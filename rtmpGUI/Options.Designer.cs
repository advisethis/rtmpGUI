namespace rtmpGUI
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.button1 = new System.Windows.Forms.Button();
            this.findVLC = new System.Windows.Forms.OpenFileDialog();
            this.txtVLCloc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSuppress = new System.Windows.Forms.CheckBox();
            this.chkCheckUpdates = new System.Windows.Forms.CheckBox();
            this.chkStartList = new System.Windows.Forms.CheckBox();
            this.chkWebPage = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(299, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Locate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // findVLC
            // 
            this.findVLC.FileName = "vlc.exe";
            this.findVLC.Filter = "VLC (vlc.exe)|vlc.exe";
            // 
            // txtVLCloc
            // 
            this.txtVLCloc.Enabled = false;
            this.txtVLCloc.Location = new System.Drawing.Point(6, 22);
            this.txtVLCloc.Name = "txtVLCloc";
            this.txtVLCloc.Size = new System.Drawing.Size(287, 20);
            this.txtVLCloc.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVLCloc);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Options";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Okay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 244);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSuppress);
            this.groupBox2.Controls.Add(this.chkCheckUpdates);
            this.groupBox2.Controls.Add(this.chkStartList);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 94);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program Options";
            // 
            // chkSuppress
            // 
            this.chkSuppress.AutoSize = true;
            this.chkSuppress.Location = new System.Drawing.Point(7, 67);
            this.chkSuppress.Name = "chkSuppress";
            this.chkSuppress.Size = new System.Drawing.Size(138, 17);
            this.chkSuppress.TabIndex = 3;
            this.chkSuppress.Text = "Suppress command line";
            this.chkSuppress.UseVisualStyleBackColor = true;
            // 
            // chkCheckUpdates
            // 
            this.chkCheckUpdates.AutoSize = true;
            this.chkCheckUpdates.Location = new System.Drawing.Point(7, 43);
            this.chkCheckUpdates.Name = "chkCheckUpdates";
            this.chkCheckUpdates.Size = new System.Drawing.Size(169, 17);
            this.chkCheckUpdates.TabIndex = 2;
            this.chkCheckUpdates.Text = "Check for updates on startup?";
            this.chkCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // chkStartList
            // 
            this.chkStartList.AutoSize = true;
            this.chkStartList.Location = new System.Drawing.Point(7, 19);
            this.chkStartList.Name = "chkStartList";
            this.chkStartList.Size = new System.Drawing.Size(197, 17);
            this.chkStartList.TabIndex = 1;
            this.chkStartList.Text = "Load remote channel list at start up?";
            this.chkStartList.UseVisualStyleBackColor = true;
            // 
            // chkWebPage
            // 
            this.chkWebPage.AutoSize = true;
            this.chkWebPage.Location = new System.Drawing.Point(7, 16);
            this.chkWebPage.Name = "chkWebPage";
            this.chkWebPage.Size = new System.Drawing.Size(144, 17);
            this.chkWebPage.TabIndex = 3;
            this.chkWebPage.Text = "Load alternate webpage.";
            this.chkWebPage.UseVisualStyleBackColor = true;
            this.chkWebPage.CheckedChanged += new System.EventHandler(this.chkWebPage_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkWebPage);
            this.groupBox3.Controls.Add(this.txtWeb);
            this.groupBox3.Location = new System.Drawing.Point(12, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 65);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Webpage";
            // 
            // txtWeb
            // 
            this.txtWeb.Enabled = false;
            this.txtWeb.Location = new System.Drawing.Point(6, 39);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(368, 20);
            this.txtWeb.TabIndex = 0;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 281);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog findVLC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox txtVLCloc;
        private System.Windows.Forms.CheckBox chkStartList;
        private System.Windows.Forms.CheckBox chkCheckUpdates;
        private System.Windows.Forms.CheckBox chkWebPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.CheckBox chkSuppress;
    }
}