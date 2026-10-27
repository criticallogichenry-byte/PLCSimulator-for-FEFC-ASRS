namespace MessageCheck
{
    partial class Frm_1121P
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SRCcombo = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PR_MSG = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_BARCODE = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_WriteToDB = new System.Windows.Forms.CheckBox();
            this.groupBox_DB = new Methods.myGroupBox();
            this.textBox_DBIPAddress = new Methods.myIPTextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox_DBUser = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox_DBTable = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox_STATION_NR = new System.Windows.Forms.TextBox();
            this.textBox_ID_PLC = new System.Windows.Forms.TextBox();
            this.comboBox_STATUS = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_TRACK_ID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_SGID_1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_SGID_2 = new System.Windows.Forms.ComboBox();
            this.comboBox_SGID_3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_SGID_5 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_SGID_4 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox_DB.SuspendLayout();
            this.SuspendLayout();
            // 
            // SRCcombo
            // 
            this.SRCcombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SRCcombo.Enabled = false;
            this.SRCcombo.FormattingEnabled = true;
            this.SRCcombo.Items.AddRange(new object[] {
            "Carton Line1",
            "Carton Line2",
            "Pallet Line"});
            this.SRCcombo.Location = new System.Drawing.Point(76, 74);
            this.SRCcombo.Name = "SRCcombo";
            this.SRCcombo.Size = new System.Drawing.Size(100, 20);
            this.SRCcombo.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Location = new System.Drawing.Point(76, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "12";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "MSG_LEN :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "ID_SRC :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID_PLC :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "PR_MSG :";
            // 
            // PR_MSG
            // 
            this.PR_MSG.BackColor = System.Drawing.SystemColors.Menu;
            this.PR_MSG.Location = new System.Drawing.Point(76, 26);
            this.PR_MSG.Name = "PR_MSG";
            this.PR_MSG.Size = new System.Drawing.Size(100, 22);
            this.PR_MSG.TabIndex = 11;
            this.PR_MSG.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "STATION_NR :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "BARCODE :";
            // 
            // textBox_BARCODE
            // 
            this.textBox_BARCODE.Location = new System.Drawing.Point(264, 52);
            this.textBox_BARCODE.Name = "textBox_BARCODE";
            this.textBox_BARCODE.Size = new System.Drawing.Size(132, 22);
            this.textBox_BARCODE.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 33);
            this.button1.TabIndex = 37;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_WriteToDB
            // 
            this.checkBox_WriteToDB.AutoSize = true;
            this.checkBox_WriteToDB.Location = new System.Drawing.Point(304, 163);
            this.checkBox_WriteToDB.Name = "checkBox_WriteToDB";
            this.checkBox_WriteToDB.Size = new System.Drawing.Size(108, 16);
            this.checkBox_WriteToDB.TabIndex = 111;
            this.checkBox_WriteToDB.Text = "是否寫入資料庫";
            this.checkBox_WriteToDB.UseVisualStyleBackColor = true;
            // 
            // groupBox_DB
            // 
            this.groupBox_DB.BackColor = System.Drawing.Color.Khaki;
            this.groupBox_DB.Controls.Add(this.textBox_DBIPAddress);
            this.groupBox_DB.Controls.Add(this.textBox_PW);
            this.groupBox_DB.Controls.Add(this.label19);
            this.groupBox_DB.Controls.Add(this.textBox_DBUser);
            this.groupBox_DB.Controls.Add(this.label20);
            this.groupBox_DB.Controls.Add(this.textBox_DBTable);
            this.groupBox_DB.Controls.Add(this.label21);
            this.groupBox_DB.Controls.Add(this.label22);
            this.groupBox_DB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox_DB.Location = new System.Drawing.Point(10, 147);
            this.groupBox_DB.Name = "groupBox_DB";
            this.groupBox_DB.Size = new System.Drawing.Size(278, 90);
            this.groupBox_DB.TabIndex = 118;
            this.groupBox_DB.TabStop = false;
            this.groupBox_DB.Text = "DB";
            // 
            // textBox_DBIPAddress
            // 
            this.textBox_DBIPAddress.Location = new System.Drawing.Point(40, 27);
            this.textBox_DBIPAddress.Name = "textBox_DBIPAddress";
            this.textBox_DBIPAddress.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBIPAddress.TabIndex = 113;
            this.textBox_DBIPAddress.Text = "0.0.0.0";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_PW.Location = new System.Drawing.Point(173, 56);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(95, 22);
            this.textBox_PW.TabIndex = 73;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(142, 59);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 11);
            this.label19.TabIndex = 72;
            this.label19.Text = "PW :";
            // 
            // textBox_DBUser
            // 
            this.textBox_DBUser.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_DBUser.Location = new System.Drawing.Point(173, 28);
            this.textBox_DBUser.Name = "textBox_DBUser";
            this.textBox_DBUser.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBUser.TabIndex = 71;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(142, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 11);
            this.label20.TabIndex = 70;
            this.label20.Text = "USER :";
            // 
            // textBox_DBTable
            // 
            this.textBox_DBTable.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_DBTable.Location = new System.Drawing.Point(40, 55);
            this.textBox_DBTable.Name = "textBox_DBTable";
            this.textBox_DBTable.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBTable.TabIndex = 69;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(4, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(43, 11);
            this.label21.TabIndex = 68;
            this.label21.Text = "TABLE :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(4, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(39, 11);
            this.label22.TabIndex = 66;
            this.label22.Text = "ADDR :";
            // 
            // textBox_STATION_NR
            // 
            this.textBox_STATION_NR.Location = new System.Drawing.Point(264, 5);
            this.textBox_STATION_NR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_STATION_NR.Name = "textBox_STATION_NR";
            this.textBox_STATION_NR.Size = new System.Drawing.Size(132, 22);
            this.textBox_STATION_NR.TabIndex = 119;
            // 
            // textBox_ID_PLC
            // 
            this.textBox_ID_PLC.Enabled = false;
            this.textBox_ID_PLC.Location = new System.Drawing.Point(113, 50);
            this.textBox_ID_PLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ID_PLC.Name = "textBox_ID_PLC";
            this.textBox_ID_PLC.Size = new System.Drawing.Size(61, 22);
            this.textBox_ID_PLC.TabIndex = 120;
            this.textBox_ID_PLC.Text = "41";
            // 
            // comboBox_STATUS
            // 
            this.comboBox_STATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_STATUS.FormattingEnabled = true;
            this.comboBox_STATUS.Items.AddRange(new object[] {
            "ARRIVE",
            "EVACUATED"});
            this.comboBox_STATUS.Location = new System.Drawing.Point(265, 28);
            this.comboBox_STATUS.Name = "comboBox_STATUS";
            this.comboBox_STATUS.Size = new System.Drawing.Size(132, 20);
            this.comboBox_STATUS.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(207, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "STATUS :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "TRACK_ID :";
            // 
            // textBox_TRACK_ID
            // 
            this.textBox_TRACK_ID.Location = new System.Drawing.Point(264, 75);
            this.textBox_TRACK_ID.Name = "textBox_TRACK_ID";
            this.textBox_TRACK_ID.Size = new System.Drawing.Size(132, 22);
            this.textBox_TRACK_ID.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 121;
            this.label7.Text = "SG_ID 1 :";
            // 
            // comboBox_SGID_1
            // 
            this.comboBox_SGID_1.FormattingEnabled = true;
            this.comboBox_SGID_1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboBox_SGID_1.Location = new System.Drawing.Point(178, 99);
            this.comboBox_SGID_1.Name = "comboBox_SGID_1";
            this.comboBox_SGID_1.Size = new System.Drawing.Size(38, 20);
            this.comboBox_SGID_1.TabIndex = 122;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 12);
            this.label9.TabIndex = 123;
            this.label9.Text = "SG_ID 2 :";
            // 
            // comboBox_SGID_2
            // 
            this.comboBox_SGID_2.FormattingEnabled = true;
            this.comboBox_SGID_2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboBox_SGID_2.Location = new System.Drawing.Point(263, 98);
            this.comboBox_SGID_2.Name = "comboBox_SGID_2";
            this.comboBox_SGID_2.Size = new System.Drawing.Size(38, 20);
            this.comboBox_SGID_2.TabIndex = 124;
            // 
            // comboBox_SGID_3
            // 
            this.comboBox_SGID_3.FormattingEnabled = true;
            this.comboBox_SGID_3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboBox_SGID_3.Location = new System.Drawing.Point(354, 99);
            this.comboBox_SGID_3.Name = "comboBox_SGID_3";
            this.comboBox_SGID_3.Size = new System.Drawing.Size(38, 20);
            this.comboBox_SGID_3.TabIndex = 126;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 104);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 12);
            this.label11.TabIndex = 125;
            this.label11.Text = "SG_ID 3 :";
            // 
            // comboBox_SGID_5
            // 
            this.comboBox_SGID_5.FormattingEnabled = true;
            this.comboBox_SGID_5.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboBox_SGID_5.Location = new System.Drawing.Point(353, 121);
            this.comboBox_SGID_5.Name = "comboBox_SGID_5";
            this.comboBox_SGID_5.Size = new System.Drawing.Size(38, 20);
            this.comboBox_SGID_5.TabIndex = 130;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(310, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 12);
            this.label12.TabIndex = 129;
            this.label12.Text = "SG_ID 5 :";
            // 
            // comboBox_SGID_4
            // 
            this.comboBox_SGID_4.FormattingEnabled = true;
            this.comboBox_SGID_4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11"});
            this.comboBox_SGID_4.Location = new System.Drawing.Point(263, 121);
            this.comboBox_SGID_4.Name = "comboBox_SGID_4";
            this.comboBox_SGID_4.Size = new System.Drawing.Size(38, 20);
            this.comboBox_SGID_4.TabIndex = 128;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(220, 126);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 12);
            this.label13.TabIndex = 127;
            this.label13.Text = "SG_ID 4 :";
            // 
            // Frm_1121P
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 242);
            this.Controls.Add(this.comboBox_SGID_5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox_SGID_4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox_SGID_3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox_SGID_2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox_SGID_1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_ID_PLC);
            this.Controls.Add(this.textBox_STATION_NR);
            this.Controls.Add(this.groupBox_DB);
            this.Controls.Add(this.checkBox_WriteToDB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_STATUS);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_TRACK_ID);
            this.Controls.Add(this.textBox_BARCODE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SRCcombo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PR_MSG);
            this.Name = "Frm_1121P";
            this.Text = "Frm_1121P";
            this.Load += new System.EventHandler(this.Frm_1121P_Load);
            this.groupBox_DB.ResumeLayout(false);
            this.groupBox_DB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SRCcombo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PR_MSG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_BARCODE;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_WriteToDB;
        private Methods.myGroupBox groupBox_DB;
        private Methods.myIPTextBox textBox_DBIPAddress;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox_DBUser;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox_DBTable;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_STATION_NR;
        private System.Windows.Forms.TextBox textBox_ID_PLC;
        private System.Windows.Forms.ComboBox comboBox_STATUS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_TRACK_ID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_SGID_1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_SGID_2;
        private System.Windows.Forms.ComboBox comboBox_SGID_3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_SGID_5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_SGID_4;
        private System.Windows.Forms.Label label13;
    }
}