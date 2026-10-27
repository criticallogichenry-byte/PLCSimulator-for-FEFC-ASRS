using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Methods_FENC;
using ddmcOTIZ;
using PLCTools;
using System.Collections;

using System.Data.SqlClient;

namespace MessageCheck
{    
    public partial class Frm_2033P : Form
    {
        PLCdata_FENC mPLC;
        _2033P m2033P = new _2033P();
        DBconfiguration mDBset = new DBconfiguration();

        string[,] mErrCode; // 記錄資料表 Err_Code 所有錯誤定義

        int m_nType = Constants_GUAN_YING._GuanYin;   

        int nMissionID = 0;                     // only for LOG
        public string m_zMessageRAW = "";

        public Frm_2033P()
        {
            InitializeComponent();
        }

        public Frm_2033P(DBconfiguration DBset)
        {
            InitializeComponent();
            mDBset = DBset;
        }

        private void Frm_2033P_Load(object sender, EventArgs e)
        {                        
             for (int i=0;i<=Constants_GUAN_YING._MAX_LAYER;i++)
            {
                LEVELcomboBox.Items.Add(i);
            }   
                             
            ID_SRC.Text = "1";
            PR_MSG.Text = "1";

            MissionIDBox.Text = "0";
            BARCODEtextBox.Text = "0";
            POStextBox.Text = "1";
            MissionIDBox.Text = nMissionID.ToString();

            SAcomboBox.SelectedIndex = 0;
            checkBox_LARGE.Checked = true;

            PLCcombo.SelectedIndex = 0;            
            MissionTYPEcomboBox.SelectedIndex = 0;
            DEVICEcomboBox.SelectedIndex = 0;
            SIDEcomboBox.SelectedIndex = 0;
            LEVELcomboBox.SelectedIndex = 1;        // 起始為0
            ERRORcomboBox.SelectedIndex = -1;       // 錯誤內容欄位於執行後由資料表讀取後才會填入，因此這階段無法先指定位置。改由資料表讀取後才指定。
            MISSIONcomboBox.SelectedIndex = 0;
            comboBox_SUBPOS.SelectedIndex = 0;

            // 顯示DB登入至UI
            textBox_DBIPAddress.Text = mDBset.DBIP;
            textBox_DBUser.Text = mDBset.DBUSER;
            textBox_PW.Text = mDBset.DBPW;
            textBox_DBTable.Text = mDBset.DBTABLE;

            mPLC = new PLCdata_FENC(textBox_DBIPAddress.Text, textBox_DBUser.Text, textBox_PW.Text, textBox_DBTable.Text, false);     // real OTIZ connection       

            GetErrorCodeFromDB();       // 由資料表 ErrorCodeDelimit 載入所有定義Err的資料顯示於UI選項

        }
        // 
        private void GetErrorCodeFromDB()
        {
            string zErrorDes;
            string zSQL = String.Format("SELECT Err_Code, Err_Desc FROM ErrorCodeDelimit ORDER BY Err_Code");
            ArrayList dataROW = mPLC.ExecuteSELECT(zSQL);

            mErrCode = new string[dataROW.Count, 2];

            if (dataROW.Count > 0)
            {
                for (int i = 0; i < dataROW.Count; i++)
                {
                    string[] data = dataROW[i] as string[];

                    mErrCode[i,0] = data[0];
                    mErrCode[i,1] = data[1];

                    zErrorDes = String.Format("{0},{1}", mErrCode[i,0], mErrCode[i,1]);
                    ERRORcomboBox.Items.Add(zErrorDes);
                }
            }

            // 錯誤內容欄位於執行後由資料表讀取後才會填入，因此改在資料表讀取後才指定。
            ERRORcomboBox.SelectedIndex = 0;
        }

        private void PLCcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
             string szITEM = PLCcombo.GetItemText(PLCcombo.SelectedItem);

            switch (szITEM)
            {
                case "19":
                    SAcomboBox.SelectedIndex = 0;
                    break;
                case "20":
                    SAcomboBox.SelectedIndex = 1;
                    break;
                case "21":
                    SAcomboBox.SelectedIndex = 2;
                    break;
                case "22":
                    SAcomboBox.SelectedIndex = 3;
                    break;
                case "23":
                    SAcomboBox.SelectedIndex = 4;
                    break;
                case "24":
                    SAcomboBox.SelectedIndex = 5;
                    break;
                case "25":
                    SAcomboBox.SelectedIndex = 6;
                    break;
            }

            m_nType = Constants_GUAN_YING._GuanYin;                    
        }

        private void DeviceNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string szITEM = SAcomboBox.GetItemText(SAcomboBox.SelectedItem);

