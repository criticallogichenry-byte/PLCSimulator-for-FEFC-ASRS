using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Methods;
using ddmcOTIZ;
using ddmcFEFC;
using System.Security.AccessControl;
using System.Data.SqlClient;
using Methods_FENC;
using MessageCheck;
using Methods.Algorithm;

using System.Collections;
using System.Diagnostics.Eventing.Reader;

namespace PLCTools
{
    public partial class Frm_Monitor : Form
    {
        ManualResetEvent _pauseEventP = new ManualResetEvent(true);
        ManualResetEvent _shutdownEventP = new ManualResetEvent(false);

        Thread m_hThread;

        PLCdata_FENC mPLC;
        Methods_FENC.DBconfiguration mDBset = new Methods_FENC.DBconfiguration();
        SqlConnection icn_3;        // Query data from Phase III
        
        object m_MessageObject;
        string m_szMessageSystemTime;
        string m_RAW;
        int m_nSerialNO = 0;

        SC01_DLG[] mSC_DLG = new SC01_DLG[8];        // 吊車實時監控畫面。對應combox中的七輛吊車，其中的NONE保留不用，因此陣列為8

        Methods_FENC._1121P m1121P = new Methods_FENC._1121P();
        Methods_FENC._1122V m1122V = new Methods_FENC._1122V();
        Methods_FENC._2032V m2032V = new Methods_FENC._2032V();
        Methods_FENC._2033P m2033P = new Methods_FENC._2033P();
        Algorithm m_DataConvert = new Algorithm();

        // 完整解析交訊內容的代理器
        public delegate int MessageParseDelegate(string zz, ref string m_szResult, ref object Message);
        public MessageParseDelegate m_MessageParseFUN;

        // 僅簡單顯示交訊內容的代理器
        public delegate string MessageParseDelegateToRough(string zz);
        public MessageParseDelegateToRough m_MessageParseROUGH;

        public delegate void DisplayToUI(string zz, bool bIsClear);        // 存粹用於thread進行跨線程UI的代理器

        public delegate void DisplayBindingSourceDelegate(DataTable dt);

        public Frm_Monitor(Methods_FENC.DBconfiguration DataSET)
        {
            InitializeComponent();

            mDBset = DataSET;
            // 用於建立到站交訊及刪除。
            mPLC = new PLCdata_FENC(DataSET.DBIP, DataSET.DBUSER, DataSET.DBPW, DataSET.DBTABLE, false);     // real OTIZ connection
            // 用於顯示於DataGripView
            string cnstr = string.Format("server={0};database={1};uid={2};pwd={3};Connect Timeout = 180", DataSET.DBIP, DataSET.DBTABLE, DataSET.DBUSER, DataSET.DBPW);
            icn_3 = new SqlConnection();
            icn_3.ConnectionString = cnstr;
        }

        private void DisplayBindingSource(DataTable dt)
        {            
            if (this.InvokeRequired)
            {
                DisplayBindingSourceDelegate uu = new DisplayBindingSourceDelegate(DisplayBindingSource);
                this.Invoke(uu, new object[] { dt });
            }
            else
            {
                DisplayBindingSourceHandler(dt);
            }
        }

        private void StartMonitor()
        {
            m_hThread = new Thread(new ThreadStart(this.thread_worker));
            m_hThread.IsBackground = true;
            m_hThread.Start();
        }

        public void DisplayBindingSourceHandler(DataTable dt)
        {
            string zResult = string.Empty;

            BindingSource bsource = new BindingSource();

            // 測試取得第一筆指定欄位之內容
            dt.Columns.Add("Content", typeof(string));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string zz = dt.Rows[i]["RawData"].ToString();
                // 產生交訊內容說明供顯示畫面顯示
                //zz = m_pBASE.MessageParserForDisplay(zz);
                m_MessageParseFUN(zz, ref zResult, ref m_MessageObject);

                // 轉譯後的內容放至 dataGridView 中新增的 content 欄位裡
                dt.Rows[i][6] = zResult;

                // Modify the Day/Time format 並塞入 dataGridView 中的日期欄位
                // 不對日期進行客制化格式。
                //zz = dt.Rows[i]["SystemTime"].ToString();
                //string zDateTime = String.Format("{0} {1}/{2} {3}:{4}:{5}", zz.Substring(2, 2), zz.Substring(4, 2), zz.Substring(6, 2), zz.Substring(8, 2), zz.Substring(10, 2), zz.Substring(12, 2));
                //dt.Rows[i][0] = zDateTime;
            }

