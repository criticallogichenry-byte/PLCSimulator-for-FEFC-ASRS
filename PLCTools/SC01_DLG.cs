using ddmcOTIZ;
using Methods_FENC;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PLCTools.Frm_Monitor;

namespace PLCTools
{
    public partial class SC01_DLG : Form
    {
        ManualResetEvent _pauseEventP = new ManualResetEvent(true);
        ManualResetEvent _shutdownEventP = new ManualResetEvent(false);

        Thread m_hThread;

        _1121P m1121P = new _1121P();
        _1122V m1122V = new _1122V();
        _2032V m2032V = new _2032V();
        _2033P m2033P = new _2033P();

        string zSQL;
        int m_nPLCID;
        string m_zMessageRAW;
        int m_nDelayTime = 0;

        static PLCdata_FENC mPLC;
        Methods_FENC.DBconfiguration mDBset = new Methods_FENC.DBconfiguration();
        SqlConnection icn_3;        // Query data from Phase III

        public delegate string MessageParseDelegate(string zz);
        public MessageParseDelegate m_SubMessageParseFUN;                

        public SC01_DLG(Methods_FENC.DBconfiguration DataSET, int nPLCID)
        {
            InitializeComponent();

            m_nPLCID = nPLCID;

            mDBset = DataSET;
            // 用於建立到站交訊及刪除。
            mPLC = new PLCdata_FENC(DataSET.DBIP, DataSET.DBUSER, DataSET.DBPW, DataSET.DBTABLE, false);     // real OTIZ connection            
        }
        
        //  
        private void DisplayMessageFUN(string zRAW, bool bIsClear)
        {
            if (this.InvokeRequired)
            {
                DisplayToUI uu = new DisplayToUI(DisplayMessageFUN);
                this.Invoke(uu, new object[] { zRAW, bIsClear });
            }
            else
            {
                //DisplayMessageToUI(zMsg, bIsClear);

                // 先不進行清除，避免畫面閃爍。
                // 清除richtextbox內容                
                if (bIsClear)
                {
                    //richTextBox_Display.Clear();
                    //richTextBox_Display.Focus();
                    richTextBox_Display.SelectionColor = Color.White;
                    richTextBox_Display.AppendText("============================= 我是分隔線 =========================\r\n");
                }
                else
                {
                    string[] zBuffer = zRAW.Split('+');

                    // 拆解時間日期
                    string zYear = zBuffer[1].Substring(0, 4);
                    string zDate = zBuffer[1].Substring(4, 4);
                    string zHour = zBuffer[1].Substring(8, 2);
                    string zMin = zBuffer[1].Substring(10, 2);
                    string zSec = zBuffer[1].Substring(12, 2);

                    string zMsg = zBuffer[0] + " ---> 時間 [" + zHour + ":" + zMin +":" + zSec + "]" + "\r\n";           // 交訊內容+時間
                    
                    // 依命令與通知使用不同顏色顯示
                    if (zMsg.Contains("2032"))
                        richTextBox_Display.SelectionColor = Color.Lime;
                    else if (zMsg.Contains("2033"))
                    {
                        if (zMsg.Contains("WORKING"))
                            richTextBox_Display.SelectionColor = Color.DeepSkyBlue;
                        else
                            richTextBox_Display.SelectionColor = Color.Yellow;
                    }
                    else
                    {
                        richTextBox_Display.SelectionColor = Color.Red;
                        zMsg = String.Format(" 交訊內容異常 :: {0}", zMsg);
                    }

                    richTextBox_Display.AppendText(zMsg);

                    // 計算長度滾到最後一行。                    
                    richTextBox_Display.SelectionStart = richTextBox_Display.Text.Length;
                    richTextBox_Display.ScrollToCaret();
                }
            }
        }

