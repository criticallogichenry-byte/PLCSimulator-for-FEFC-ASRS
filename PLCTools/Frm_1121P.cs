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
    public partial class Frm_1121P : Form
    {
        Algorithm m_DataConvert = new Algorithm();
        PLCdata_FENC mPLC;
        _1121P m1121P = new _1121P();
        
        public int m_nSequenceNumber;
        public string m_szCurTime;
        public string m_zMessageRAW;

        bool m_bForceToSpecifyDB = false;               // 強制指定自設資料庫

        int m_nType = Constants_GUAN_YING._GuanYin;                // 第三or第四期站點        
        DBconfiguration mDBset = new DBconfiguration();

        public Frm_1121P()
        {
            InitializeComponent();

            m_zMessageRAW = "";
            m_szCurTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public Frm_1121P(DBconfiguration DBset)
        {
            InitializeComponent();
            mDBset = DBset;
        }

        private void Frm_1121P_Load(object sender, EventArgs e)
        {                                                                
            comboBox_STATUS.SelectedIndex = 0;                        
            SRCcombo.SelectedIndex = 0;
            comboBox_SGID_1.SelectedIndex = 1;
            comboBox_SGID_2.SelectedIndex = 0;
            comboBox_SGID_3.SelectedIndex = 0;
            comboBox_SGID_4.SelectedIndex = 0;
            comboBox_SGID_5.SelectedIndex = 0;

            textBox_STATION_NR.Text = "4011";
            textBox_BARCODE.Text = "D71230400515";
            textBox_TRACK_ID.Text = "0";

            // 顯示DB登入至UI
            textBox_DBIPAddress.Text = mDBset.DBIP;
            textBox_DBUser.Text = mDBset.DBUSER;
            textBox_PW.Text = mDBset.DBPW;
            textBox_DBTable.Text = mDBset.DBTABLE;
        }

        private void check_Force(object sender, EventArgs e)
        {
            m_bForceToSpecifyDB ^= true;

        }

        private void button1_Click(object sender, EventArgs e)
        {                                        
            m1121P.header.PR_MSG = Convert.ToInt32(PR_MSG.Text);

            mPLC = new PLCdata_FENC(textBox_DBIPAddress.Text, textBox_DBUser.Text, textBox_PW.Text, textBox_DBTable.Text, false);     // real OTIZ connection                    

            // 設定 ID_PLC
            // 依所選的PLC決定連線第三或四期的資料庫  

            m1121P.header.MSG_LEN = _1121P.FOOTER;
            m1121P.header.ID_PLC = Convert.ToInt16(textBox_ID_PLC.Text);
            m1121P.header.ID_SRC = 1;

            // STATION_NR
            m1121P.STATION_NR = Convert.ToInt32(textBox_STATION_NR.Text);

            // STATUS
            string zSelected = comboBox_STATUS.GetItemText(comboBox_STATUS.SelectedItem);
            if (zSelected == "ARRIVE")
                m1121P.STATUS = 1;
            else if (zSelected == "EVACUATED")
                m1121P.STATUS = 99;

            // BARCODE
            m1121P.BARCODE = m_DataConvert.StringToHEXstring(textBox_BARCODE.Text);

            // TRACK_ID
            m1121P.TRACK_ID = Convert.ToInt32(textBox_TRACK_ID.Text);

            // SG_ID1 ~ 5
            int nSelected = Convert.ToInt16(comboBox_SGID_1.SelectedIndex);
            m1121P.SG_ID1 = nSelected;

            nSelected = Convert.ToInt16(comboBox_SGID_2.SelectedIndex);
            m1121P.SG_ID2 = nSelected;

            nSelected = Convert.ToInt16(comboBox_SGID_3.SelectedIndex);
            m1121P.SG_ID3 = nSelected;

            nSelected = Convert.ToInt16(comboBox_SGID_4.SelectedIndex);
            m1121P.SG_ID4 = nSelected;

            nSelected = Convert.ToInt16(comboBox_SGID_5.SelectedIndex);
            m1121P.SG_ID5 = nSelected;

            //int nSerialNO = mPLC.V1122(m1122V.header.ID_PLC, m1122V.header.ID_SRC, m1122V);
            int nSerial = m1121P.header.PR_MSG;

            m_zMessageRAW = mPLC.messageP(1121, m1121P, checkBox_WriteToDB.Checked);
            m1121P = mPLC.P1121Parser(m_zMessageRAW);

            DialogResult = DialogResult.OK;
            return;
        }

        public void SetMessageData(_1121P objMessage)
        {
            textBox_STATION_NR.Text = objMessage.STATION_NR.ToString();

            if (objMessage.STATUS == 1)
                comboBox_STATUS.SelectedIndex = 0;
            else
                comboBox_STATUS.SelectedIndex = 1;

            textBox_BARCODE.Text = objMessage.BARCODE;

            if (objMessage.STATION_NR == 3112 && objMessage.STATUS == 1)
                textBox_TRACK_ID.Text = "0";
            else
                textBox_TRACK_ID.Text = objMessage.TRACK_ID.ToString();
        }
    }
}
