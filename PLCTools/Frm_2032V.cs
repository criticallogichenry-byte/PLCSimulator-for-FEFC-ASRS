using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Methods_FENC;     // 使用觀音自動倉
using ddmcOTIZ;
using PLCTools;

namespace MessageCheck
{
    public partial class Frm_2032V : Form
    {
        PLCdata_FENC mPLC;
        _2032V m2032V = new _2032V();
        DBconfiguration mDBset = new DBconfiguration();

        string []zStationBUF = { "STORAGE", "BAY", "FEEDBACK" }; 

        int nMissionID = 0;                     // only for LOG

        public string m_zMessageRAW = "";
        int m_nType = Constants_GUAN_YING._GuanYin;

        public Frm_2032V()
        {
            InitializeComponent();
        }

        public Frm_2032V(DBconfiguration DBset)
        {
            InitializeComponent();
            mDBset = DBset;
        }

        private void Frm_2032V_Load(object sender, EventArgs e)
        {                        
            ID_SRC.Text = "1";

            SAcomboBox.SelectedIndex = 0;

            MissionIDBox.Text = "0";
            BARCODEtextBox.Text = "0";
            textBox_POS_SRC.Text = "1";
            MissionIDBox.Text = nMissionID.ToString();

            PLCcombo.SelectedIndex = 0;
            comboBox_DEVICE_SRC.SelectedIndex = 0;
            comboBox_DEVICE_DST.SelectedIndex = 0;
            MissionTYPEcomboBox.SelectedIndex = 0;
            DEVICEcomboBox.SelectedIndex = 0;
            comboBox_SIDE_SRC.SelectedIndex = 0;
            comboBox_LEVEL_SRC.SelectedIndex = 0;

            checkBox_LARGE.Checked = true;

            // 顯示DB登入至UI
            textBox_DBIPAddress.Text = mDBset.DBIP;
            textBox_DBUser.Text = mDBset.DBUSER;
            textBox_PW.Text = mDBset.DBPW;
            textBox_DBTable.Text = mDBset.DBTABLE;            
        }

        // TRUE  : 顯示所有站點
        // FALSE : 不顯示 FeedBack 站點
        private void Set_DeviceDST_item(bool bSpecial=true)
        {
            comboBox_DEVICE_DST.Items.Clear();

            if (bSpecial)
            {
                for (int i = 0; i < zStationBUF.Count(); i++)
                {
                    comboBox_DEVICE_DST.Items.Add(zStationBUF[i]);
                }
            }
            else
            {
                for (int i=0;i<zStationBUF.Count()-1; i++)
                {
                    comboBox_DEVICE_DST.Items.Add(zStationBUF[i]);
                }
            }
        }

        private void PLCcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string szITEM = PLCcombo.GetItemText(PLCcombo.SelectedItem);

            switch(szITEM)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string szITEM = null;
            // clear to NULL
            m2032V.SRC_DEVICE = m2032V.SRC_LEVEL = m2032V.SRC_POSITION = m2032V.SRC_SIDE = 0;
            m2032V.DST_DEVICE = m2032V.DST_LEVEL = m2032V.DST_POSITION = m2032V.DST_SIDE = 0;

            m2032V.header.ID_PLC = Convert.ToInt16(PLCcombo.GetItemText(PLCcombo.SelectedItem));

            szITEM = SAcomboBox.GetItemText(SAcomboBox.SelectedItem);
            if (szITEM == "SA31")
            {
                m2032V.DEVICE_NR = 3431;
            }
            else if (szITEM == "SA32")
            {
                m2032V.DEVICE_NR = 3432;
            }
            else if (szITEM == "SA33")
            {
                m2032V.DEVICE_NR = 3433;
            }
            else if (szITEM == "SA34")
            {
                m2032V.DEVICE_NR = 3434;
            }
            else if (szITEM == "SA35")
            {
                m2032V.DEVICE_NR = 3435;
            }
            else if (szITEM == "SA36")
            {
                m2032V.DEVICE_NR = 3436;
            }
            else if (szITEM == "SA37")
            {
                m2032V.DEVICE_NR = 3437;
            }

