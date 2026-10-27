namespace PLCTools
{
    partial class Frm_Monitor
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
            this.dataGridView_command = new System.Windows.Forms.DataGridView();
            this.richTextBox_Display = new System.Windows.Forms.RichTextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_send_2033P = new System.Windows.Forms.Button();
            this.textBox_TRACKID_2033 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBox_SMALL = new System.Windows.Forms.CheckBox();
            this.checkBox_LARGE = new System.Windows.Forms.CheckBox();
            this.MISSIONcomboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.ERRORcomboBox = new System.Windows.Forms.ComboBox();
            this.POStextBox = new System.Windows.Forms.TextBox();
            this.LEVELcomboBox = new System.Windows.Forms.ComboBox();
            this.SIDEcomboBox = new System.Windows.Forms.ComboBox();
            this.comboBox_DEVICE = new System.Windows.Forms.ComboBox();
            this.MissionTYPEcomboBox = new System.Windows.Forms.ComboBox();
            this.SAcomboBox = new System.Windows.Forms.ComboBox();
            this.MissionIDBox = new System.Windows.Forms.TextBox();
            this.OrderIDBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_SGID_5 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox_SGID_4 = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox_SGID_3 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox_SGID_2 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_SGID_1 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_STATION_NR = new System.Windows.Forms.TextBox();
            this.comboBox_STATUS = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TRACKID_1121 = new System.Windows.Forms.TextBox();
            this.textBox_BARCODE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dateTimeTO = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFROM = new System.Windows.Forms.DateTimePicker();
            this.textBox_TrackID_forQuery = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBox_SC = new System.Windows.Forms.ComboBox();
            this.btn_cranc = new System.Windows.Forms.Button();
            this.btn_Mission = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_command)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_command
            // 
            this.dataGridView_command.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_command.Location = new System.Drawing.Point(13, 404);
            this.dataGridView_command.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView_command.Name = "dataGridView_command";
            this.dataGridView_command.RowHeadersWidth = 51;
            this.dataGridView_command.Size = new System.Drawing.Size(1041, 295);
            this.dataGridView_command.TabIndex = 0;
            this.dataGridView_command.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_command_CellContentDoubleClick);
            // 
            // richTextBox_Display
            // 
            this.richTextBox_Display.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox_Display.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_Display.Location = new System.Drawing.Point(13, 16);
            this.richTextBox_Display.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox_Display.Name = "richTextBox_Display";
            this.richTextBox_Display.Size = new System.Drawing.Size(429, 379);
            this.richTextBox_Display.TabIndex = 1;
            this.richTextBox_Display.Text = "";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(571, 704);
            this.btn_check.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(100, 48);
            this.btn_check.TabIndex = 2;
            this.btn_check.Text = "QUERY";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.BTN_click_QUERY);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_send_2033P);
            this.groupBox1.Controls.Add(this.textBox_TRACKID_2033);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.checkBox_SMALL);
            this.groupBox1.Controls.Add(this.checkBox_LARGE);
            this.groupBox1.Controls.Add(this.MISSIONcomboBox);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.ERRORcomboBox);
            this.groupBox1.Controls.Add(this.POStextBox);
            this.groupBox1.Controls.Add(this.LEVELcomboBox);
            this.groupBox1.Controls.Add(this.SIDEcomboBox);
            this.groupBox1.Controls.Add(this.comboBox_DEVICE);
            this.groupBox1.Controls.Add(this.MissionTYPEcomboBox);
            this.groupBox1.Controls.Add(this.SAcomboBox);
            this.groupBox1.Controls.Add(this.MissionIDBox);
            this.groupBox1.Controls.Add(this.OrderIDBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(759, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(296, 377);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "message 2033P";
            // 
            // btn_send_2033P
            // 
            this.btn_send_2033P.Location = new System.Drawing.Point(104, 335);
            this.btn_send_2033P.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_send_2033P.Name = "btn_send_2033P";
            this.btn_send_2033P.Size = new System.Drawing.Size(145, 37);
            this.btn_send_2033P.TabIndex = 150;
            this.btn_send_2033P.Text = "Send 2033P";
            this.btn_send_2033P.UseVisualStyleBackColor = true;
            this.btn_send_2033P.Click += new System.EventHandler(this.click_Send2033P);
            // 
            // textBox_TRACKID_2033
            // 
            this.textBox_TRACKID_2033.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_TRACKID_2033.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox_TRACKID_2033.Location = new System.Drawing.Point(141, 217);
            this.textBox_TRACKID_2033.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TRACKID_2033.Name = "textBox_TRACKID_2033";
            this.textBox_TRACKID_2033.Size = new System.Drawing.Size(147, 22);
            this.textBox_TRACKID_2033.TabIndex = 147;
            this.textBox_TRACKID_2033.Text = "0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(21, 223);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(78, 16);
            this.label23.TabIndex = 146;
            this.label23.Text = "TRACK_ID :";
            // 
            // checkBox_SMALL
            // 
            this.checkBox_SMALL.AutoSize = true;
            this.checkBox_SMALL.Location = new System.Drawing.Point(213, 305);
            this.checkBox_SMALL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_SMALL.Name = "checkBox_SMALL";
            this.checkBox_SMALL.Size = new System.Drawing.Size(59, 20);
            this.checkBox_SMALL.TabIndex = 145;
            this.checkBox_SMALL.Text = "小箱";
            this.checkBox_SMALL.UseVisualStyleBackColor = true;
            // 
            // checkBox_LARGE
            // 
            this.checkBox_LARGE.AutoSize = true;
            this.checkBox_LARGE.Location = new System.Drawing.Point(141, 305);
            this.checkBox_LARGE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBox_LARGE.Name = "checkBox_LARGE";
            this.checkBox_LARGE.Size = new System.Drawing.Size(59, 20);
            this.checkBox_LARGE.TabIndex = 144;
            this.checkBox_LARGE.Text = "大箱";
            this.checkBox_LARGE.UseVisualStyleBackColor = true;
            // 
            // MISSIONcomboBox
            // 
            this.MISSIONcomboBox.FormattingEnabled = true;
            this.MISSIONcomboBox.Items.AddRange(new object[] {
            "WORKING",
            "COMPLETED",
            "ABORTED",
            "手動指定"});
            this.MISSIONcomboBox.Location = new System.Drawing.Point(165, 276);
            this.MISSIONcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MISSIONcomboBox.Name = "MISSIONcomboBox";
            this.MISSIONcomboBox.Size = new System.Drawing.Size(123, 24);
            this.MISSIONcomboBox.TabIndex = 143;
            this.MISSIONcomboBox.SelectionChangeCommitted += new System.EventHandler(this.click_MissionResultCombo);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 281);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 16);
            this.label18.TabIndex = 142;
            this.label18.Text = "Mission Result :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(21, 252);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(78, 16);
            this.label17.TabIndex = 141;
            this.label17.Text = "Error Code :";
            // 
            // ERRORcomboBox
            // 
            this.ERRORcomboBox.FormattingEnabled = true;
            this.ERRORcomboBox.Items.AddRange(new object[] {
            "OK",
            "Tray/Pallet on board",
            "Tray/Pallet NOT on board",
            "Full to full",
            "Empty to empty",
            "SA is busy",
            "Barcode mismatch",
            "Possible Collision",
            "Manual mode",
            "Path is not free",
            "Wrong data in mission",
            "Rack remained on board"});
            this.ERRORcomboBox.Location = new System.Drawing.Point(116, 249);
            this.ERRORcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ERRORcomboBox.Name = "ERRORcomboBox";
            this.ERRORcomboBox.Size = new System.Drawing.Size(172, 24);
            this.ERRORcomboBox.TabIndex = 140;
            // 
            // POStextBox
            // 
            this.POStextBox.BackColor = System.Drawing.SystemColors.Window;
            this.POStextBox.Location = new System.Drawing.Point(141, 196);
            this.POStextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.POStextBox.Name = "POStextBox";
            this.POStextBox.Size = new System.Drawing.Size(147, 22);
            this.POStextBox.TabIndex = 139;
            this.POStextBox.Text = "1";
            // 
            // LEVELcomboBox
            // 
            this.LEVELcomboBox.FormattingEnabled = true;
            this.LEVELcomboBox.Location = new System.Drawing.Point(141, 167);
            this.LEVELcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LEVELcomboBox.Name = "LEVELcomboBox";
            this.LEVELcomboBox.Size = new System.Drawing.Size(147, 24);
            this.LEVELcomboBox.TabIndex = 138;
            // 
            // SIDEcomboBox
            // 
            this.SIDEcomboBox.FormattingEnabled = true;
            this.SIDEcomboBox.Items.AddRange(new object[] {
            "LEFT",
            "RIGHT",
            "NULL"});
            this.SIDEcomboBox.Location = new System.Drawing.Point(141, 140);
            this.SIDEcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SIDEcomboBox.Name = "SIDEcomboBox";
            this.SIDEcomboBox.Size = new System.Drawing.Size(147, 24);
            this.SIDEcomboBox.TabIndex = 137;
            // 
            // comboBox_DEVICE
            // 
            this.comboBox_DEVICE.FormattingEnabled = true;
            this.comboBox_DEVICE.Items.AddRange(new object[] {
            "STORAGE",
            "LOAD/UNLOADING BAY",
            "FEEDBACK/PICKUP",
            "STATION"});
            this.comboBox_DEVICE.Location = new System.Drawing.Point(104, 116);
            this.comboBox_DEVICE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_DEVICE.Name = "comboBox_DEVICE";
            this.comboBox_DEVICE.Size = new System.Drawing.Size(184, 24);
            this.comboBox_DEVICE.TabIndex = 136;
            // 
            // MissionTYPEcomboBox
            // 
            this.MissionTYPEcomboBox.FormattingEnabled = true;
            this.MissionTYPEcomboBox.Items.AddRange(new object[] {
            "LOAD",
            "UNLOAD",
            "MOVE",
            "LOAD-UNLOAD"});
            this.MissionTYPEcomboBox.Location = new System.Drawing.Point(141, 89);
            this.MissionTYPEcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MissionTYPEcomboBox.Name = "MissionTYPEcomboBox";
            this.MissionTYPEcomboBox.Size = new System.Drawing.Size(147, 24);
            this.MissionTYPEcomboBox.TabIndex = 135;
            // 
            // SAcomboBox
            // 
            this.SAcomboBox.FormattingEnabled = true;
            this.SAcomboBox.Items.AddRange(new object[] {
            "SA31",
            "SA32",
            "SA33",
            "SA34",
            "SA35",
            "SA36",
            "SA37"});
            this.SAcomboBox.Location = new System.Drawing.Point(141, 60);
            this.SAcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SAcomboBox.Name = "SAcomboBox";
            this.SAcomboBox.Size = new System.Drawing.Size(147, 24);
            this.SAcomboBox.TabIndex = 134;
            // 
            // MissionIDBox
            // 
            this.MissionIDBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.MissionIDBox.Enabled = false;
            this.MissionIDBox.Location = new System.Drawing.Point(141, 39);
            this.MissionIDBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MissionIDBox.Name = "MissionIDBox";
            this.MissionIDBox.Size = new System.Drawing.Size(147, 22);
            this.MissionIDBox.TabIndex = 133;
            this.MissionIDBox.Text = "0";
            // 
            // OrderIDBox
            // 
            this.OrderIDBox.BackColor = System.Drawing.SystemColors.Window;
            this.OrderIDBox.Enabled = false;
            this.OrderIDBox.Location = new System.Drawing.Point(141, 16);
            this.OrderIDBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OrderIDBox.Name = "OrderIDBox";
            this.OrderIDBox.Size = new System.Drawing.Size(147, 22);
            this.OrderIDBox.TabIndex = 132;
            this.OrderIDBox.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 308);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 16);
            this.label15.TabIndex = 131;
            this.label15.Text = "Type_Pallet :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 199);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 16);
            this.label13.TabIndex = 130;
            this.label13.Text = "POS :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(21, 172);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 129;
            this.label12.Text = "Level :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 148);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 128;
            this.label11.Text = "Side :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 119);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 127;
            this.label10.Text = "Device :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 97);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 126;
            this.label8.Text = "MissoinTYPE :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 71);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 16);
            this.label7.TabIndex = 125;
            this.label7.Text = "DeviceNR :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 16);
            this.label6.TabIndex = 124;
            this.label6.Text = "MissonID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 123;
            this.label1.Text = "OrderID :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBox_SGID_5);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.comboBox_SGID_4);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.comboBox_SGID_3);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.comboBox_SGID_2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.comboBox_SGID_1);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.textBox_STATION_NR);
            this.groupBox2.Controls.Add(this.comboBox_STATUS);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_TRACKID_1121);
            this.groupBox2.Controls.Add(this.textBox_BARCODE);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(451, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(303, 377);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "message 1121P";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 335);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 36);
            this.button1.TabIndex = 138;
            this.button1.Text = "Send1121P";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.click_Send1121P);
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
            "11",
            "12"});
            this.comboBox_SGID_5.Location = new System.Drawing.Point(119, 208);
            this.comboBox_SGID_5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SGID_5.Name = "comboBox_SGID_5";
            this.comboBox_SGID_5.Size = new System.Drawing.Size(49, 24);
            this.comboBox_SGID_5.TabIndex = 137;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(41, 213);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 16);
            this.label19.TabIndex = 136;
            this.label19.Text = "SG_ID 5 :";
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
            "11",
            "12"});
            this.comboBox_SGID_4.Location = new System.Drawing.Point(244, 180);
            this.comboBox_SGID_4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SGID_4.Name = "comboBox_SGID_4";
            this.comboBox_SGID_4.Size = new System.Drawing.Size(49, 24);
            this.comboBox_SGID_4.TabIndex = 135;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(173, 185);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(62, 16);
            this.label20.TabIndex = 134;
            this.label20.Text = "SG_ID 4 :";
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
            "11",
            "12"});
            this.comboBox_SGID_3.Location = new System.Drawing.Point(119, 177);
            this.comboBox_SGID_3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SGID_3.Name = "comboBox_SGID_3";
            this.comboBox_SGID_3.Size = new System.Drawing.Size(49, 24);
            this.comboBox_SGID_3.TabIndex = 133;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 185);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 16);
            this.label9.TabIndex = 132;
            this.label9.Text = "SG_ID 3 :";
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
            "11",
            "12"});
            this.comboBox_SGID_2.Location = new System.Drawing.Point(243, 148);
            this.comboBox_SGID_2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SGID_2.Name = "comboBox_SGID_2";
            this.comboBox_SGID_2.Size = new System.Drawing.Size(49, 24);
            this.comboBox_SGID_2.TabIndex = 131;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(171, 153);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 16);
            this.label14.TabIndex = 130;
            this.label14.Text = "SG_ID 2 :";
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
            "11",
            "12"});
            this.comboBox_SGID_1.Location = new System.Drawing.Point(119, 148);
            this.comboBox_SGID_1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SGID_1.Name = "comboBox_SGID_1";
            this.comboBox_SGID_1.Size = new System.Drawing.Size(49, 24);
            this.comboBox_SGID_1.TabIndex = 129;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(41, 153);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 128;
            this.label16.Text = "SG_ID 1 :";
            // 
            // textBox_STATION_NR
            // 
            this.textBox_STATION_NR.Location = new System.Drawing.Point(119, 20);
            this.textBox_STATION_NR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_STATION_NR.Name = "textBox_STATION_NR";
            this.textBox_STATION_NR.Size = new System.Drawing.Size(175, 22);
            this.textBox_STATION_NR.TabIndex = 127;
            // 
            // comboBox_STATUS
            // 
            this.comboBox_STATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_STATUS.FormattingEnabled = true;
            this.comboBox_STATUS.Items.AddRange(new object[] {
            "ARRIVE",
            "EVACUATED"});
            this.comboBox_STATUS.Location = new System.Drawing.Point(120, 52);
            this.comboBox_STATUS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_STATUS.Name = "comboBox_STATUS";
            this.comboBox_STATUS.Size = new System.Drawing.Size(175, 24);
            this.comboBox_STATUS.TabIndex = 126;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 125;
            this.label2.Text = "STATUS :";
            // 
            // textBox_TRACKID_1121
            // 
            this.textBox_TRACKID_1121.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.textBox_TRACKID_1121.Location = new System.Drawing.Point(119, 116);
            this.textBox_TRACKID_1121.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TRACKID_1121.Name = "textBox_TRACKID_1121";
            this.textBox_TRACKID_1121.Size = new System.Drawing.Size(175, 22);
            this.textBox_TRACKID_1121.TabIndex = 123;
            // 
            // textBox_BARCODE
            // 
            this.textBox_BARCODE.Location = new System.Drawing.Point(119, 84);
            this.textBox_BARCODE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_BARCODE.Name = "textBox_BARCODE";
            this.textBox_BARCODE.Size = new System.Drawing.Size(175, 22);
            this.textBox_BARCODE.TabIndex = 124;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 121;
            this.label3.Text = "TRACK_ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 89);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 122;
            this.label4.Text = "BARCODE :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 120;
            this.label5.Text = "STATION_NR :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(39, 732);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 16);
            this.label21.TabIndex = 11;
            this.label21.Text = "TO";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(16, 708);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 16);
            this.label22.TabIndex = 10;
            this.label22.Text = "FROM";
            // 
            // dateTimeTO
            // 
            this.dateTimeTO.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTO.Location = new System.Drawing.Point(75, 729);
            this.dateTimeTO.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeTO.Name = "dateTimeTO";
            this.dateTimeTO.Size = new System.Drawing.Size(265, 22);
            this.dateTimeTO.TabIndex = 9;
            // 
            // dateTimeFROM
            // 
            this.dateTimeFROM.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.dateTimeFROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeFROM.Location = new System.Drawing.Point(75, 700);
            this.dateTimeFROM.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimeFROM.Name = "dateTimeFROM";
            this.dateTimeFROM.Size = new System.Drawing.Size(265, 22);
            this.dateTimeFROM.TabIndex = 8;
            // 
            // textBox_TrackID_forQuery
            // 
            this.textBox_TrackID_forQuery.Location = new System.Drawing.Point(419, 703);
            this.textBox_TrackID_forQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_TrackID_forQuery.Name = "textBox_TrackID_forQuery";
            this.textBox_TrackID_forQuery.Size = new System.Drawing.Size(132, 22);
            this.textBox_TrackID_forQuery.TabIndex = 12;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(349, 705);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 16);
            this.label24.TabIndex = 13;
            this.label24.Text = "TrackID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(944, 708);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 39);
            this.button2.TabIndex = 14;
            this.button2.Text = "Pallet Monitor";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.click_StartMonitor);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(352, 731);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(37, 16);
            this.label25.TabIndex = 15;
            this.label25.Text = "吊車";
            // 
            // comboBox_SC
            // 
            this.comboBox_SC.FormattingEnabled = true;
            this.comboBox_SC.Items.AddRange(new object[] {
            "ALL",
            "SA1 [3431]",
            "SA2 [3432]",
            "SA3 [3433]",
            "SA4 [3434]",
            "SA5 [3435]",
            "SA6 [3436]",
            "SA7 [3437]"});
            this.comboBox_SC.Location = new System.Drawing.Point(419, 727);
            this.comboBox_SC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox_SC.Name = "comboBox_SC";
            this.comboBox_SC.Size = new System.Drawing.Size(132, 24);
            this.comboBox_SC.TabIndex = 16;
            // 
            // btn_cranc
            // 
            this.btn_cranc.Enabled = false;
            this.btn_cranc.Location = new System.Drawing.Point(828, 709);
            this.btn_cranc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_cranc.Name = "btn_cranc";
            this.btn_cranc.Size = new System.Drawing.Size(111, 39);
            this.btn_cranc.TabIndex = 17;
            this.btn_cranc.Text = "Crane Monitor";
            this.btn_cranc.UseVisualStyleBackColor = true;
            this.btn_cranc.Click += new System.EventHandler(this.click_crane_monitor);
            // 
            // btn_Mission
            // 
            this.btn_Mission.Location = new System.Drawing.Point(695, 709);
            this.btn_Mission.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Mission.Name = "btn_Mission";
            this.btn_Mission.Size = new System.Drawing.Size(128, 39);
            this.btn_Mission.TabIndex = 18;
            this.btn_Mission.Text = "Mission Monitor";
            this.btn_Mission.UseVisualStyleBackColor = true;
            this.btn_Mission.Click += new System.EventHandler(this.click_MissionMonitor);
            // 
            // Frm_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 756);
            this.Controls.Add(this.btn_Mission);
            this.Controls.Add(this.btn_cranc);
            this.Controls.Add(this.comboBox_SC);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox_TrackID_forQuery);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.dateTimeTO);
            this.Controls.Add(this.dateTimeFROM);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.richTextBox_Display);
            this.Controls.Add(this.dataGridView_command);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_Monitor";
            this.Text = "Frm_Monitor";
            this.Load += new System.EventHandler(this.Frm_Monitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_command)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_command;
        private System.Windows.Forms.RichTextBox richTextBox_Display;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_TRACKID_2033;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox checkBox_SMALL;
        private System.Windows.Forms.CheckBox checkBox_LARGE;
        private System.Windows.Forms.ComboBox MISSIONcomboBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox ERRORcomboBox;
        private System.Windows.Forms.TextBox POStextBox;
        private System.Windows.Forms.ComboBox LEVELcomboBox;
        private System.Windows.Forms.ComboBox SIDEcomboBox;
        private System.Windows.Forms.ComboBox comboBox_DEVICE;
        private System.Windows.Forms.ComboBox MissionTYPEcomboBox;
        private System.Windows.Forms.ComboBox SAcomboBox;
        private System.Windows.Forms.TextBox MissionIDBox;
        private System.Windows.Forms.TextBox OrderIDBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_STATION_NR;
        private System.Windows.Forms.ComboBox comboBox_STATUS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TRACKID_1121;
        private System.Windows.Forms.TextBox textBox_BARCODE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_SGID_3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox_SGID_2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_SGID_1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox_SGID_5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_SGID_4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btn_send_2033P;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dateTimeTO;
        private System.Windows.Forms.DateTimePicker dateTimeFROM;
        private System.Windows.Forms.TextBox textBox_TrackID_forQuery;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBox_SC;
        private System.Windows.Forms.Button btn_cranc;
        private System.Windows.Forms.Button btn_Mission;
    }
}