        private void thread_worker()
        {
            while (true)
            {
                _pauseEventP.WaitOne(Timeout.Infinite);

                if (_shutdownEventP.WaitOne(0))
                    break;                

                //zSQL = String.Format("SELECT TOP 10 RAWDATA, SystemTime FROM ASRS_ReadPLCLog WHERE MessageType = 2033 AND ReceivingNodeID = {0} UNION ", m_nPLCID);
                //zSQL += String.Format("SELECT TOP 10 RAWDATA, SystemTime FROM ASRS_WritePLCLog WHERE MessageType = 2032 AND ReceivingNodeID = {0} ORDER BY SystemTime DESC", m_nPLCID);

                zSQL = String.Format("SELECT TOP 10 * FROM (SELECT RAWDATA, SystemTime FROM ASRS_ReadPLCLog WHERE MessageType=2033 AND ReceivingNodeID = {0} UNION ", m_nPLCID);
                zSQL += String.Format("SELECT RAWDATA, SystemTime FROM ASRS_WritePLCLog WHERE MessageType = 2032 AND ReceivingNodeID = {0}) A ORDER BY SystemTime DESC ", m_nPLCID);
                ArrayList dataROW = mPLC.ExecuteSELECT(zSQL);

                if (dataROW.Count > 0)
                {
                    for (int i = 0; i < dataROW.Count; i++)
                    {
                        string[] data = dataROW[i] as string[];
                        string zResult = m_SubMessageParseFUN(data[0]);
                        zResult += "+" + data[1];

                        DisplayMessageFUN(zResult, false);
                    }                    
                }                

                Thread.Sleep(2000);

                DisplayMessageFUN("", true);        // 清除richtextbox內容
            }
        }

        private void thread_worker_mission()
        {
            while(true)
            {
                _pauseEventP.WaitOne(Timeout.Infinite);

                if (_shutdownEventP.WaitOne(0))
                    break;

                ArrayList dataROW = mPLC.ExecuteSELECT("SELECT TOP 1 SystemTime, SequenceNumber, RawData FROM ASRS_WritePLCRAW ORDER BY SystemTime");

                if (dataROW.Count > 0)
                {
                    string[] data = dataROW[0] as string[];
                    string zSystemTime = data[0];                    
                    string zRAW = data[2];
                    int nSequenceNumber = Convert.ToInt32(data[1]);

                    int nType = mPLC.DispatchRAW(zRAW);

                    if (nType > 0)
                    {
                        switch(nType)
                        {
                            case 1122:
                                ProcessProcedure_PL(zRAW, zSystemTime);
                                break;

                            case 2032:
                                ProcessProcedure_SA(zRAW, zSystemTime);
                                break;
                        }

                        DeleteRAW(zSystemTime, nType, nSequenceNumber); 
                    }
                }
                Thread.Sleep(m_nDelayTime);
            }
        }

        private void click_start(object sender, EventArgs e)
        {
            //string zResult = m_SubMessageParseFUN("0000001000000001000007f1000000190000000100000D6D000000040000000200000000000000000000000000000000000018D3000000000000000100000010");

            if (m_hThread == null)
            {
                //m_hThread = new Thread(new ThreadStart(this.thread_worker));
                m_hThread = new Thread(new ThreadStart(this.thread_worker_mission));
                m_hThread.IsBackground = true;
                m_hThread.Start();

                btn_start.Text = "暫停";
            }
            // 暫停
            else if (btn_start.Text == "暫停")
            {
                _pauseEventP.Reset();
                btn_start.Text = "啟動";
            }
            // 重啟
            else
            {
                _pauseEventP.Set();
                btn_start.Text = "暫停";
            }
        }

        // 停止執行緒並關閉視窗
        private void click_stop(object sender, EventArgs e)
        {
            _shutdownEventP.Set();

            Close();
        }

        public static string GetErrorDesc(int nErrorCode)
        {
            string zErrorDESC = "";

            string zSQL = String.Format("SELECT Err_Desc FROM ErrorCodeDelimit WHERE Err_Code = {0}", nErrorCode);
            ArrayList dataROW = mPLC.ExecuteSELECT(zSQL);

            if (dataROW.Count == 0)
                zErrorDESC = nErrorCode.ToString();
            else
            {
                string[] data = dataROW[0] as string[];

                zErrorDESC = data[0];
            }

            return zErrorDESC;
        }

