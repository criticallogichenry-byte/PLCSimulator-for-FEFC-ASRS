using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using ddmcOTIZ;
using Methods_FENC;
using INI;
using MessageCheck;

namespace PLCTools
{    
    public partial class Form1 : Form
    {
        _1121P m1121P = new _1121P();
        _1122V m1122data = new _1122V();
        _2032V m2032data = new _2032V();
        _2033P m2033P = new _2033P();
        Object mObject;     // dummy when used in btn_parse_Click() 

        private int[] nCommandList;
        string[] m_szDisplay;       // for meaning display
        string m_szResult;

        PLCdata_FENC mPLC;            // Form1 這裡沒用到資料庫，因此只使用不連線，且一個 mPLC 做交訊解析就可。      

        Frm_1121P _1121DLG;
        Frm_1122V _1122DLG;
        Frm_2032V _2032DLG;
        Frm_2033P _2033DLG;
        Frm_Monitor _MonitorDLG;

        ddmcINI mINI;
        public DBconfiguration mDBset;
        public Methods_FENC.DBconfiguration mDBset2;

        string[] zSGID_def = { "NONE", "棧板無法辨試", "目的站錯誤", "料別與序號不符", "高度與料別檢知錯誤", "3111→3112 棧板SIZE CHECK ERR", "3015→3111 棧板SIZE CHECK ERR", "BAR CODE WAITING ERROR", "為DTY小包裝棧板，確認(大庫格)",
                               "為POY小包裝棧板，確認(小庫格)", "為DTY 大包裝棧板 4 LAYER ", "為DTY 大包裝棧板 3 LAYER", "為DTY 大包裝棧板 3 LAYER(小庫格)" };

        private string zSGID(int nID)
        {
            string zMessage = "";

            zMessage = String.Format("原始值 {0} - {1}", nID, zSGID_def[nID]);

            return zMessage;
        }

        public Form1()
        {
            InitializeComponent();

            nCommandList = new int[Constants_GUAN_YING._MAX_COMMAND_CNT];
            mPLC = new PLCdata_FENC();        // Form1 不連線資料庫。
        }

        private void TabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {
            TabControl objTab = (TabControl)sender;
            int nSelected = 0;

            switch (objTab.SelectedTab.Text)
            {
                case "OP01":
                    nSelected = 0;
                    break;
            }
        }

