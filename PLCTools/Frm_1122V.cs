using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Methods_FENC;
using Methods.Algorithm;
using ddmcOTIZ;
using PLCTools;

namespace MessageCheck
{
    public partial class Frm_1122V : Form
    {
        Algorithm m_DataConvert = new Algorithm();
        PLCdata_FENC mPLC;
        _1122V m1122V = new _1122V();

        public string m_zMessageRAW;
        public int m_nSequenceNumber;
        public string m_szCurTime;

        bool m_bForceToSpecifyDB = false;               // 強制指定自設資料庫

        int m_nType = Constants_GUAN_YING._GuanYin;                       // 第三or第四期站點
        //myStationDEF mStations = new myStationDEF();    // 站點名稱與ID
        DBconfiguration mDBset = new DBconfiguration();

        public Frm_1122V()
        {
            InitializeComponent();

            m_zMessageRAW = "";
            m_szCurTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public Frm_1122V(DBconfiguration DBset)
        {
            InitializeComponent();

            mDBset = DBset;
        }

        private void Frm_1122V_Load(object sender, EventArgs e)
        {                                  
            COMMANDcomboBox.SelectedIndex = 1;          // default to MOVE
            comboBox_PACKAGE_TYPE.SelectedIndex = 0;            
            SRCcombo.SelectedIndex = 0;
            textBox_BARCODE.Text = "0"; // "D71230400515";

            TRACK_IDtextBox.Text = "10000001";
            textBox_STATION_NR.Text = "4011";
            textBox_DEST_STATION_NR.Text = "4062";

            // 顯示DB登入至UI
            textBox_DBIPAddress.Text = mDBset.DBIP;
            textBox_DBUser.Text = mDBset.DBUSER;
            textBox_PW.Text = mDBset.DBPW;
            textBox_DBTable.Text = mDBset.DBTABLE;
        }

        private void check_Force(object sender, EventArgs e)
        {
            m_bForceToSpecifyDB ^= true;

            if (m_bForceToSpecifyDB)
            {
                textBox_DBIPAddress.Enabled = true;
                textBox_DBTable.Enabled = true;
                textBox_DBUser.Enabled = true;
                textBox_PW.Enabled = true;
            }
            else
            {
                textBox_DBIPAddress.Enabled = false;
                textBox_DBTable.Enabled = false;
                textBox_DBUser.Enabled = false;
                textBox_PW.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string szITEM = "";
                            
//            m1122V.header.PR_MSG = Convert.ToInt32(PR_MSG.Text);

//            m1122V.header.ID_SRC = 1;
//            m1122V.header.ID_MSG = 1122;

//            m1122V.header.MSG_LEN = _1122V.FOOTER;
            m1122V.header.PR_MSG = Convert.ToInt32(PR_MSG.Text);           //由資料庫產生，不外加處理 Convert.ToInt16(PR_MSG.Text);

            mDBset.DBIP = textBox_DBIPAddress.Text;
            mDBset.DBPW = textBox_PW.Text;
            mDBset.DBUSER = textBox_DBUser.Text;
            mDBset.DBTABLE = textBox_DBTable.Text;                
            
            mPLC = new PLCdata_FENC(mDBset.DBIP, mDBset.DBUSER, mDBset.DBPW, mDBset.DBTABLE, false);     // real OTIZ connection                    

            // 設定 ID_PLC
            m1122V.header.ID_PLC = Convert.ToInt16(textBox_ID_PLC.Text);

            // STATION_NR
            m1122V.STATION_NR = Convert.ToInt32(textBox_STATION_NR.Text);

            // DEST_STATION_NR
            m1122V.DESTINATION_STATION_NR = Convert.ToInt32(textBox_DEST_STATION_NR.Text);

            // COMMAND
            szITEM = COMMANDcomboBox.GetItemText(COMMANDcomboBox.SelectedItem);
            switch (szITEM)
            {
                case "MOVE":
                    m1122V.COMMAND = Constants_FENC.MOVE;
                    break;
                case "RESET":
                    m1122V.COMMAND = Constants_FENC.RESET;
                    break;
                case "CLEAR":
                    m1122V.COMMAND = Constants_FENC.RESET_TRACKID;
                    break;
            }

            // 棧板大小
            switch (Convert.ToInt16(comboBox_PACKAGE_TYPE.SelectedIndex))
            {
                case 0:
                    m1122V.PACKAGE_TYPE = 0;
                    break;
                case 1:
                    m1122V.PACKAGE_TYPE = 1;
                    break;
            }

            // TRACK_ID
            m1122V.TRACK_ID = Convert.ToInt32(TRACK_IDtextBox.Text);

            // BARCODE  // 沒輸入則於RAW中產生 00000000000000000000000000000000 空值
            if (textBox_BARCODE.Text == "0")
                m1122V.BARCODE = "0";
            else
                //m1122V.BARCODE = m_DataConvert.StringToHEXstring(textBox_BARCODE.Text);
                m1122V.BARCODE = textBox_BARCODE.Text;  // 改由DLL進行轉碼
    
            //int nSerialNO = mPLC.V1122(m1122V.header.ID_PLC, m1122V.header.ID_SRC, m1122V);
            int nSerial = m1122V.header.PR_MSG;

            // 因應自動倉使用31，避免衝突暫且用99代替
            m_zMessageRAW = mPLC.messageV(1122, m1122V.header.ID_PLC, m1122V.header.ID_SRC, m1122V, nSerial, checkBox_WriteToDB.Checked);
            //m_zMessageRAW = mPLC.messageV(1122, 99, m1122V.header.ID_SRC, m1122V, nSerial, checkBox_WriteToDB.Checked);

            MessageBox.Show("產生RAW : " + m_zMessageRAW, "1122V 命令", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText(m_zMessageRAW);

            textBox_Display_RAW.Text = m_zMessageRAW;
            //DialogResult = DialogResult.OK;
            //return;
        }
    }
}