            mPLC = new PLCdata_FENC(textBox_DBIPAddress.Text, textBox_DBUser.Text, textBox_PW.Text, textBox_DBTable.Text, false);     // real OTIZ connection            

            m2032V.header.ID_SRC = 1;
            m2032V.header.ID_MSG = 2032;

            m2032V.header.MSG_LEN = Convert.ToInt16(MSG_LEN.Text);
            m2032V.header.PR_MSG = Convert.ToInt32(PR_MSG.Text);           //由資料庫產生，不外加處理 Convert.ToInt16(PR_MSG.Text);

            //m2032V.SUB_POSITION = 0;

            // MISSION_TYPE
            switch (Convert.ToInt16(MissionTYPEcomboBox.SelectedIndex) + 1)
            {
                case 1:             // LOAD
                    m2032V.MISSION_TYPE = 1;
                    break;
                case 2:             // UNLOAD
                    m2032V.MISSION_TYPE = 2;
                    break;
                case 3:             // MOVE
                    m2032V.MISSION_TYPE = 3;
                    break;
                case 4:             // LOAD-UNLOAD
                    m2032V.MISSION_TYPE = 4;
                    break;
            }

            // TRACK_ID
            //m2012V.TRACK_ID = Convert.ToInt32(TrackIDBox.Text);
            
            // LOAD 與 LOAD-UNLOAD 才可選擇SRC
            if (m2032V.MISSION_TYPE == 4 || m2032V.MISSION_TYPE == 1)
            {
                //SRC DEVICE
                switch (Convert.ToInt16(comboBox_DEVICE_SRC.SelectedIndex) + 1)
                {
                    case 1:             // STORAGE
                        m2032V.SRC_DEVICE = 1;
                        break;
                    case 2:             // LOAD/UNLOADING BAY
                        m2032V.SRC_DEVICE = 2;
                        break;
                    case 3:             // FEEDBACK/PICKOUT
                        m2032V.SRC_DEVICE = 3;
                        break;
                }

                // SRC_SIDE
                switch (Convert.ToInt16(comboBox_SIDE_SRC.SelectedIndex) + 1)
                {
                    case 1:             // LEFT
                        m2032V.SRC_SIDE = 1;
                        break;
                    case 2:             // RIGHT
                        m2032V.SRC_SIDE = 2;
                        break;
                    case 3:             // NONE if Bay is selected
                        m2032V.SRC_SIDE = 0;
                        break;
                }


                // if DEVICE is FEEDBACK, LEVEL,POS,SIDE should be 0
                if (m2032V.SRC_DEVICE == 3)
                {
                    //m2012V.SIDE = 0;
                    m2032V.SRC_LEVEL = 0;
                    m2032V.SRC_POSITION = 0;
                }
                else
                {
                    // LEVEL
                    //m2012V.LEVEL = Convert.ToInt16(LEVELcomboBox.SelectedIndex) + 1;
                    string zLEVEL = comboBox_LEVEL_SRC.GetItemText(comboBox_LEVEL_SRC.SelectedItem);
                    m2032V.SRC_LEVEL = Convert.ToInt16(zLEVEL);
                    // 因為是以 index 為設定值，不是以內部值為參考。當選擇的 index 是內部內容為 0 的 index 9, 一律視為 0
                    if (m2032V.SRC_LEVEL >= 19)
                        m2032V.SRC_LEVEL = 0;
                    // POS            
                    m2032V.SRC_POSITION = Convert.ToInt16(textBox_POS_SRC.Text);
                }
            }
            else
            {
                m2032V.SRC_DEVICE = 0;
                m2032V.SRC_LEVEL = 0;
                m2032V.SRC_SIDE = 0;
                m2032V.SRC_POSITION = 0;
            }