            // 雖然在SQL已進行過ORDER排序，在DataView也可再做一次排序。此次條件為 SystemTime、FinishedTime。
            // 若兩時間都一樣，則會有順序與實際順序不同，這點在參考排序結果時要以實際排序為主。
            dt.DefaultView.Sort = "SystemTime DESC";

            bsource.DataSource = dt;
            dataGridView_command.DataSource = bsource;
        }

        // 使用 Form1的delegate解析交訊內容。此函式做為參數傳給SC物件做為callback
        private string DisplayMessageToFormUI(string zRAW)
        {
            string zResult = "";
            //m_MessageParseFUN(zRAW, ref zResult, ref m_MessageObject);
            zResult = m_MessageParseROUGH(zRAW);

            return zResult;
        }

        // 執行SQL並將結果顯示至 DataGridView
        private void sendSQL(string zSQL)
        {
            SqlCommand cmd;

            cmd = new SqlCommand(zSQL, icn_3);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            DisplayBindingSource(dt);
        }

        public string GetErrorDesc(int nDeviceID, int nErrorCode)
        {
            string zErrorDESC = "";

            string zSQL = String.Format("SELECT AlarmMessage FROM ASRS_AlarmInfo WHERE DeviceID = {0} AND AlarmCode = {1}", nDeviceID, nErrorCode);
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

        private void UPDATE_DeviceStatusInfo(int nTRACK_ID, int nStationNR, int nStatus)
        {
            string zSQL = "";
            if (nStatus == 1)
                zSQL = String.Format("UPDATE ASRS_DeviceStatusInfo SET TrackID={0} WHERE DeviceID={1}", nTRACK_ID, nStationNR);
            else if (nStatus == 99)
            {
                if (nStationNR == 3112)
                    zSQL = String.Format("UPDATE ASRS_DeviceStatusInfo SET TrackID=NULL WHERE DeviceID={0}", nStationNR);
                else
                    zSQL = String.Format("UPDATE ASRS_DeviceStatusInfo SET TrackID=NULL WHERE TrackID={0} AND DeviceID={1}", nTRACK_ID, nStationNR);
            }
            else            // 未定義視為離站清除
                zSQL = String.Format("UPDATE ASRS_DeviceStatusInfo SET TrackID=NULL WHERE TrackID={0} AND DeviceID={1}", nTRACK_ID, nStationNR);     
            
            if (nStationNR == 3112)
            {
                zSQL = String.Format("UPDATE ASRS_DeviceStatusInfo SET TrackID=NULL WHERE DeviceID={0}", nStationNR);
            }

            mPLC.SqlInsertUpdateDelete(zSQL);
        }

        private void thread_worker()
        {
            while (true)
            {
                _pauseEventP.WaitOne(Timeout.Infinite);

                if (_shutdownEventP.WaitOne(0))
                    break;

                //int nType = mPLC.ReadPLCRaw(PLC_READ.GENERAL, ref m_szMessageSystemTime, ref m_RAW, ref m_nSerialNO, PLC_TYPE.ROBOT_SR2);      // 測試使用7號代碼，指定PLC=50                
                // sendSQL("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, RawData FROM ASRS_WritePLCRaw WHERE MessageType IN (1122, 2032) ORDER BY SystemTime DESC");

                /*
                zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, RawData FROM ASRS_WritePLCLog WHERE MessageType = 2032 AND SUBSTRING(RawData,129,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} UNION ", zTrackID, StartTime, EndTime);
                 zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, RawData FROM ASRS_WritePLCLog WHERE MessageType = 1122 AND SUBSTRING(RawData,73,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} ORDER BY SystemTime DESC", zTrackID, StartTime, EndTime);
                            }
                 */
                // 即時監看吊車命令及拖盤到3112通知
                string zSQL = "";
                //zSQL = "SELECT TOP 50 SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE MessageType IN (1122, 2032) UNION ";
                // 只監控3112進站離站。
                zSQL = "SELECT TOP 50 SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE MessageType = 1122  AND SUBSTRING(RawData,41,8) = '00000C28'  AND SUBSTRING(RawData,49,8) = '00000003'UNION ";
                zSQL += "SELECT TOP 50 SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_ReadPLCLog WHERE MessageType = 1121 AND SUBSTRING(RawData,41,8) = '00000C28' ORDER BY SystemTime DESC";
                sendSQL(zSQL);

                Thread.Sleep(200);
            }
        }

        private void Frm_Monitor_Load(object sender, EventArgs e)
        {
            this.dateTimeFROM.Value = DateTime.Now.AddHours(-1);
            this.dateTimeTO.Value = DateTime.Now.AddHours(1);

            // 2033P 使用的樓層選項動態產生
            for (int i = 0; i <= Constants_GUAN_YING._MAX_LAYER; i++)
            {
                LEVELcomboBox.Items.Add(i);
            }

            comboBox_SC.SelectedIndex = 0;
        }

        // DataGridView 雙擊後取得解譯後的RAW內容，並將轉為交訊格式
        private void dataGridView_command_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nType = 0;
            string zResult = string.Empty;
            string value = dataGridView_command.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            string zSystemTime = dataGridView_command.Rows[e.RowIndex].Cells[0].Value.ToString();
            int nSerialNO = Convert.ToInt16(dataGridView_command.Rows[e.RowIndex].Cells[1].Value.ToString());
            int nReceivingNodeID = Convert.ToInt16(dataGridView_command.Rows[e.RowIndex].Cells[2].Value.ToString());

            nType = m_MessageParseFUN(value, ref zResult, ref m_MessageObject);

            ProcessMessageContent(nType, zSystemTime, zResult, m_MessageObject);

            //mPLC.DeletePLCRaw(zSystemTime, nReceivingNodeID, nSerialNO);
        }