        public void ProcessProcedure_PL(string zRAW, string zSystemTimeV)
        {
            string zResult = "";

            // 顯示 1122V內容
            zResult = m_SubMessageParseFUN(zRAW);
            zResult += "+" + zSystemTimeV;
            DisplayMessageFUN(zResult, false);

            mPLC.V1122(ref m1122V);

            m1121P.header = m1122V.header;
            m1121P.BARCODE = m1122V.BARCODE;
            m1121P.TRACK_ID = m1122V.TRACK_ID;

            m1121P.SG_ID1 = 1;
            m1121P.SG_ID2 = 1;
            m1121P.SG_ID3 = 1;
            m1121P.SG_ID4 = 1;
            m1121P.SG_ID5 = 1;

            if (m1122V.COMMAND == 3)
            {
/*
                // 產生離站通知
                m1121P.STATION_NR = m1122V.STATION_NR;
                m1121P.STATUS = 99;

                m_zMessageRAW = mPLC.messageP(1121, m1121P, true);
                zResult = m_SubMessageParseFUN(m_zMessageRAW);
                zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                DisplayMessageFUN(zResult, false);

                Thread.Sleep(10000);     // waiting for 2seconds
*/

                // 產生下一站到站通知
                m1121P.STATION_NR = m1122V.DESTINATION_STATION_NR;
                m1121P.STATUS = 1;

                m_zMessageRAW = mPLC.messageP(1121, m1121P, true);
                zResult = m_SubMessageParseFUN(m_zMessageRAW);
                zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                DisplayMessageFUN(zResult, false);

                Thread.Sleep(2000);
                
                // 自動產生碼頭離站通知
                if (m1121P.STATION_NR == 4373 || m1121P.STATION_NR==4363 || m1121P.STATION_NR == 4353 || m1121P.STATION_NR == 4343 || m1121P.STATION_NR == 4333 || m1121P.STATION_NR == 4323 || m1121P.STATION_NR == 4313)
                {
                    m1121P.STATUS = 99;

                    m_zMessageRAW = mPLC.messageP(1121, m1121P, true);
                    zResult = m_SubMessageParseFUN(m_zMessageRAW);
                    zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    DisplayMessageFUN(zResult, false);
                }
            }
        }

        public void ProcessProcedure_SA(string zRAW, string zSystemTimeV)
        {
            string zResult = "";

            mPLC.V2032(ref m2032V);

            // 顯示 1122V內容
            zResult = m_SubMessageParseFUN(zRAW);
            zResult += "+" + zSystemTimeV;
            DisplayMessageFUN(zResult, false);

            m2033P.header = m2032V.header;
            m2033P.DEVICE_NR = m2032V.DEVICE_NR;

            switch(m2032V.MISSION_TYPE)
            {
                case 1: // LOAD
                    break;
                case 2: // UNLOAD
                    break;
                case 3: // MOVE
                    break;
                case 4: // LOAD-UNLOAD

                    // storage
                    if (m2032V.SRC_DEVICE == 1)
                    {
                        // generate WORKING
                        m2033P.MISSION_TYPE = m2032V.MISSION_TYPE;
                        m2033P.MISSION_RESULT = 0;          // working
                        m2033P.DEVICE = 1;                  // storage
                        m2033P.SIDE = m2032V.SRC_SIDE;
                        m2033P.LEVEL = m2032V.SRC_LEVEL;
                        m2033P.POSITION = m2032V.SRC_POSITION;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK

                        m_zMessageRAW = mPLC.messageP(2033, m2033P, true);
                        zResult = m_SubMessageParseFUN(m_zMessageRAW);
                        zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        DisplayMessageFUN(zResult, false);

                        Thread.Sleep(2000);

                        // generate COMPLTET
                        m2033P.MISSION_RESULT = 1;          // complete
                        m2033P.DEVICE = 2;                  // bay
                        m2033P.SIDE = 0;
                        m2033P.LEVEL = 0;
                        m2033P.POSITION = 0;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK
                    }
                    // Bay
                    else if (m2032V.SRC_DEVICE == 2)
                    {
                        // generate WORKING
                        m2033P.MISSION_RESULT = 0;          // working
                        m2033P.DEVICE = 2;                  // bay
                        m2033P.SIDE = 0;
                        m2033P.LEVEL = 0;
                        m2033P.POSITION = 0;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK

                        m_zMessageRAW = mPLC.messageP(2033, m2033P, true);
                        zResult = m_SubMessageParseFUN(m_zMessageRAW);
                        zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        DisplayMessageFUN(zResult, false);

                        Thread.Sleep(2000);
/*
                        // 入庫端輸送帶離站通知
                        if (m2032V.DEVICE_NR == 3431)
                            m1121P.STATION_NR = 3272;
                        else if (m2032V.DEVICE_NR == 3432)
                            m1121P.STATION_NR = 3262;
                        else if (m2032V.DEVICE_NR == 3433)
                            m1121P.STATION_NR = 3252;
                        else if (m2032V.DEVICE_NR == 3434)
                            m1121P.STATION_NR = 3242;
                        else if (m2032V.DEVICE_NR == 3435)
                            m1121P.STATION_NR = 3232;
                        else if (m2032V.DEVICE_NR == 3436)
                            m1121P.STATION_NR = 3222;
                        else if (m2032V.DEVICE_NR == 3437)
                            m1121P.STATION_NR = 3212;

                        m1121P.header.PR_MSG = 1;
                        m1121P.header.ID_PLC = 41;
                        m1121P.header.ID_MSG = 1121;
                        m1121P.STATUS = 99;
                        m1121P.TRACK_ID = m2032V.TRACK_ID;
                        m1121P.BARCODE = "XXXXXXXX";

                        m_zMessageRAW = mPLC.messageP(1121, m1121P, true);
                        zResult = m_SubMessageParseFUN(m_zMessageRAW);
                        zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        DisplayMessageFUN(zResult, false);

                        Thread.Sleep(2000);
*/

                        // generate COMPLETE
                        m2033P.MISSION_TYPE = m2032V.MISSION_TYPE;
                        m2033P.MISSION_RESULT = 1;          // complete
                        m2033P.DEVICE = 1;                  // storage
                        m2033P.SIDE = m2032V.DST_SIDE;
                        m2033P.LEVEL = m2032V.DST_LEVEL;
                        m2033P.POSITION = m2032V.DST_POSITION;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK
                    }
                    // feedback
                    else if (m2032V.SRC_DEVICE == 3)
                    {
                        // generate WORKING
                        m2033P.MISSION_TYPE = m2032V.MISSION_TYPE;
                        m2033P.MISSION_RESULT = 0;          // working
                        m2033P.DEVICE = 2;                  // bay
                        m2033P.SIDE = 0;
                        m2033P.LEVEL = 0;
                        m2033P.POSITION = 0;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK

                        m_zMessageRAW = mPLC.messageP(2033, m2033P, true);
                        zResult = m_SubMessageParseFUN(m_zMessageRAW);
                        zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        DisplayMessageFUN(zResult, false);

                        Thread.Sleep(2000);

                        // generate COMPLTET
                        m2033P.MISSION_RESULT = 1;          // complete
                        m2033P.DEVICE = 1;                  // storage
                        m2033P.SIDE = m2032V.DST_SIDE;
                        m2033P.LEVEL = m2032V.DST_LEVEL;
                        m2033P.POSITION = m2032V.DST_POSITION;
                        m2033P.TYPE_PALLET = m2032V.TYPE_PALLET;
                        m2033P.TRACK_ID = m2032V.TRACK_ID;
                        m2033P.ERROR_CODE = 1;              // OK
                    }

                    m_zMessageRAW = mPLC.messageP(2033, m2033P, true);
                    zResult = m_SubMessageParseFUN(m_zMessageRAW);
                    zResult += "+" + DateTime.Now.ToString("yyyyMMddHHmmss");
                    DisplayMessageFUN(zResult, false);

                    break;
            }            

        }