        private bool tabControlCheckHave(System.Windows.Forms.TabControl tab, String tabName)
        {
            for (int i = 0; i < tab.TabCount; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void Add_TabPage(string str, Form myForm)
        {
            if (tabControlCheckHave(this.tabControl1, str)) { return; }
            else
            {
                tabControl1.TabPages.Add(str);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                myForm.FormBorderStyle = FormBorderStyle.None;
                myForm.TopLevel = false;
                myForm.Show();
                myForm.Parent = tabControl1.SelectedTab;
                //tabControl1.SelectedTab.AutoScroll = true;
                tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_szDisplay = new string[10];

            // get INI configuration
            String sFilename = "System.ini";
            String sLocation = Path.GetFullPath(sFilename);//讀出 system.ini的位置
            mINI = new ddmcINI(sLocation);
            mDBset = new DBconfiguration();
            mDBset2 = new Methods_FENC.DBconfiguration();

            // 設定 三期資料庫
            mDBset2.DBIP = mDBset.DBIP = mINI.IniReadValue("DATABASE", "IP");
            mDBset2.DBUSER = mDBset.DBUSER = mINI.IniReadValue("DATABASE", "USER");
            mDBset2.DBPW = mDBset.DBPW = mINI.IniReadValue("DATABASE", "PW");
            mDBset2.DBTABLE = mDBset.DBTABLE = mINI.IniReadValue("DATABASE", "DB");

            _2032DLG = new Frm_2032V(mDBset);
            _2033DLG = new Frm_2033P(mDBset);
            _1121DLG = new Frm_1121P(mDBset);
            _1122DLG = new Frm_1122V(mDBset);
            _MonitorDLG = new Frm_Monitor(mDBset2);

            // 載入 TAB 
            Add_TabPage("2032V", _2032DLG);
            Add_TabPage("2033P", _2033DLG);
            Add_TabPage("1122V", _1122DLG);
            Add_TabPage("1121P", _1121DLG);            

            // 預設第一個TAB
            tabControl1.SelectedIndex = 0;

            // 交訊解析callbakck函式指定給 Frm_Monitor 物件。直接由此物件直接解析
            _MonitorDLG.m_MessageParseFUN = MessageParse;               // 完整解析
            _MonitorDLG.m_MessageParseROUGH = MessageParseForRough;     // 簡單解析
        }

        // 用於吊車解析簡單內容
        public string MessageParseForRough(string zRAW)
        {
            string zTemp = string.Empty;
            string zResult = string.Empty;
            int nType = mPLC.DispatchRAW(zRAW);            

            switch (nType)
            {
                case 2032:
                    mPLC.V2032(ref m2032data);

                    zResult = String.Format("命令 : {0} 序號 : {1}, TrackID : {2} ", m2032data.header.ID_MSG, m2032data.header.PR_MSG, m2032data.TRACK_ID);

                    // 任務型態
                    if (m2032data.MISSION_TYPE == 1)
                        zTemp = " LOAD ";
                    else if (m2032data.MISSION_TYPE == 2)
                        zTemp = " UNLOAD ";
                    else if (m2032data.MISSION_TYPE == 3)
                        zTemp = " MOVE ";
                    else if (m2032data.MISSION_TYPE == 4)
                        zTemp = " LOAD-UNLOAD ";
                    else
                        zTemp = " 未定義 ";

                    zResult += String.Format(" - 任務 : {0} ", zTemp);

// ---------------------------------------- 來源端
                    zTemp = "";                    
                    if (m2032data.SRC_DEVICE == 1)
                    {
                        zTemp = "起點 倉庫 ";

                        // 哪一側
                        if (m2032data.SRC_SIDE == 1)
                            zTemp += " 左側 ";
                        else if (m2032data.SRC_SIDE == 2)
                            zTemp += " 右側 ";
                        else
                            zTemp += " SRC_SIDE 未定義 ";

                        // 第幾層
                        if (m2032data.SRC_LEVEL > 0 && m2032data.SRC_LEVEL <= 18)
                            zTemp += String.Format(" 第 {0} 層 ", m2032data.SRC_LEVEL);
                        else
                            zTemp += String.Format(" 層數 {0} 異常 ", m2032data.SRC_LEVEL);

                        // 哪一庫格
                        if (m2032data.SRC_POSITION > 0 && m2032data.SRC_POSITION <= 60)
                            zTemp += String.Format(" {0}格 ", m2032data.SRC_POSITION);
                        else
                            zTemp += String.Format(" 格數 {0} 異常 ", m2032data.SRC_POSITION);
                    }
                    else if (m2032data.SRC_DEVICE == 2)
                        zTemp = " 起點 碼頭 ";
                    else if (m2032data.SRC_DEVICE == 3)
                        zTemp = " 起點 餵入 ";
                    else
                        zTemp = " 起點 未定義 ";
                    zResult += zTemp;

// ----------------------------------------- 目的端
                    zTemp = "";
                    if (m2032data.DST_DEVICE == 1)
                    {
                        zTemp = "終點 倉庫";

                        // 哪一側
                        if (m2032data.DST_SIDE == 1)
                            zTemp += " 左側 ";
                        else if (m2032data.DST_SIDE == 2)
                            zTemp += " 右側 ";
                        else
                            zTemp += " SRC_SIDE 未定義 ";

                        // 第幾層
                        if (m2032data.DST_LEVEL > 0 && m2032data.DST_LEVEL <= 18)
                            zTemp += String.Format(" 第 {0} 層 ", m2032data.DST_LEVEL);
                        else
                            zTemp += String.Format(" 層數 {0} 異常 ", m2032data.DST_LEVEL);

                        // 哪一庫格
                        if (m2032data.DST_POSITION > 0 && m2032data.DST_POSITION <= 60)
                            zTemp += String.Format(" {0}格 ", m2032data.DST_POSITION);
                        else
                            zTemp += String.Format(" 格數 {0} 異常 ", m2032data.DST_POSITION);
                    }
                    else if (m2032data.DST_DEVICE == 2)
                        zTemp += " 終點 碼頭";
                    else if (m2032data.DST_DEVICE == 3)
                        zTemp += " 終點 餵入";
                    zResult += zTemp;// + "\r\n";
                    
                    break;

                case 2033:
                    mPLC.P2033(ref m2033P);

                    zResult = String.Format("通知 : {0} 序號 : {1}, TrackID : {2} ", m2033P.header.ID_MSG, m2033P.header.PR_MSG, m2033P.TRACK_ID);

                    // 任務型態
                    if (m2033P.MISSION_TYPE == 1)
                        zTemp = " LOAD ";
                    else if (m2033P.MISSION_TYPE == 2)
                        zTemp = " UNLOAD ";
                    else if (m2033P.MISSION_TYPE == 3)
                        zTemp = " MOVE ";
                    else if (m2033P.MISSION_TYPE == 4)
                        zTemp = " LOAD-UNLOAD ";
                    else
                        zTemp = " 未定義 ";
                    zResult += String.Format(" - 任務 : {0} ", zTemp);

 // ---------------------------------------- 位置端 START
                    zTemp = "";
                    if (m2033P.DEVICE == 1)
                    {
                        zTemp = "起點 倉庫 ";

                        // 哪一側
                        if (m2033P.SIDE == 1)
                            zTemp += " 左側 ";
                        else if (m2033P.SIDE == 2)
                            zTemp += " 右側 ";
                        else
                            zTemp += " SIDE 未定義 ";

                        // 第幾層
                        if (m2033P.LEVEL > 0 && m2033P.LEVEL <= 18)
                            zTemp += String.Format(" 第 {0} 層 ", m2033P.LEVEL);
                        else
                            zTemp += String.Format(" 層數 {0} 異常 ", m2033P.LEVEL);

                        // 哪一庫格
                        if (m2033P.POSITION > 0 && m2033P.POSITION <= 60)
                            zTemp += String.Format(" {0}格 ", m2033P.POSITION);
                        else
                            zTemp += String.Format(" 格數 {0} 異常 ", m2033P.POSITION);
                    }
                    else if (m2033P.DEVICE == 2)
                        zTemp += " 位置 碼頭 ";
                    else if (m2033P.DEVICE == 3)
                        zTemp += " 位置 餵入 ";
                    else
                        zTemp += " 位置 未定義 ";
                    // ---------------------------------------- 位置端 END

                    if (m2033P.MISSION_RESULT == 0)
                        zTemp += " 狀態 : WORKING ";
                    else if (m2033P.MISSION_RESULT == 1)
                        zTemp += " 狀態 : COMPLETE ";
                    else if (m2033P.MISSION_RESULT == 2)
                        zTemp += " 狀態 : ABORTED ";
                    else
                        zTemp += String.Format(" 狀態 : {0}未定義 ", m2033P.MISSION_RESULT);

                    string zErr = SC01_DLG.GetErrorDesc(m2033P.MISSION_RESULT);
                    if (m2033P.ERROR_CODE == 1)
                        zTemp += String.Format(" 正常 : {0}", zErr);
                    else
                        zTemp += String.Format(" ERROR_CODE {0} : {1}", m2033P.ERROR_CODE, zErr);

                    zResult += zTemp;                   

                    break;
            }

            return zResult;
        }

        // 用於解析完整交訊內容
        public int MessageParse(string zRAW, ref string m_szResult, ref object Message)
        {
            string zParam1 = string.Empty;            
            string zParam2 = "";            

            int nType = mPLC.DispatchRAW(zRAW);

            if (nType > 0)
            {
                switch (nType)
                {
                    case 1121:
                        mPLC.P1121(ref m1121P);

                        if (m1121P.STATUS == 1)
                            zParam1 = "Pallet Arrived at " + m1121P.STATION_NR.ToString();
                        else if (m1121P.STATUS == 99)
                            zParam1 = "Pallet Left From Station " + m1121P.STATION_NR.ToString();
                        else
                            zParam1 = "Not Defined";

                        m_szResult = String.Format("箱號:[{0}], TrackID[{1}], {2}", m1121P.BARCODE, m1121P.TRACK_ID, zParam1);
                        m_szResult += "\r\n"
                                    + "SGID1 : " + zSGID(m1121P.SG_ID1) + "\r\n"
                                    + "SGID2 : " + zSGID(m1121P.SG_ID2) + "\r\n"
                                    + "SGID3 : " + zSGID(m1121P.SG_ID3) + "\r\n"
                                    + "SGID4 : " + zSGID(m1121P.SG_ID4) + "\r\n"
                                    + "SGID5 : " + zSGID(m1121P.SG_ID5);

                        // 或使用 P1121Parser()解析也行。
                        Message = mPLC.P1121Parser(zRAW);

                        break;

                    case 1122:
                        mPLC.V1122(ref m1122data);

                        string zCommand = "";
                        if (m1122data.COMMAND == 5)
                            zCommand = "CLEAR_TrackID";
                        else
                            zCommand = m1122data.COMMAND.ToString();

                        m_szResult = String.Format("Command[{3}] From [{0}] to Station[{1}] with TrackID[{2}]", m1122data.STATION_NR, m1122data.DESTINATION_STATION_NR, m1122data.TRACK_ID, zCommand);

                        break;

                    case 2032:
                        mPLC.V2032(ref m2032data);

                        switch (m2032data.MISSION_TYPE)
                        {
                            case 1:
                                m_szDisplay[0] = "LOAD";
                                break;
                            case 2:
                                m_szDisplay[0] = "UNLOAD";
                                break;
                            case 3:
                                m_szDisplay[0] = "MOVE";
                                break;
                            case 4:
                                m_szDisplay[0] = "LOAD-UNLOAD";
                                break;
                        }

                        switch (m2032data.SRC_DEVICE)
                        {
                            case 1:
                                m_szDisplay[1] = "Storage";

                                if (m2032data.SRC_SIDE == 1)
                                    m_szDisplay[2] = "LEFT";
                                else if (m2032data.SRC_SIDE == 2)
                                    m_szDisplay[2] = "RIGHT";

                                break;
                            case 2:
                                m_szDisplay[1] = "Bay";

                                m_szDisplay[2] = "0";
                                break;
                            case 3:
                                m_szDisplay[1] = "Feedback/Pickout";
                                break;
                            default:
                                m_szDisplay[1] = "NONE";
                                m_szDisplay[2] = "NONE";
                                break;
                        }

                        switch (m2032data.DST_DEVICE)
                        {
                            case 1:
                                m_szDisplay[3] = "Storage";

                                if (m2032data.DST_SIDE == 1)
                                    m_szDisplay[4] = "LEFT";
                                else if (m2032data.DST_SIDE == 2)
                                    m_szDisplay[4] = "RIGHT";

                                break;
                            case 2:
                                m_szDisplay[3] = "Bay";

                                m_szDisplay[4] = "0";
                                break;
                            case 3:
                                m_szDisplay[3] = "Feedback/Pickout";
                                break;
                            default:
                                m_szDisplay[3] = "NONE";
                                m_szDisplay[4] = "NONE";
                                break;
                        }

                        m_szResult = "------ [HEADER] ------" + "\r\n"
                                   + "MSG_LEN : " + m2032data.header.MSG_LEN + "\r\n"
                                   + "ID_PLC  : " + m2032data.header.ID_PLC + "\r\n"
                                   + "IS_SRC  : " + m2032data.header.ID_SRC + "\r\n"
                                   + "------ [DATA] ------" + "\r\n"
                                   + "DEVICE_NR    : " + m2032data.DEVICE_NR + "\r\n"
                                   + "MISSION_TYPE : " + m_szDisplay[0] + "\r\n"
                                   + "SRC_DEVICE   : " + m_szDisplay[1] + "\r\n"
                                   + "SRC_SIDE     : " + m_szDisplay[2] + "\r\n"
                                   + "SRC_LEVEL    : " + m2032data.SRC_LEVEL + "\r\n"
                                   + "SRC_POSITION : " + m2032data.SRC_POSITION + "\r\n"
                                   + "DST_DEVICE   : " + m_szDisplay[3] + "\r\n"
                                   + "DST_SIDE     : " + m_szDisplay[4] + "\r\n"
                                   + "DST_LEVEL    : " + m2032data.DST_LEVEL + "\r\n"
                                   + "DST_POSITION : " + m2032data.DST_POSITION + "\r\n"
                                   + "TRACK_ID     : " + m2032data.TRACK_ID + "\r\n"
                                   + "TYPE_PALLET  : " + m2032data.TYPE_PALLET + "\r\n";
                        break;

                    case 2033:
                        mPLC.P2033(ref m2033P);                        

                        switch (m2033P.MISSION_TYPE)
                        {
                            case 1:
                                m_szDisplay[0] = "LOAD";
                                m_szDisplay[1] = "高架吊車上";       // 若狀態為 WORKING 或 LOAD，表示物品在吊車自己身上。
                                break;
                            case 2:
                                m_szDisplay[0] = "UNLOAD";
                                break;
                            case 3:
                                m_szDisplay[0] = "MOVE";
                                break;
                            case 4:
                                m_szDisplay[0] = "LOAD-UNLOAD";
                                break;
                        }

                        switch (m2033P.DEVICE)
                        {
                            case 1:
                                m_szDisplay[1] = "STORAGE";

                                if (m2033P.SIDE == 1)
                                    m_szDisplay[2] = "LEFT";
                                else if (m2033P.SIDE == 2)
                                    m_szDisplay[2] = "RIGHT";
                                else
                                    m_szDisplay[2] = "ERROR";

                                break;
                            case 2:
                                m_szDisplay[1] = "BAY";

                                m_szDisplay[2] = "0";
                                break;
                            case 3:
                                m_szDisplay[1] = "Feedback/Pickout";
                                break;
                        }

                        if (m2033P.ERROR_CODE == 1)
                            m_szDisplay[3] = "OK";
                        else
                            m_szDisplay[3] = _MonitorDLG.GetErrorDesc(m2033P.DEVICE_NR, m2033P.ERROR_CODE);                

                        switch (m2033P.MISSION_RESULT)
                        {
                            case 0:
                                m_szDisplay[4] = "WORKING";

                                m_szDisplay[1] = "高架吊車上";       // 若狀態為working，表示物品在吊車自己身上。
                                break;
                            case 1:
                                m_szDisplay[4] = "COMPLETED";
                                break;
                            case 2:
                                m_szDisplay[4] = "ABORTED";
                                break;
                        }

                        m_szResult = "------ [HEADER] ------" + "\r\n"
                                   + "MSG_LEN : " + m2033P.header.MSG_LEN + "\r\n"
                                   + "ID_PLC  : " + m2033P.header.ID_PLC + "\r\n"
                                   + "IS_SRC  : " + m2033P.header.ID_SRC + "\r\n"
                                   + "------ [DATA] ------" + "\r\n"
                                   + "DEVICE_NR : " + m2033P.DEVICE_NR + "\r\n"
                                   + "MISSION_TYPE : " + m_szDisplay[0] + "\r\n"
                                   + "DEVICE : " + m_szDisplay[1] + "\r\n"
                                   + "SIDE : " + m_szDisplay[2] + "\r\n"
                                   + "LEVEL : " + m2033P.LEVEL + "\r\n"
                                   + "POS : " + m2033P.POSITION + "\r\n"
                                   + "TYPE_PALLET : " + m2033P.TYPE_PALLET + "\r\n"
                                   + "TRACK_ID    : " + m2033P.TRACK_ID + "\r\n"
                                   + "ERROR_CODE : " + m_szDisplay[3] + "\r\n"
                                   + "MISSION_RESULT : " + m_szDisplay[4];

                        // 第二種方式
                        m2033P = mPLC.P2033Parser(zRAW);
                        break;

                }               
            }

            switch (nType)
            {
                case 1121:
                    Message = m1121P;
                    break;
                case 1122:
                    Message = m1122data;
                    break;
                case 2032:
                    Message = m2032data;
                    break;
                case 2033:
                    Message = m2033P;
                    break;
            }

            return nType;
        }

        private void btn_parse_Click(object sender, EventArgs e)
        {
            int nType = 0;
            string zRAW = textBox_RAW.Text;
            string[] zCaseID = new string[5];

            if (zRAW == string.Empty) 
            {
                //_MonitorDLG.ShowDialog(this);
                _MonitorDLG.Show(this);
            }
            else
            {
                 nType = MessageParse(zRAW, ref m_szResult, ref mObject);

                if (m_szResult == string.Empty)
                    m_szResult = "交訊內容未定義";
                else
                {
                    if (nType == 1121)
                    {
                        zCaseID = m_szResult.Split(',');
                        tabControl1.SelectedIndex = 3;                  // 切換至1121P TAB
                        _1121DLG.SetMessageData((_1121P)mObject);
                    }
                }

                MessageBox.Show(m_szResult, "觀音自動倉 " + nType.ToString());
            }            
        }
    }
}