        // 雙擊 DataGripView 之後呼叫此函式取得 RAW 內容轉為結構並進行資料處理
        private void ProcessMessageContent(int nType, string zSystemtime, string zResult, object MessageObject)
        {
            int nSerialNO = 0;
            int nSendingNodeID = 0;

            comboBox_SGID_1.SelectedIndex = 0;
            comboBox_SGID_2.SelectedIndex = 0;
            comboBox_SGID_3.SelectedIndex = 0;
            comboBox_SGID_4.SelectedIndex = 0; ;
            comboBox_SGID_5.SelectedIndex = 0;

            switch (nType)
            {
                case 1121:
                    m1121P = (Methods_FENC._1121P)m_MessageObject;
                    nSerialNO = m1121P.header.PR_MSG;
                    nSendingNodeID = m1121P.header.ID_PLC;

                    textBox_STATION_NR.Text = m1121P.STATION_NR.ToString();

                    textBox_BARCODE.Text = m1121P.BARCODE;

                    textBox_TRACKID_1121.Text = m1121P.TRACK_ID.ToString();

                    if (m1121P.STATUS == 1)
                        comboBox_STATUS.SelectedIndex = 0;              // Arrived
                    else
                        comboBox_STATUS.SelectedIndex = 1;              // Evaucation

                    comboBox_SGID_1.SelectedIndex = m1121P.SG_ID1;
                    comboBox_SGID_2.SelectedIndex = m1121P.SG_ID2;
                    comboBox_SGID_3.SelectedIndex = m1121P.SG_ID3;
                    comboBox_SGID_4.SelectedIndex = m1121P.SG_ID4;
                    comboBox_SGID_5.SelectedIndex = m1121P.SG_ID5;
                    break;
                case 1122:
                    m1122V = (Methods_FENC._1122V)m_MessageObject;
                    nSerialNO = m1122V.header.PR_MSG;
                    nSendingNodeID = m1122V.header.ID_PLC;
                    break;
                case 2032:
                    m2032V = (Methods_FENC._2032V)m_MessageObject;
                    nSerialNO = m2032V.header.PR_MSG;
                    nSendingNodeID = m2032V.header.ID_PLC;
                    m2032V = (Methods_FENC._2032V)m_MessageObject;
                    break;
                case 2033:
                    m2033P = (Methods_FENC._2033P)m_MessageObject;
                    nSerialNO = m2033P.header.PR_MSG;
                    nSendingNodeID = m2033P.header.ID_PLC;
                    break;
            }
            
            richTextBox_Display.Text = zResult;
                     
            textBox_TRACKID_2033.Text = m2032V.TRACK_ID.ToString();            

            //mPLC.DeletePLCRaw(zSystemtime, 1, nSerialNO);

            // 依1121、2032命令產生對應到對話框的1121、2033通知
            switch(nType)
            {
                case 1122:
                    // 模擬收到拖盤移動命令，拖盤移動到指定目的地的到站通知交訊。
                    textBox_STATION_NR.Text = m1122V.DESTINATION_STATION_NR.ToString();
                    textBox_TRACKID_1121.Text = m1122V.TRACK_ID.ToString();
                    comboBox_STATUS.SelectedIndex = 0; // Arrived
                    //m1121P.SG_ID1 = Convert.ToInt16(comboBox_SGID_1.GetItemText(comboBox_SGID_1.SelectedItem));
                    //m1121P.SG_ID2 = Convert.ToInt16(comboBox_SGID_2.GetItemText(comboBox_SGID_2.SelectedItem));
                    //m1121P.SG_ID3 = Convert.ToInt16(comboBox_SGID_3.GetItemText(comboBox_SGID_3.SelectedItem));
                    //m1121P.SG_ID4 = Convert.ToInt16(comboBox_SGID_4.GetItemText(comboBox_SGID_4.SelectedItem));
                    //m1121P.SG_ID5 = Convert.ToInt16(comboBox_SGID_5.GetItemText(comboBox_SGID_5.SelectedItem));
                    break;

                case 2032:      // DataGridView 雙擊後，只對2032命令內容對應顯示到2033P介面。以做為事後補通知方便
                    int nSelected = m2032V.DEVICE_NR - 3430;
                    SAcomboBox.SelectedIndex = nSelected - 1;           // 減掉設備代碼3430，再減去1獲得對應comboxBox的對應碼

                    ERRORcomboBox.SelectedIndex = 0;
                    MISSIONcomboBox.SelectedIndex = 0;

                    // 任務型態
                    MissionTYPEcomboBox.SelectedIndex = m2032V.MISSION_TYPE - 1;

                    // 設備
                    if (m2032V.MISSION_TYPE == 1)   // LOAD
                    {
                        comboBox_DEVICE.SelectedIndex = m2032V.SRC_DEVICE - 1;
                        // 第幾層
                        LEVELcomboBox.SelectedIndex = m2032V.SRC_LEVEL;         // 樓層不用減1。項目0可做為空值使用
                        // 第幾格
                        POStextBox.Text = m2032V.SRC_POSITION.ToString();
                        // 哪一面
                        SIDEcomboBox.SelectedIndex = m2032V.SRC_SIDE - 1;
                    }
                    else if (m2032V.MISSION_TYPE == 2 || m2032V.MISSION_TYPE == 3) // UNLOAD、MOVE
                    {
                        comboBox_DEVICE.SelectedIndex = m2032V.DST_DEVICE - 1;
                        // 第幾層
                        LEVELcomboBox.SelectedIndex = m2032V.DST_LEVEL;         // 樓層不用減1。項目0可做為空值使用
                        // 第幾格
                        POStextBox.Text = m2032V.DST_POSITION.ToString();
                        // 哪一面
                        SIDEcomboBox.SelectedIndex = m2032V.DST_SIDE - 1;
                    }
                    // LOAD-UNLOAD 組合命令涉及來源與目的有可能是庫格及碼頭，因此必須限定只能手動給予參數，否則不予接受。
                    // 此設定於使用者按下 SEND 按紐檢查若為 "手動指定" 則不予許使用。
                    else if (m2032V.MISSION_TYPE == 4) // LOAD-UNLOAD
                    {
                        comboBox_DEVICE.SelectedIndex = m2032V.DST_DEVICE - 1;
                        // 第幾層
                        LEVELcomboBox.SelectedIndex = m2032V.SRC_LEVEL;         // 樓層不用減1。項目0可做為空值使用
                        // 第幾格
                        POStextBox.Text = m2032V.SRC_POSITION.ToString();
                        // 哪一面
                        SIDEcomboBox.SelectedIndex = m2032V.SRC_SIDE - 1;

                        MISSIONcomboBox.SelectedIndex = 3;  // 手動指定
                    }

                    break;
            }
        }