            if (m2032V.MISSION_TYPE == 2 || m2032V.MISSION_TYPE == 4)
            {
                //SRC DEVICE
                switch (Convert.ToInt16(comboBox_DEVICE_DST.SelectedIndex) + 1)
                {
                    case 1:             // STORAGE
                        m2032V.DST_DEVICE = 1;
                        break;
                    case 2:             // LOAD/UNLOADING BAY
                        m2032V.DST_DEVICE = 2;
                        break;
                    case 3:             // FEEDBACK/PICKOUT
                        m2032V.DST_DEVICE = 3;
                        break;
                }

                // DST_SIDE
                switch (Convert.ToInt16(comboBox_SIDE_DST.SelectedIndex) + 1)
                {
                    case 1:             // LEFT
                        m2032V.DST_SIDE = 1;
                        break;
                    case 2:             // RIGHT
                        m2032V.DST_SIDE = 2;
                        break;
                    case 3:
                        m2032V.DST_SIDE = 0;    // NONE, if Bay is selected
                        break;
                }


                // if DEVICE is FEEDBACK, LEVEL,POS,SIDE should be 0
                if (m2032V.DST_DEVICE == 3)
                {
                    //m2012V.SIDE = 0;
                    m2032V.DST_LEVEL = 0;
                    m2032V.DST_POSITION = 0;
                }
                else
                {
                    // LEVEL
                    //m2012V.LEVEL = Convert.ToInt16(LEVELcomboBox.SelectedIndex) + 1;
                    string zLEVEL = comboBox_LEVEL_SRC.GetItemText(comboBox_LEVEL_DST.SelectedItem);
                    m2032V.DST_LEVEL = Convert.ToInt16(zLEVEL);
                    // 因為是以 index 為設定值，不是以內部值為參考。當選擇的 index 是內部內容為 0 的 index 9, 一律視為 0
                    if (m2032V.DST_LEVEL >= 19)
                        m2032V.DST_LEVEL = 0;
                    // POS            
                    m2032V.DST_POSITION = Convert.ToInt16(textBox_POS_DST.Text);
                }
            }

            // TYPE_PALLET
            //m2032V.TYPE_PALLET = Convert.ToInt32(TYPE_PALLETtextBox.Text);
            if (checkBox_LARGE.Checked)
                m2032V.TYPE_PALLET = 0;
            else
                m2032V.TYPE_PALLET = 1;

            // TRACK_ID
            if (textBox_TrackID.Text != "")
                m2032V.TRACK_ID = Convert.ToInt32(textBox_TrackID.Text);
            else
                m2032V.TRACK_ID = 0;

            // BARCODE
            //m2012V.BARCODE = Convert.ToInt32(BARCODEtextBox.Text);

            //int nSerialNO = mPLC.V2012(m2012V.header.ID_PLC, m2012V.header.ID_SRC, m2012V);
            int nSerial = m2032V.header.PR_MSG;
            // 於ASRS立庫，命令為2112。因此改用變數帶入。
            string zRAW = mPLC.messageV(m2032V.header.ID_MSG, m2032V.header.ID_PLC, m2032V.header.ID_SRC, m2032V, nSerial, checkBox_WriteToDB.Checked);

            MessageBox.Show("產生RAW : " + zRAW,"2032V 命令",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Clipboard.SetText(zRAW);

            textBox_Display_RAW.Text = zRAW;
//            DialogResult = DialogResult.OK;
//            return;
        }

// ******************************* SA至RH進行料架的 Load or Unload 時，若 mission 為 LOAD，則 POS 為 2，UNLOAD 則為 1 ************************
        private void MissionTYPEcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 預設來源-目的地全啟用
            comboBox_DEVICE_SRC.Enabled = true;
            comboBox_LEVEL_SRC.Enabled = true;
            comboBox_SIDE_SRC.Enabled = true;
            textBox_POS_SRC.Enabled = true;

            comboBox_DEVICE_DST.Enabled = true;
            comboBox_LEVEL_DST.Enabled = true;
            comboBox_SIDE_DST.Enabled = true;
            textBox_POS_DST.Enabled = true;

