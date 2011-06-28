namespace rtmpGUI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.channel_name = new System.Windows.Forms.ColumnHeader();
            this.swf_url = new System.Windows.Forms.ColumnHeader();
            this.rtmp_url = new System.Windows.Forms.ColumnHeader();
            this.http_url = new System.Windows.Forms.ColumnHeader();
            this.additional_info = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.editChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.recordChannel = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sysLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.wbApp = new System.Windows.Forms.WebBrowser();
            this.txtCommands = new System.Windows.Forms.TextBox();
            this.locateVLC = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshxmlMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.showCommands = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.howToMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locateVLC,
            this.refreshxmlMenu,
            this.showCommands,
            this.toolStripSeparator1,
            this.exitMenu});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(205, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToMenu,
            this.aboutMenu});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.channel_name,
            this.swf_url,
            this.rtmp_url,
            this.http_url,
            this.additional_info});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.Location = new System.Drawing.Point(0, 27);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(191, 296);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // channel_name
            // 
            this.channel_name.Text = "Channel Name";
            this.channel_name.Width = 102;
            // 
            // swf_url
            // 
            this.swf_url.Text = "SWF URL";
            this.swf_url.Width = 80;
            // 
            // rtmp_url
            // 
            this.rtmp_url.Text = "Link";
            this.rtmp_url.Width = 80;
            // 
            // http_url
            // 
            this.http_url.Text = "Page URL";
            // 
            // additional_info
            // 
            this.additional_info.Text = "Playpath";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChannel,
            this.deleteChannel,
            this.editChannel,
            this.recordChannel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 92);
            // 
            // addChannel
            // 
            this.addChannel.Name = "addChannel";
            this.addChannel.Size = new System.Drawing.Size(158, 22);
            this.addChannel.Text = "Add Channel";
            this.addChannel.Click += new System.EventHandler(this.addChannel_Click);
            // 
            // deleteChannel
            // 
            this.deleteChannel.Name = "deleteChannel";
            this.deleteChannel.Size = new System.Drawing.Size(158, 22);
            this.deleteChannel.Text = "Delete Channel";
            this.deleteChannel.Click += new System.EventHandler(this.deleteChannel_Click);
            // 
            // editChannel
            // 
            this.editChannel.Name = "editChannel";
            this.editChannel.Size = new System.Drawing.Size(158, 22);
            this.editChannel.Text = "Edit Channel";
            this.editChannel.Click += new System.EventHandler(this.editChannel_Click);
            // 
            // recordChannel
            // 
            this.recordChannel.Name = "recordChannel";
            this.recordChannel.Size = new System.Drawing.Size(158, 22);
            this.recordChannel.Text = "Record Channel";
            this.recordChannel.Click += new System.EventHandler(this.recordChannel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sysLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(574, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sysLabel
            // 
            this.sysLabel.Name = "sysLabel";
            this.sysLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // wbApp
            // 
            this.wbApp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.wbApp.Location = new System.Drawing.Point(194, 28);
            this.wbApp.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbApp.Name = "wbApp";
            this.wbApp.Size = new System.Drawing.Size(380, 295);
            this.wbApp.TabIndex = 3;
            this.wbApp.Url = new System.Uri("http://affiliate.zap2it.com/tvlistings/ZCGrid.do", System.UriKind.Absolute);
            // 
            // txtCommands
            // 
            this.txtCommands.Location = new System.Drawing.Point(194, 28);
            this.txtCommands.Multiline = true;
            this.txtCommands.Name = "txtCommands";
            this.txtCommands.Size = new System.Drawing.Size(379, 294);
            this.txtCommands.TabIndex = 4;
            // 
            // locateVLC
            // 
            this.locateVLC.Image = global::rtmpGUI.Properties.Resources.application_form_add;
            this.locateVLC.Name = "locateVLC";
            this.locateVLC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.locateVLC.Size = new System.Drawing.Size(208, 22);
            this.locateVLC.Text = "&Options";
            this.locateVLC.Click += new System.EventHandler(this.optionsMenu_Click);
            // 
            // refreshxmlMenu
            // 
            this.refreshxmlMenu.Image = global::rtmpGUI.Properties.Resources.arrow_refresh;
            this.refreshxmlMenu.Name = "refreshxmlMenu";
            this.refreshxmlMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshxmlMenu.Size = new System.Drawing.Size(208, 22);
            this.refreshxmlMenu.Text = "&Refresh XML";
            this.refreshxmlMenu.Click += new System.EventHandler(this.refreshxmlMenu_Click);
            // 
            // showCommands
            // 
            this.showCommands.CheckOnClick = true;
            this.showCommands.Image = global::rtmpGUI.Properties.Resources.application_osx_terminal;
            this.showCommands.Name = "showCommands";
            this.showCommands.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.showCommands.Size = new System.Drawing.Size(208, 22);
            this.showCommands.Text = "&Show Commands";
            this.showCommands.Click += new System.EventHandler(this.showCommands_Click);
            // 
            // exitMenu
            // 
            this.exitMenu.Image = global::rtmpGUI.Properties.Resources.cross;
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitMenu.Size = new System.Drawing.Size(208, 22);
            this.exitMenu.Text = "E&xit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // howToMenu
            // 
            this.howToMenu.Image = global::rtmpGUI.Properties.Resources.newspaper;
            this.howToMenu.Name = "howToMenu";
            this.howToMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.howToMenu.Size = new System.Drawing.Size(159, 22);
            this.howToMenu.Text = "H&ow To";
            this.howToMenu.Click += new System.EventHandler(this.howToMenu_Click);
            // 
            // aboutMenu
            // 
            this.aboutMenu.Image = global::rtmpGUI.Properties.Resources.world;
            this.aboutMenu.Name = "aboutMenu";
            this.aboutMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.aboutMenu.Size = new System.Drawing.Size(159, 22);
            this.aboutMenu.Text = "&About";
            this.aboutMenu.Click += new System.EventHandler(this.aboutMenu_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 345);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.wbApp);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtCommands);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "rtmpGUI";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locateVLC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshxmlMenu;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem howToMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutMenu;
        private System.Windows.Forms.ColumnHeader channel_name;
        private System.Windows.Forms.ColumnHeader swf_url;
        private System.Windows.Forms.ColumnHeader rtmp_url;
        private System.Windows.Forms.ColumnHeader http_url;
        private System.Windows.Forms.ColumnHeader additional_info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sysLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recordChannel;
        private System.Windows.Forms.ToolStripMenuItem showCommands;
        private System.Windows.Forms.ToolStripMenuItem addChannel;
        private System.Windows.Forms.ToolStripMenuItem deleteChannel;
        private System.Windows.Forms.TextBox txtCommands;
        private System.Windows.Forms.ToolStripMenuItem editChannel;
        public System.Windows.Forms.WebBrowser wbApp;
        protected internal System.Windows.Forms.ListView listView1;
    }
}