        private void CollectAllUIdata(int nType)
        {
            string szITEM = null;
            
            m2033P.header.ID_SRC = 1;
            m2033P.header.ID_MSG = nType;                        
            m2033P.header.PR_MSG = 1;

            if (nType == 2033)
            {
                m2033P.header.MSG_LEN = Methods_FENC._2033P.FOOTER;

                szITEM = SAcomboBox.GetItemText(SAcomboBox.SelectedItem);
                if (szITEM == "SA31")
                {
                    m2033P.DEVICE_NR = 3431;
                    m2033P.header.ID_PLC = 19;
                }
                else if (szITEM == "SA32")
                {
                    m2033P.DEVICE_NR = 3432;
                    m2033P.header.ID_PLC = 20;
                }
                else if (szITEM == "SA33")
                {
                    m2033P.DEVICE_NR = 3433;
                    m2033P.header.ID_PLC = 21;
                }
                else if (szITEM == "SA34")
                {
                    m2033P.DEVICE_NR = 3434;
                    m2033P.header.ID_PLC = 22;
                }
                else if (szITEM == "SA35")
                {
                    m2033P.DEVICE_NR = 3435;
                    m2033P.header.ID_PLC = 23;
                }
                else if (szITEM == "SA36")
                {
                    m2033P.DEVICE_NR = 3436;
                    m2033P.header.ID_PLC = 24;
                }
                else if (szITEM == "SA37")
                {
                    m2033P.DEVICE_NR = 3437;
                    m2033P.header.ID_PLC = 25;
                }

                // MISSION_TYPE
                switch (Convert.ToInt16(MissionTYPEcomboBox.SelectedIndex))
                {
                    case 0:             // LOAD
                        m2033P.MISSION_TYPE = 1;
                        break;
                    case 1:             // UNLOAD
                        m2033P.MISSION_TYPE = 2;
                        break;
                    case 2:             // MOVE
                        m2033P.MISSION_TYPE = 3;
                        break;
                    case 3:             // LOAD-UNLOAD
                        m2033P.MISSION_TYPE = 4;
                        break;
                }

                // DEVICE
                switch (Convert.ToInt16(comboBox_DEVICE.SelectedIndex) + 1)
                {
                    case 1:             // STORAGE
                        m2033P.DEVICE = 1;
                        break;
                    case 2:             // LOAD/UNLOADING BAY
                        m2033P.DEVICE = 2;
                        break;
                    case 3:             // FEEDBACK/PICKOUT
                        m2033P.DEVICE = 3;
                        break;
                    case 4:             // STATION
                        m2033P.DEVICE = 4;
                        break;
                }

                // SIDE
                switch (Convert.ToInt16(SIDEcomboBox.SelectedIndex) + 1)
                {
                    case 1:             // LEFT
                        m2033P.SIDE = 1;
                        break;
                    case 2:             // RIGHT
                        m2033P.SIDE = 2;
                        break;
                    case 3:             // NULL
                        m2033P.SIDE = 0;
                        break;
                }

                // LEVEL
                m2033P.LEVEL = Convert.ToInt16(LEVELcomboBox.SelectedIndex);

                // POS
                m2033P.POSITION = Convert.ToInt16(POStextBox.Text);

                // TRACK_ID
                m2033P.TRACK_ID = Convert.ToInt32(textBox_TRACKID_2033.Text);

                // TYPE_PALLET
                //m2033P.TYPE_PALLET = Convert.ToInt32(TYPE_PALLETtextBox.Text);
                if (checkBox_LARGE.Checked)
                    m2033P.TYPE_PALLET = 0;
                else
                    m2033P.TYPE_PALLET = 1;

                // ERROR_CODE
                m2033P.ERROR_CODE = Convert.ToInt32(ERRORcomboBox.SelectedIndex) + 1;      // data from 1

                // MISSION_RESULT
                m2033P.MISSION_RESULT = Convert.ToInt32(MISSIONcomboBox.SelectedIndex);    // data from 0

                mPLC.messageP(2033, m2033P, true);
            }
        }