            switch (szITEM)
            {
                case "SA31":
                    PLCcombo.SelectedIndex = 0;
                    break;
                case "SA32":
                    PLCcombo.SelectedIndex = 1;
                    break;
                case "SA33":
                    PLCcombo.SelectedIndex = 2;
                    break;
                case "SA34":
                    PLCcombo.SelectedIndex = 3;
                    break;
                case "SA35":
                    PLCcombo.SelectedIndex = 4;
                    break;
                case "SA36":
                    PLCcombo.SelectedIndex = 5;
                    break;
                case "SA37":
                    PLCcombo.SelectedIndex = 6;
                    break;
            }
        }

        private string StringToHEXstring(string s)
        {
            string hexBCDstringOutput = null;
            char[] values = s.ToCharArray();

            foreach (char letter in values)
            {
                int va = Convert.ToInt32(letter);
                // 以HEX型式顯示字串才啟用
                hexBCDstringOutput += String.Format("{0:X}", va);
            }

            return hexBCDstringOutput;
        }

        private void CollectAllUIdata()
        {
            string szITEM = null;

            m2033P.header.ID_PLC = Convert.ToInt16(PLCcombo.GetItemText(PLCcombo.SelectedItem));

            szITEM = SAcomboBox.GetItemText(SAcomboBox.SelectedItem);
            if (szITEM == "SA31")
            {                
                m2033P.DEVICE_NR = 3431;
            }
            else if (szITEM == "SA32")
            {                
                m2033P.DEVICE_NR = 3432;
            }
            else if (szITEM == "SA33")
            {                
                m2033P.DEVICE_NR = 3433;
            }
            else if (szITEM == "SA34")
            {                
                m2033P.DEVICE_NR = 3434;
            }
            else if (szITEM == "SA35")
            {                
                m2033P.DEVICE_NR = 3435;
            }
            else if (szITEM == "SA36")
            {                
                m2033P.DEVICE_NR = 3436;
            }
            else if (szITEM == "SA37")
            {                
                m2033P.DEVICE_NR = 3437;
            }            

            m2033P.header.ID_SRC = 1;
            m2033P.header.ID_MSG = 2033;
            m2033P.header.MSG_LEN = Convert.ToInt16(MSG_LEN.Text);
            m2033P.header.PR_MSG = Convert.ToInt16(PR_MSG.Text);

            // MISSION_TYPE
            switch (Convert.ToInt16(MissionTYPEcomboBox.SelectedIndex) + 1)
            {
                case 1:             // LOAD
                    m2033P.MISSION_TYPE = 1;
                    break;
                case 2:             // UNLOAD
                    m2033P.MISSION_TYPE = 2;
                    break;
                case 3:             // MOVE
                    m2033P.MISSION_TYPE = 3;
                    break;
                case 4:             // LOAD-UNLOAD
                    m2033P.MISSION_TYPE = 4;
                    break;
            }

            // TRACK_ID
            //m2013P.TRACK_ID = Convert.ToInt32(TrackIDBox.Text);

            // DEVICE
            switch (Convert.ToInt16(DEVICEcomboBox.SelectedIndex) + 1)
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
            m2033P.TRACK_ID = Convert.ToInt32(textBox_TrackID.Text);

            // TYPE_PALLET
            //m2033P.TYPE_PALLET = Convert.ToInt32(TYPE_PALLETtextBox.Text);
            if (checkBox_LARGE.Checked)
                m2033P.TYPE_PALLET = 0;
            else
                m2033P.TYPE_PALLET = 1;

            // ERROR_CODE
            // m2033P.ERROR_CODE = Convert.ToInt32(ERRORcomboBox.SelectedIndex) + 1;      // data from 1
            // ERROR_CODE
            // 資料表讀取所有的錯誤內容將前面數字截取做為錯誤代碼填入交訊中
            string zSelectedItem = ERRORcomboBox.GetItemText(ERRORcomboBox.SelectedItem);
            string[] zItemCol = zSelectedItem.Split(',');
            m2033P.ERROR_CODE = Convert.ToInt32(zItemCol[0]);

            // MISSION_RESULT
            m2033P.MISSION_RESULT = Convert.ToInt32(MISSIONcomboBox.SelectedIndex);    // data from 0
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CollectAllUIdata();
     
            m_zMessageRAW = mPLC.messageP(2033, m2033P, checkBox_WriteToDB.Checked);
            m2033P = mPLC.P2033Parser(m_zMessageRAW);

            MessageBox.Show("寫入RAW : " + m_zMessageRAW, "2013P 資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(m_zMessageRAW);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
/*
            CollectAllUIdata();

            //mPLC.P2013(2013, m2013P);
            if (m_nType != PhaseType._ASRS)
                m_zMessageRAW = mPLC.messageP(2013, m2013P, checkBox_WriteToDB.Checked);            
            else
                m_zMessageRAW = mPLC.messageP(2113, m2113P, checkBox_WriteToDB.Checked);

            MessageBox.Show("寫入RAW : " + m_zMessageRAW, "2013P 資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(m_zMessageRAW);  
 */
        }

// 若 MissionType 為 LOAD, Mission Result 為 Completed，位置欄位都清為0。
        private void click_MittionTYPE(object sender, EventArgs e)
        {
            if (Convert.ToInt32(MISSIONcomboBox.SelectedIndex) == 1)        // completed
            {
                SIDEcomboBox.SelectedIndex = 2;
                LEVELcomboBox.SelectedIndex = 0;
                POStextBox.Text = "0";
            }
        }

        private void click_MissionRESULT(object sender, EventArgs e)
        {
            if (Convert.ToInt32(MissionTYPEcomboBox.SelectedIndex)==0)      // load
            {
                SIDEcomboBox.SelectedIndex = 2;
                LEVELcomboBox.SelectedIndex = 0;
                POStextBox.Text = "0";
            }
        }
        // 若 MissionType 為 LOAD, Mission Result 為 Completed，位置欄位都清為0。
    }
}