            string zMissionType = ((ComboBox)sender).GetItemText(((ComboBox)sender).SelectedItem);

            if (zMissionType == "LOAD")                       
            {
                comboBox_DEVICE_DST.Enabled = false;
                comboBox_LEVEL_DST.Enabled = false;
                comboBox_SIDE_DST.Enabled = false;
                textBox_POS_DST.Enabled = false;           
            }
            else if (zMissionType == "UNLOAD")
            {
                comboBox_DEVICE_SRC.Enabled = false;
                comboBox_LEVEL_SRC.Enabled = false;
                comboBox_SIDE_SRC.Enabled = false;
                textBox_POS_SRC.Enabled = false;
            }                        
        }

        private void DEVICEcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zDeviceSelected = ((ComboBox)sender).GetItemText(((ComboBox)sender).SelectedItem);

            // 選擇DEVICE時，若PLC使用自動倉，若是 LOADUNLOADING BAY，則對應的SIDE欄位則有TC與RH分別。
            if (zDeviceSelected == "LOAD/UNLOADING BAY")
            {

                    comboBox_SIDE_SRC.Items.Clear();

                    // 每一SC對應到的TC是以ID為設定，無法動態產生哪台SC對哪個TC點。
                    comboBox_SIDE_SRC.Items.Add("TC111, TC113, TC115");
                    comboBox_SIDE_SRC.Items.Add("TC308, TC310, TC312");
                    comboBox_SIDE_SRC.Items.Add("TC302, TC304, TC306");
                    comboBox_SIDE_SRC.Items.Add("TC204, TC208, TC212");
                    comboBox_SIDE_SRC.Items.Add("TC206, TC210, TC214");
                    comboBox_SIDE_SRC.Items.Add("TC402");
                    comboBox_SIDE_SRC.Items.Add("TC403, TC405");

                    comboBox_SIDE_SRC.SelectedIndex = 0;
            }
            else
            {
                comboBox_SIDE_SRC.Items.Clear();

                comboBox_SIDE_SRC.Items.Add("LEFT");
                comboBox_SIDE_SRC.Items.Add("RIGHT");
                comboBox_SIDE_SRC.Items.Add("NONE");

                comboBox_SIDE_SRC.SelectedIndex = 0;
            }            
        }

        private void comboBox_DEVICE_SRC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zDevice_SRC = ((ComboBox)sender).GetItemText(((ComboBox)sender).SelectedItem);

            Set_DeviceDST_item();

            if (zDevice_SRC=="Bay" || zDevice_SRC == "FeedBack")
            {
                if (zDevice_SRC == "Bay" || zDevice_SRC == "FeedBack")
                    Set_DeviceDST_item(false);

                comboBox_SIDE_SRC.SelectedIndex = 2;    // points to NONE
                comboBox_LEVEL_SRC.SelectedIndex = 18;  // points to 0
                textBox_POS_SRC.Text = "0";
            }
            else
            {
                comboBox_SIDE_SRC.SelectedIndex = 0;    // points to NONE
                comboBox_LEVEL_SRC.SelectedIndex = 0;  // points to 0
                textBox_POS_SRC.Text = "1";
            }
        }

        private void comboBox_DEVICE_DST_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zDevice_DST = ((ComboBox)sender).GetItemText(((ComboBox)sender).SelectedItem);

            if (zDevice_DST == "Bay" || zDevice_DST == "FeedBack")
            {
                comboBox_SIDE_DST.SelectedIndex = 2;    // points to NONE
                comboBox_LEVEL_DST.SelectedIndex = 18;  // points to 0
                textBox_POS_DST.Text = "0";
            }
            else
            {
                comboBox_SIDE_DST.SelectedIndex = 0;    // points to NONE
                comboBox_LEVEL_DST.SelectedIndex = 0;  // points to 0
                textBox_POS_DST.Text = "1";
            }
        }
    }
}