        public void DeleteRAW(string zSystemTime, int nMessageType, int nSequenceNumber)
        {
            string zSQL = "UPDATE ASRS_WritePLCLog SET finishedTime=Replace(Replace(Replace(CONVERT(varchar(21), GETDATE(), 120),'-',''),':',''),' ','') "
                        + "WHERE SystemTime='" + zSystemTime + "' AND MessageType=" + nMessageType + " AND  SequenceNumber='" + nSequenceNumber + "' ";
            mPLC.SqlInsertUpdateDeleteII(zSQL, false);

            zSQL = String.Format("DELETE ASRS_WritePLCRaw WHERE MessageType = {0} AND SequenceNumber = {1} AND SystemTime = {2}", nMessageType, nSequenceNumber, zSystemTime);
            mPLC.SqlInsertUpdateDeleteII(zSQL, false);
        }

        private void comboBox_delay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cast the sender back to a ComboBox
            ComboBox cb = sender as ComboBox;

            if (cb != null)
            {
                // Get the selected item value/text
                string selectedValue = cb.SelectedItem?.ToString();

                switch (selectedValue)
                {
                    case "NONE":
                        m_nDelayTime = 0;
                        break;
                    case "1 秒":
                        m_nDelayTime = 1000;
                        break;
                    case "3 秒":
                        m_nDelayTime = 3000;
                        break;
                    case "5 秒":
                        m_nDelayTime = 5000;
                        break;
                }
            }
        }

        private void SC01_DLG_Load(object sender, EventArgs e)
        {
            comboBox_delay.SelectedIndex = 0;
        }
    }
}
