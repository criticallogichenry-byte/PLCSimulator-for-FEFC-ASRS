namespace PLCTools
{
    partial class SC01_DLG
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
            this.richTextBox_Display = new System.Windows.Forms.RichTextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_delay = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // richTextBox_Display
            // 
            this.richTextBox_Display.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBox_Display.ForeColor = System.Drawing.Color.Lime;
            this.richTextBox_Display.Location = new System.Drawing.Point(5, 8);
            this.richTextBox_Display.Name = "richTextBox_Display";
            this.richTextBox_Display.Size = new System.Drawing.Size(1486, 766);
            this.richTextBox_Display.TabIndex = 2;
            this.richTextBox_Display.Text = "";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(683, 777);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(185, 32);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.click_start);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1393, 775);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(93, 33);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "CLOSE";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.click_stop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 781);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Delay : ";
            // 
            // comboBox_delay
            // 
            this.comboBox_delay.FormattingEnabled = true;
            this.comboBox_delay.Items.AddRange(new object[] {
            "NONE",
            "1 秒",
            "3 秒",
            "5 秒"});
            this.comboBox_delay.Location = new System.Drawing.Point(219, 776);
            this.comboBox_delay.Name = "comboBox_delay";
            this.comboBox_delay.Size = new System.Drawing.Size(121, 28);
            this.comboBox_delay.TabIndex = 6;
            this.comboBox_delay.SelectedIndexChanged += new System.EventHandler(this.comboBox_delay_SelectedIndexChanged);
            // 
            // SC01_DLG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1497, 812);
            this.Controls.Add(this.comboBox_delay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.richTextBox_Display);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SC01_DLG";
            this.Text = "SC01_DLG";
            this.Load += new System.EventHandler(this.SC01_DLG_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_Display;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_delay;
    }
}