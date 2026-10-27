namespace PLCTools
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.textBox_RAW = new System.Windows.Forms.TextBox();
            this.btn_parse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(13, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(557, 315);
            this.tabControl1.TabIndex = 0;
            // 
            // textBox_RAW
            // 
            this.textBox_RAW.Location = new System.Drawing.Point(13, 8);
            this.textBox_RAW.Name = "textBox_RAW";
            this.textBox_RAW.Size = new System.Drawing.Size(474, 22);
            this.textBox_RAW.TabIndex = 1;
            // 
            // btn_parse
            // 
            this.btn_parse.Location = new System.Drawing.Point(493, 7);
            this.btn_parse.Name = "btn_parse";
            this.btn_parse.Size = new System.Drawing.Size(75, 23);
            this.btn_parse.TabIndex = 2;
            this.btn_parse.Text = "PARSE";
            this.btn_parse.UseVisualStyleBackColor = true;
            this.btn_parse.Click += new System.EventHandler(this.btn_parse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 356);
            this.Controls.Add(this.btn_parse);
            this.Controls.Add(this.textBox_RAW);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "觀音廠自動倉 V1.42";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox_RAW;
        private System.Windows.Forms.Button btn_parse;
        //private System.Windows.Forms.Button button1;
    }
}

