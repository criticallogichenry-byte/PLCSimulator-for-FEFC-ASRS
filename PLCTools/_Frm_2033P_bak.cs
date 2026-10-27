using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Methods;
using ddmcOTIZ;
using PLCTools;

namespace MessageCheck
{
    public partial class Frm_2013P : Form
    {
        PLCdataOBJ mPLC;
        _2013P m2013P = new _2013P();
        _2113P m2113P = new _2113P();
        DBconfiguration mDBset = new DBconfiguration();

        int m_nType = Constants_GUAN_YING._GuanYin;   

        int nMissionID = 0;                     // only for LOG
        public string m_zMessageRAW = "";

        public Frm_2013P()
        {
            InitializeComponent();
        }

        public Frm_2013P(DBconfiguration DBset)
        {
            InitializeComponent();
            mDBset = DBset;
        }

        private void Frm_2013P_Load(object sender, EventArgs e)
        {    
            for (int i=0;i<Constants_GUAN_YING._MAX_LAYER;i++)
            {
                LEVELcomboBox.Items.Add(i+1);
            }   
                             
            ID_SRC.Text = "1";
            PR_MSG.Text = "1";

            MissionIDBox.Text = "0";
            BARCODEtextBox.Text = "0";
            POStextBox.Text = "1";
            MissionIDBox.Text = nMissionID.ToString();

            SAcomboBox.SelectedIndex = 0;

            PLCcombo.SelectedIndex = 0;            
            MissionTYPEcomboBox.SelectedIndex = 0;
            DEVICEcomboBox.SelectedIndex = 0;
            SIDEcomboBox.SelectedIndex = 0;
            LEVELcomboBox.SelectedIndex = 0;
            ERRORcomboBox.SelectedIndex = 0;
            MISSIONcomboBox.SelectedIndex = 0;
            comboBox_SUBPOS.SelectedIndex = 0;

            // 顯示DB登入至UI
            textBox_DBIPAddress.Text = mDBset.DBIP;
            textBox_DBUser.Text = mDBset.DBUSER;
            textBox_PW.Text = mDBset.DBPW;
            textBox_DBTable.Text = mDBset.DBTABLE;
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

            m2013P.header.ID_PLC = Convert.ToInt16(PLCcombo.GetItemText(PLCcombo.SelectedItem));

            szITEM = SAcomboBox.GetItemText(SAcomboBox.SelectedItem);
            if (szITEM == "SA31")
            {                
                m2013P.DEVICE_NR = 3431;
            }
            else if (szITEM == "SA32")
            {                
                m2013P.DEVICE_NR = 3432;
            }
            else if (szITEM == "SA33")
            {                
                m2013P.DEVICE_NR = 3433;
            }
            else if (szITEM == "SA34")
            {                
                m2013P.DEVICE_NR = 3434;
            }
            else if (szITEM == "SA35")
            {                
                m2013P.DEVICE_NR = 3435;
            }
            else if (szITEM == "SA36")
            {                
                m2013P.DEVICE_NR = 3436;
            }
            else if (szITEM == "SA37")
            {                
                m2013P.DEVICE_NR = 3437;
            }

            mPLC = new PLCdataOBJ(textBox_DBIPAddress.Text, textBox_DBUser.Text, textBox_PW.Text, textBox_DBTable.Text, false);     // real OTIZ connection       

            m2013P.header.ID_SRC = 1;
            m2013P.header.ID_MSG = 2013;
            m2013P.header.MSG_LEN = Convert.ToInt16(MSG_LEN.Text);
            m2013P.header.PR_MSG = Convert.ToInt16(PR_MSG.Text);

            m2013P.ORDER_ID = Convert.ToInt32(OrderIDBox.Text);
            m2013P.MISSION_ID = Convert.ToInt32(MissionIDBox.Text);

            // MISSION_TYPE
            switch (Convert.ToInt16(MissionTYPEcomboBox.SelectedIndex) + 1)
            {
                case 1:             // LOAD
                    m2013P.MISSION_TYPE = 1;
                    break;
                case 2:             // UNLOAD
                    m2013P.MISSION_TYPE = 2;
                    break;
                case 3:             // MOVE
                    m2013P.MISSION_TYPE = 3;
                    break;
            }

            // TRACK_ID
            m2013P.TRACK_ID = Convert.ToInt32(TrackIDBox.Text);

            // DEVICE
            switch (Convert.ToInt16(DEVICEcomboBox.SelectedIndex) + 1)
            {
                case 1:             // STORAGE
                    m2013P.DEVICE = 1;
                    break;
                case 2:             // LOAD/UNLOADING BAY
                    m2013P.DEVICE = 2;
                    break;
                case 3:             // FEEDBACK/PICKOUT
                    m2013P.DEVICE = 3;
                    break;
                case 4:             // STATION
                    m2013P.DEVICE = 4;
                    break;
            }

            // SIDE
            switch (Convert.ToInt16(SIDEcomboBox.SelectedIndex) + 1)
            {
                case 1:             // LEFT
                    m2013P.SIDE = 1;
                    break;
                case 2:             // RIGHT
                    m2013P.SIDE = 2;
                    break;
                case 3:             // NULL
                    m2013P.SIDE = 0;
                    break;
            }

            // LEVEL
            m2013P.LEVEL = Convert.ToInt16(LEVELcomboBox.SelectedIndex) + 1;

            // POS
            m2013P.POSITION = Convert.ToInt16(POStextBox.Text);

            // TYPE_PALLET
            m2013P.TYPE_PALLET = Convert.ToInt32(TYPE_PALLETtextBox.Text);

            // ERROR_CODE
            m2013P.ERROR_CODE = Convert.ToInt32(ERRORcomboBox.SelectedIndex) + 1;      // data from 1

            // MISSION_RESULT
            m2013P.MISSION_RESULT = Convert.ToInt32(MISSIONcomboBox.SelectedIndex);    // data from 0

            // BARCODE
            if (m_nType != PhaseType._ASRS)
                m2013P.BARCODE = Convert.ToInt32(BARCODEtextBox.Text);
            else
            {
                m2113P.header = m2013P.header;

                // m1271V.ORDER_ID = StringToHEXstring(nOrderID.ToString().PadLeft(10,'0'));
                m2113P.DEVICE = m2013P.DEVICE;
                m2113P.DEVICE_NR = m2013P.DEVICE_NR;
                m2113P.ERROR_CODE = m2013P.ERROR_CODE;
                m2113P.LEVEL = m2013P.LEVEL;
                m2113P.MISSION_ID = m2013P.MISSION_ID;
                m2113P.MISSION_RESULT = m2013P.MISSION_RESULT;
                m2113P.MISSION_TYPE = m2013P.MISSION_TYPE;
                m2113P.ORDER_ID = m2013P.ORDER_ID;
                m2113P.POSITION = m2013P.POSITION;
                m2113P.SIDE = m2013P.SIDE;
                m2113P.SUB_POSITION = m2013P.SUB_POSITION;
                m2113P.TRACK_ID = m2013P.TRACK_ID;
                m2113P.TYPE_PALLET = m2013P.TYPE_PALLET;
                m2113P.BARCODE = BARCODEtextBox.Text; //StringToHEXstring(BARCODEtextBox.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CollectAllUIdata();

            //mPLC.P2013(2013, m2013P);
            if (m_nType != PhaseType._ASRS)
                m_zMessageRAW = mPLC.messageP(2013, m2013P, checkBox_WriteToDB.Checked);            
            else
                m_zMessageRAW = mPLC.messageP(2113, m2113P, checkBox_WriteToDB.Checked);

            MessageBox.Show("寫入RAW : " + m_zMessageRAW, "2013P 資料", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(m_zMessageRAW);
        }
    }
}
