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
            this.components = new System.ComponentModel.Container();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAPIkey = new System.Windows.Forms.TextBox();
            this.txtAPIuser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtLocList = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.findChannels = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Locate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // findVLC
            // 
            this.findVLC.Filter = "Media Player |*.*";
            // 
            // txtVLCloc
            // 
            this.txtVLCloc.Enabled = false;
            this.txtVLCloc.Location = new System.Drawing.Point(6, 22);
            this.txtVLCloc.Name = "txtVLCloc";
            this.txtVLCloc.Size = new System.Drawing.Size(277, 20);
            this.txtVLCloc.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtVLCloc);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(8, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 56);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Options";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 267);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Okay";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(246, 267);
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
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 68);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program Options";
            // 
            // chkSuppress
            // 
            this.chkSuppress.AutoSize = true;
            this.chkSuppress.Location = new System.Drawing.Point(7, 43);
            this.chkSuppress.Name = "chkSuppress";
            this.chkSuppress.Size = new System.Drawing.Size(138, 17);
            this.chkSuppress.TabIndex = 3;
            this.chkSuppress.Text = "Suppress command line";
            this.chkSuppress.UseVisualStyleBackColor = true;
            // 
            // chkCheckUpdates
            // 
            this.chkCheckUpdates.AutoSize = true;
            this.chkCheckUpdates.Location = new System.Drawing.Point(7, 19);
            this.chkCheckUpdates.Name = "chkCheckUpdates";
            this.chkCheckUpdates.Size = new System.Drawing.Size(169, 17);
            this.chkCheckUpdates.TabIndex = 2;
            this.chkCheckUpdates.Text = "Check for updates on startup?";
            this.chkCheckUpdates.UseVisualStyleBackColor = true;
            // 
            // chkStartList
            // 
            this.chkStartList.AutoSize = true;
            this.chkStartList.Location = new System.Drawing.Point(6, 19);
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
            this.groupBox3.Location = new System.Drawing.Point(6, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 65);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Webpage";
            // 
            // txtWeb
            // 
            this.txtWeb.Enabled = false;
            this.txtWeb.Location = new System.Drawing.Point(6, 39);
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(358, 20);
            this.txtWeb.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(392, 249);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(384, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Program Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(384, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkLabel1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtAPIkey);
            this.groupBox4.Controls.Add(this.txtAPIuser);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 89);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "API Information";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(273, 68);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(90, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Register for a key";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "API Key :";
            // 
            // txtAPIkey
            // 
            this.txtAPIkey.Location = new System.Drawing.Point(79, 45);
            this.txtAPIkey.Name = "txtAPIkey";
            this.txtAPIkey.Size = new System.Drawing.Size(284, 20);
            this.txtAPIkey.TabIndex = 2;
            // 
            // txtAPIuser
            // 
            this.txtAPIuser.Location = new System.Drawing.Point(79, 19);
            this.txtAPIuser.Name = "txtAPIuser";
            this.txtAPIuser.Size = new System.Drawing.Size(285, 20);
            this.txtAPIuser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "application--pencil.png");
            this.imageList1.Images.SetKeyName(1, "servers-network.png");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.txtLocList);
            this.groupBox5.Controls.Add(this.chkStartList);
            this.groupBox5.Location = new System.Drawing.Point(8, 80);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(370, 75);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Channel Lsit Options";
            // 
            // txtLocList
            // 
            this.txtLocList.Enabled = false;
            this.txtLocList.Location = new System.Drawing.Point(6, 42);
            this.txtLocList.Name = "txtLocList";
            this.txtLocList.Size = new System.Drawing.Size(277, 20);
            this.txtLocList.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(289, 39);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Locate";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // findChannels
            // 
            this.findChannels.FileName = "openFileDialog1";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 302);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
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
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAPIkey;
        private System.Windows.Forms.TextBox txtAPIuser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtLocList;
        private System.Windows.Forms.OpenFileDialog findChannels;
    }
}