        private void send1121P(int nStationNR, int nStatus, int nTrackID, string zBARCODE="", bool bDoDeviceStatusInfo=true)
        {
            m1121P.header.MSG_LEN = Methods_FENC._1121P.FOOTER;
            m1121P.header.PR_MSG = 1;
            m1121P.header.ID_MSG = 1121;
            m1121P.header.ID_PLC = 41;
            m1121P.header.ID_SRC = 1;

            m1121P.STATION_NR = nStationNR;
            m1121P.STATUS = nStatus;
            m1121P.BARCODE = m_DataConvert.StringToHEXstring(zBARCODE);
            m1121P.TRACK_ID = nTrackID;
            m1121P.SG_ID1 = 8;
            m1121P.SG_ID2 = 0;
            m1121P.SG_ID3 = 0;
            m1121P.SG_ID4 = 0;
            m1121P.SG_ID5 = 0;

            mPLC.messageP(1121, m1121P, true);

            // 同自更新以下資料表。此資料表由PLC更新，這裡手動模擬更新。
            UPDATE_DeviceStatusInfo(m1121P.TRACK_ID, nStationNR, nStatus);
        }

 // ********************************************* 按鈕事件 ************************************************
        private void click_Send2033P(object sender, EventArgs e)
        {
            // LOAD-UNLOAD 組合命令涉及來源與目的有可能是庫格及碼頭，因此必須限定只能手動給予參數，否則不予接受。
            // 此設定於使用者按下 SEND 按紐檢查若為 "手動指定" 則不予許使用。
            if (MISSIONcomboBox.GetItemText(MISSIONcomboBox.SelectedItem) == "手動指定")
            {
                MessageBox.Show("此為組合命令，必須手動設定所有參數");
                return;
            }

            CollectAllUIdata(2033);

            // // LOAD - UNLOAD。發兩次通知，使用者不用指定 mission_result 的狀態。程式分別產生 working、completed
            if (m2033P.MISSION_TYPE == 4)
            {
                //如果是COMPLETE，則產生1121棧板到站通知
                if (m2033P.MISSION_RESULT == 1)
                {
                    // 棧板出庫產生1121P到站
                    if (m2033P.DEVICE == 2)  // Bay
                    {
                        switch (m2033P.DEVICE_NR)
                        {
                            case 3431:
                                //send1121P(4011, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3432:
                                //send1121P(4024, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3433:
                                //send1121P(4034, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3434:
                                //send1121P(4044, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3435:
                                //send1121P(4054, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3436:
                                //send1121P(4064, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                            case 3437:
                                //send1121P(4074, m2033P.DEVICE_NR, m2033P.TRACK_ID);
                                UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 99);
                                break;
                        }
                    }
                }
                else if (m2033P.MISSION_RESULT == 0)
                    UPDATE_DeviceStatusInfo(m2033P.TRACK_ID, m2033P.DEVICE_NR, 1);      // 更新trackID所在的設備
            }
            else // 其他單獨狀態完成一律回 complted
            {
                // 單獨 LOAD 回應吊車COMPLETE即可
                if (m2033P.MISSION_TYPE == 1)
                {
                    m2033P.MISSION_RESULT = 1;
                    mPLC.messageP(2033, m2033P, true);
                }

                // 若目的地是UNLOAD至Bay，則依對應的高架吊車位置指定碼頭編號。
                if (m2033P.MISSION_TYPE == 2 && m2033P.DEVICE == 2)   // unload
                {
                    // 4014、4024 ..... 出庫碼頭尾數1是出庫。尾數4才是入庫用
                    switch (m2033P.DEVICE_NR)
                    {
                        case 3431:
                            send1121P(4011, 1, m2033P.TRACK_ID);
                            break;
                        case 3432:
                            send1121P(4021, 1, m2033P.TRACK_ID);
                            break;
                        case 3433:
                            send1121P(4031, 1, m2033P.TRACK_ID);
                            break;
                        case 3434:
                            send1121P(4041, 1, m2033P.TRACK_ID);
                            break;
                        case 3435:
                            send1121P(4051, 1, m2033P.TRACK_ID);
                            break;
                        case 3436:
                            send1121P(4061, 1, m2033P.TRACK_ID);
                            break;
                        case 3437:
                            send1121P(4071, 1, m2033P.TRACK_ID);
                            break;
                    }
                }
            }
        }

        private void click_Send1121P(object sender, EventArgs e)
        {
            int nSTATION_NR = 0;
            int nSTATUS = 0;
            int nTRACKID = 0;

            nSTATION_NR = Convert.ToInt32(textBox_STATION_NR.Text);
            if (textBox_TRACKID_1121.Text != "")
                nTRACKID = Convert.ToInt32(textBox_TRACKID_1121.Text);
            else
                nTRACKID = 0;

            switch (Convert.ToInt16(comboBox_STATUS.SelectedIndex))
            {
                case 0:
                    nSTATUS = 1;
                    break;
                case 1:
                    nSTATUS = 99;
                    break;
            }

            if (textBox_BARCODE.Text == "")
            {
                MessageBox.Show("請輸入箱號");
                return;
            }

            // 新棧板入掃碼準備入庫
            if (nTRACKID==0)
            {
                send1121P(nSTATION_NR, nSTATUS, nTRACKID, textBox_BARCODE.Text, false);
            }
            else
            {
                // 雙擊 DataGripView 1122V 會將下一站站點更新是UI。因此直接抓UI的站點值即可。接著再發離站。
                //send1121P(3112, 99, nTRACKID, textBox_BARCODE.Text, false);
                send1121P(nSTATION_NR, nSTATUS, nTRACKID, textBox_BARCODE.Text);                
            }
        }

        // 此按鈕依指定trackID或堆垛機號進行相關交訊查詢
        private void BTN_click_QUERY(object sender, EventArgs e)
        {            
            string StartTime = this.dateTimeFROM.Value.ToString("yyyyMMddHHmmss");
            string EndTime = this.dateTimeTO.Value.ToString("yyyyMMddHHmmss");
            
            string zSQL = "";

            // 暫停QUERY所有命令
            if (button2.Text == "暫停")            
                _pauseEventP.Reset();

            if (dataGridView_command.Rows.Count != 0)
            {
                //dataGridView_command.Rows.Clear();
                dataGridView_command.Refresh();
            }

            // 查TrackID有關的棧板及堆垛機命令及通知記錄
            if (textBox_TrackID_forQuery.Text != "")
            {                
                int nTrackID = Convert.ToInt32(textBox_TrackID_forQuery.Text);
                string zTrackID = Convert.ToString(nTrackID, 16).ToUpper().PadLeft(8, '0');

                zSQL = String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_ReadPLCLog WHERE MessageType = 2033 AND SUBSTRING(RawData,97,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} UNION ", zTrackID, StartTime, EndTime);
                zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_ReadPLCLog WHERE MessageType = 1121 AND SUBSTRING(RawData,89,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} UNION ", zTrackID, StartTime, EndTime);
                zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE MessageType = 2032 AND SUBSTRING(RawData,129,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} UNION ", zTrackID, StartTime, EndTime);
                zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE MessageType = 1122 AND SUBSTRING(RawData,73,8) = '{0}' AND Systemtime BETWEEN {1} AND {2} ORDER BY SystemTime DESC", zTrackID, StartTime, EndTime);
            }
            // 指定堆垛機號查對應命令及通知
            else
            {
                int nSelected = comboBox_SC.SelectedIndex;
                int nDeviceID = 0;
                switch(nSelected)
                {
                    case 1:         
                        nDeviceID = 19;         // SC01
                        break;
                    case 2:
                        nDeviceID = 20;
                        break;
                    case 3:
                        nDeviceID = 21;
                        break;
                    case 4:
                        nDeviceID = 22;
                        break;
                    case 5:
                        nDeviceID = 23;
                        break;
                    case 6:
                        nDeviceID = 24;
                        break;
                    case 7:
                        nDeviceID = 25;         // SC07
                        break;
                }

                // 有指定SC，則以
                if (nDeviceID != 0)
                {
                    zSQL = String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE Messagetype=2032 AND ReceivingNodeID = {0} AND Systemtime BETWEEN {1} AND {2} UNION ", nDeviceID, StartTime, EndTime);
                    // 學長將SendingNodeID做為ReceivingNodeID
                    //zSQL += String.Format("SELECT * FROM ASRS_ReadPLCLog WHERE MessageType=2033 AND SendingNodeID = {0} AND Systemtime BETWEEN {1} AND {2} ORDER BY Systemtime DESC", nDeviceID, StartTime, EndTime);
                    zSQL += String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_ReadPLCLog WHERE MessageType=2033 AND ReceivingNodeID = {0} AND Systemtime BETWEEN {1} AND {2} ORDER BY Systemtime DESC", nDeviceID, StartTime, EndTime);
                }

                else
                    zSQL = String.Format("SELECT SystemTime, SequenceNumber, ReceivingNodeID, Messagetype, FinishedTime, RawData FROM ASRS_WritePLCLog WHERE Messagetype = 2032 AND Systemtime BETWEEN {0} AND {1} ORDER BY SystemTime DESC", StartTime, EndTime);
            }

            sendSQL(zSQL);
        }

        // 如果 Mission_Result comboBox 選擇 complete，自動將 邊、層、格 歸0
        private void click_MissionResultCombo(object sender, EventArgs e)
        {
            int nIndex = MISSIONcomboBox.SelectedIndex;

            if (nIndex == 1)
            {
                SIDEcomboBox.SelectedIndex = 2;
                LEVELcomboBox.SelectedIndex = 0;
                POStextBox.Text = "0";
            }
        }

        // Pallet Monitor
        private void click_StartMonitor(object sender, EventArgs e)
        {
            // 初始啟動
            if (m_hThread == null)
            {
                StartMonitor();
                button2.Text = "暫停";
            }
            // 暫停
            else if (button2.Text == "暫停")
            {
                _pauseEventP.Reset();
                button2.Text = "啟動";
            }
            // 重啟
            else
            {
                _pauseEventP.Set();
                button2.Text = "暫停";
            }
        }

        // Stack Crane Monitor
        private void click_crane_monitor(object sender, EventArgs e)
        {
            int nSelectedItem = comboBox_SC.SelectedIndex;

            mSC_DLG[nSelectedItem] = new SC01_DLG(mDBset, nSelectedItem + 18);        // 加18至對應的吊車ID    

            mSC_DLG[nSelectedItem].Text = String.Format("吊車 {0} 號", nSelectedItem);
            mSC_DLG[nSelectedItem].m_SubMessageParseFUN = DisplayMessageToFormUI;
            mSC_DLG[nSelectedItem].Show();            
        }

        private void click_MissionMonitor(object sender, EventArgs e)
        {
            mSC_DLG[0] = new SC01_DLG(mDBset, 0);

            mSC_DLG[0].Text = "任務自動執行";
            mSC_DLG[0].m_SubMessageParseFUN = DisplayMessageToFormUI;
            mSC_DLG[0].Show();
        }
    }
}
