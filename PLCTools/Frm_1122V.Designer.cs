namespace MessageCheck
{
    partial class Frm_1122V
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
            this.label7 = new System.Windows.Forms.Label();
            this.COMMANDcomboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TRACK_IDtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_WriteToDB = new System.Windows.Forms.CheckBox();
            this.textBox_ID_PLC = new System.Windows.Forms.TextBox();
            this.textBox_STATION_NR = new System.Windows.Forms.TextBox();
            this.textBox_DEST_STATION_NR = new System.Windows.Forms.TextBox();
            this.groupBox_DB = new Methods.myGroupBox();
            this.textBox_DBIPAddress = new Methods.myIPTextBox();
            this.textBox_PW = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_DBUser = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_DBTable = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_PACKAGE_TYPE = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_BARCODE = new System.Windows.Forms.TextBox();
            this.textBox_Display_RAW = new System.Windows.Forms.TextBox();
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
            this.SRCcombo.Location = new System.Drawing.Point(76, 85);
            this.SRCcombo.Name = "SRCcombo";
            this.SRCcombo.Size = new System.Drawing.Size(88, 20);
            this.SRCcombo.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Enabled = false;
            this.textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Location = new System.Drawing.Point(76, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 22);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "13";
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
            this.label3.Location = new System.Drawing.Point(9, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "ID_SRC :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID_PLC :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "PR_MSG :";
            // 
            // PR_MSG
            // 
            this.PR_MSG.BackColor = System.Drawing.SystemColors.Menu;
            this.PR_MSG.Location = new System.Drawing.Point(76, 30);
            this.PR_MSG.Name = "PR_MSG";
            this.PR_MSG.Size = new System.Drawing.Size(88, 22);
            this.PR_MSG.TabIndex = 11;
            this.PR_MSG.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "STATION_NR :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "COMMAND :";
            // 
            // COMMANDcomboBox
            // 
            this.COMMANDcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COMMANDcomboBox.FormattingEnabled = true;
            this.COMMANDcomboBox.Items.AddRange(new object[] {
            "MOVE",
            "RESET",
            "CLEAR"});
            this.COMMANDcomboBox.Location = new System.Drawing.Point(351, 35);
            this.COMMANDcomboBox.Name = "COMMANDcomboBox";
            this.COMMANDcomboBox.Size = new System.Drawing.Size(134, 20);
            this.COMMANDcomboBox.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(272, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 12);
            this.label8.TabIndex = 25;
            this.label8.Text = "TRACK_ID :";
            // 
            // TRACK_IDtextBox
            // 
            this.TRACK_IDtextBox.Location = new System.Drawing.Point(351, 119);
            this.TRACK_IDtextBox.Name = "TRACK_IDtextBox";
            this.TRACK_IDtextBox.Size = new System.Drawing.Size(132, 22);
            this.TRACK_IDtextBox.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(225, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 12);
            this.label9.TabIndex = 27;
            this.label9.Text = "DEST_STATION_NR :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(262, 219);
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
            this.checkBox_WriteToDB.Location = new System.Drawing.Point(262, 201);
            this.checkBox_WriteToDB.Name = "checkBox_WriteToDB";
            this.checkBox_WriteToDB.Size = new System.Drawing.Size(108, 16);
            this.checkBox_WriteToDB.TabIndex = 111;
            this.checkBox_WriteToDB.Text = "是否寫入資料庫";
            this.checkBox_WriteToDB.UseVisualStyleBackColor = true;
            // 
            // textBox_ID_PLC
            // 
            this.textBox_ID_PLC.Enabled = false;
            this.textBox_ID_PLC.Location = new System.Drawing.Point(76, 57);
            this.textBox_ID_PLC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_ID_PLC.Name = "textBox_ID_PLC";
            this.textBox_ID_PLC.Size = new System.Drawing.Size(76, 22);
            this.textBox_ID_PLC.TabIndex = 113;
            this.textBox_ID_PLC.Text = "41";
            // 
            // textBox_STATION_NR
            // 
            this.textBox_STATION_NR.Location = new System.Drawing.Point(351, 10);
            this.textBox_STATION_NR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_STATION_NR.Name = "textBox_STATION_NR";
            this.textBox_STATION_NR.Size = new System.Drawing.Size(134, 22);
            this.textBox_STATION_NR.TabIndex = 114;
            // 
            // textBox_DEST_STATION_NR
            // 
            this.textBox_DEST_STATION_NR.Location = new System.Drawing.Point(351, 63);
            this.textBox_DEST_STATION_NR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_DEST_STATION_NR.Name = "textBox_DEST_STATION_NR";
            this.textBox_DEST_STATION_NR.Size = new System.Drawing.Size(132, 22);
            this.textBox_DEST_STATION_NR.TabIndex = 115;
            // 
            // groupBox_DB
            // 
            this.groupBox_DB.BackColor = System.Drawing.Color.Khaki;
            this.groupBox_DB.Controls.Add(this.textBox_DBIPAddress);
            this.groupBox_DB.Controls.Add(this.textBox_PW);
            this.groupBox_DB.Controls.Add(this.label17);
            this.groupBox_DB.Controls.Add(this.textBox_DBUser);
            this.groupBox_DB.Controls.Add(this.label16);
            this.groupBox_DB.Controls.Add(this.textBox_DBTable);
            this.groupBox_DB.Controls.Add(this.label15);
            this.groupBox_DB.Controls.Add(this.label14);
            this.groupBox_DB.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox_DB.Location = new System.Drawing.Point(8, 114);
            this.groupBox_DB.Name = "groupBox_DB";
            this.groupBox_DB.Size = new System.Drawing.Size(156, 138);
            this.groupBox_DB.TabIndex = 112;
            this.groupBox_DB.TabStop = false;
            this.groupBox_DB.Text = "DB";
            // 
            // textBox_DBIPAddress
            // 
            this.textBox_DBIPAddress.Location = new System.Drawing.Point(55, 26);
            this.textBox_DBIPAddress.Name = "textBox_DBIPAddress";
            this.textBox_DBIPAddress.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBIPAddress.TabIndex = 113;
            this.textBox_DBIPAddress.Text = "0.0.0.0";
            // 
            // textBox_PW
            // 
            this.textBox_PW.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_PW.Location = new System.Drawing.Point(55, 110);
            this.textBox_PW.Name = "textBox_PW";
            this.textBox_PW.Size = new System.Drawing.Size(95, 22);
            this.textBox_PW.TabIndex = 73;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(7, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 11);
            this.label17.TabIndex = 72;
            this.label17.Text = "PW :";
            // 
            // textBox_DBUser
            // 
            this.textBox_DBUser.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_DBUser.Location = new System.Drawing.Point(55, 82);
            this.textBox_DBUser.Name = "textBox_DBUser";
            this.textBox_DBUser.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBUser.TabIndex = 71;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(6, 88);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 11);
            this.label16.TabIndex = 70;
            this.label16.Text = "USER :";
            // 
            // textBox_DBTable
            // 
            this.textBox_DBTable.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_DBTable.Location = new System.Drawing.Point(55, 54);
            this.textBox_DBTable.Name = "textBox_DBTable";
            this.textBox_DBTable.Size = new System.Drawing.Size(95, 22);
            this.textBox_DBTable.TabIndex = 69;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(6, 60);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 11);
            this.label15.TabIndex = 68;
            this.label15.Text = "TABLE :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(6, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 11);
            this.label14.TabIndex = 66;
            this.label14.Text = "ADDR :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 12);
            this.label6.TabIndex = 116;
            this.label6.Text = "PACKAGE_TYPE :";
            // 
            // comboBox_PACKAGE_TYPE
            // 
            this.comboBox_PACKAGE_TYPE.FormattingEnabled = true;
            this.comboBox_PACKAGE_TYPE.Items.AddRange(new object[] {
            "大棧板",
            "小棧板"});
            this.comboBox_PACKAGE_TYPE.Location = new System.Drawing.Point(351, 88);
            this.comboBox_PACKAGE_TYPE.Name = "comboBox_PACKAGE_TYPE";
            this.comboBox_PACKAGE_TYPE.Size = new System.Drawing.Size(132, 20);
            this.comboBox_PACKAGE_TYPE.TabIndex = 117;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(270, 152);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 12);
            this.label11.TabIndex = 120;
            this.label11.Text = "BARCODE :";
            // 
            // textBox_BARCODE
            // 
            this.textBox_BARCODE.Location = new System.Drawing.Point(351, 148);
            this.textBox_BARCODE.Name = "textBox_BARCODE";
            this.textBox_BARCODE.Size = new System.Drawing.Size(132, 22);
            this.textBox_BARCODE.TabIndex = 121;
            this.textBox_BARCODE.Text = "0";
            // 
            // textBox_Display_RAW
            // 
            this.textBox_Display_RAW.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox_Display_RAW.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Display_RAW.ForeColor = System.Drawing.Color.Lime;
            this.textBox_Display_RAW.Location = new System.Drawing.Point(10, 259);
            this.textBox_Display_RAW.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_Display_RAW.Name = "textBox_Display_RAW";
            this.textBox_Display_RAW.ReadOnly = true;
            this.textBox_Display_RAW.Size = new System.Drawing.Size(474, 23);
            this.textBox_Display_RAW.TabIndex = 122;
            // 
            // Frm_1122V
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 300);
            this.Controls.Add(this.textBox_Display_RAW);
            this.Controls.Add(this.textBox_BARCODE);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox_PACKAGE_TYPE);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_DEST_STATION_NR);
            this.Controls.Add(this.textBox_STATION_NR);
            this.Controls.Add(this.textBox_ID_PLC);
            this.Controls.Add(this.groupBox_DB);
            this.Controls.Add(this.checkBox_WriteToDB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TRACK_IDtextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.COMMANDcomboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SRCcombo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PR_MSG);
            this.Name = "Frm_1122V";
            this.Text = "Frm_1122V";
            this.Load += new System.EventHandler(this.Frm_1122V_Load);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox COMMANDcomboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TRACK_IDtextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_WriteToDB;
        private Methods.myGroupBox groupBox_DB;
        private System.Windows.Forms.TextBox textBox_PW;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_DBUser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_DBTable;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private Methods.myIPTextBox textBox_DBIPAddress;
        private System.Windows.Forms.TextBox textBox_ID_PLC;
        private System.Windows.Forms.TextBox textBox_STATION_NR;
        private System.Windows.Forms.TextBox textBox_DEST_STATION_NR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_PACKAGE_TYPE;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_BARCODE;
        private System.Windows.Forms.TextBox textBox_Display_RAW;
    }
}