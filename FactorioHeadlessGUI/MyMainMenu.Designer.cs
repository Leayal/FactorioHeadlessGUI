namespace FactorioHeadlessGUI
{
    partial class MyMainMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEXELocation = new System.Windows.Forms.TextBox();
            this.buttonBrowseEXE = new System.Windows.Forms.Button();
            this.buttonBrowseSave = new System.Windows.Forms.Button();
            this.textBoxSaveLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelConfig = new System.Windows.Forms.Panel();
            this.buttonBrowseServerConfig = new System.Windows.Forms.Button();
            this.textBoxServerConfig = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxArgs = new System.Windows.Forms.TextBox();
            this.panelServerUI = new System.Windows.Forms.Panel();
            this.listBoxPlayerList = new System.Windows.Forms.ListBox();
            this.textBoxServerCommand = new System.Windows.Forms.TextBox();
            this.richTextBoxChatLog = new Leayal.Forms.ExRichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripPlayerList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.whisperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exRichTextBoxCommandlog = new Leayal.Forms.ExRichTextBox();
            this.panelConfig.SuspendLayout();
            this.panelServerUI.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripPlayerList.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Executable File";
            // 
            // textBoxEXELocation
            // 
            this.textBoxEXELocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEXELocation.Location = new System.Drawing.Point(1, 19);
            this.textBoxEXELocation.Name = "textBoxEXELocation";
            this.textBoxEXELocation.Size = new System.Drawing.Size(593, 20);
            this.textBoxEXELocation.TabIndex = 1;
            // 
            // buttonBrowseEXE
            // 
            this.buttonBrowseEXE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseEXE.Location = new System.Drawing.Point(599, 18);
            this.buttonBrowseEXE.Name = "buttonBrowseEXE";
            this.buttonBrowseEXE.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseEXE.TabIndex = 2;
            this.buttonBrowseEXE.Text = "Browse";
            this.buttonBrowseEXE.UseVisualStyleBackColor = true;
            this.buttonBrowseEXE.Click += new System.EventHandler(this.buttonBrowseEXE_Click);
            // 
            // buttonBrowseSave
            // 
            this.buttonBrowseSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseSave.Location = new System.Drawing.Point(599, 57);
            this.buttonBrowseSave.Name = "buttonBrowseSave";
            this.buttonBrowseSave.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseSave.TabIndex = 5;
            this.buttonBrowseSave.Text = "Browse";
            this.buttonBrowseSave.UseVisualStyleBackColor = true;
            this.buttonBrowseSave.Click += new System.EventHandler(this.buttonBrowseSave_Click);
            // 
            // textBoxSaveLocation
            // 
            this.textBoxSaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSaveLocation.Location = new System.Drawing.Point(1, 58);
            this.textBoxSaveLocation.Name = "textBoxSaveLocation";
            this.textBoxSaveLocation.Size = new System.Drawing.Size(593, 20);
            this.textBoxSaveLocation.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Save Location";
            // 
            // panelConfig
            // 
            this.panelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelConfig.Controls.Add(this.buttonBrowseServerConfig);
            this.panelConfig.Controls.Add(this.textBoxServerConfig);
            this.panelConfig.Controls.Add(this.label5);
            this.panelConfig.Controls.Add(this.buttonStartServer);
            this.panelConfig.Controls.Add(this.label4);
            this.panelConfig.Controls.Add(this.textBoxPort);
            this.panelConfig.Controls.Add(this.label3);
            this.panelConfig.Controls.Add(this.textBoxArgs);
            this.panelConfig.Controls.Add(this.label1);
            this.panelConfig.Controls.Add(this.buttonBrowseSave);
            this.panelConfig.Controls.Add(this.textBoxEXELocation);
            this.panelConfig.Controls.Add(this.textBoxSaveLocation);
            this.panelConfig.Controls.Add(this.buttonBrowseEXE);
            this.panelConfig.Controls.Add(this.label2);
            this.panelConfig.Location = new System.Drawing.Point(12, 12);
            this.panelConfig.Name = "panelConfig";
            this.panelConfig.Size = new System.Drawing.Size(674, 322);
            this.panelConfig.TabIndex = 6;
            // 
            // buttonBrowseServerConfig
            // 
            this.buttonBrowseServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseServerConfig.Location = new System.Drawing.Point(599, 96);
            this.buttonBrowseServerConfig.Name = "buttonBrowseServerConfig";
            this.buttonBrowseServerConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseServerConfig.TabIndex = 13;
            this.buttonBrowseServerConfig.Text = "Browse";
            this.buttonBrowseServerConfig.UseVisualStyleBackColor = true;
            this.buttonBrowseServerConfig.Click += new System.EventHandler(this.buttonBrowseServerConfig_Click);
            // 
            // textBoxServerConfig
            // 
            this.textBoxServerConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerConfig.Location = new System.Drawing.Point(1, 97);
            this.textBoxServerConfig.Name = "textBoxServerConfig";
            this.textBoxServerConfig.Size = new System.Drawing.Size(593, 20);
            this.textBoxServerConfig.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Server config";
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartServer.Location = new System.Drawing.Point(596, 291);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStartServer.TabIndex = 10;
            this.buttonStartServer.Text = "Start";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Port";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPort.Location = new System.Drawing.Point(69, 201);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(432, 20);
            this.textBoxPort.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Custom Args";
            // 
            // textBoxArgs
            // 
            this.textBoxArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArgs.Location = new System.Drawing.Point(69, 175);
            this.textBoxArgs.Name = "textBoxArgs";
            this.textBoxArgs.Size = new System.Drawing.Size(605, 20);
            this.textBoxArgs.TabIndex = 6;
            // 
            // panelServerUI
            // 
            this.panelServerUI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelServerUI.Controls.Add(this.exRichTextBoxCommandlog);
            this.panelServerUI.Controls.Add(this.listBoxPlayerList);
            this.panelServerUI.Controls.Add(this.textBoxServerCommand);
            this.panelServerUI.Controls.Add(this.richTextBoxChatLog);
            this.panelServerUI.Location = new System.Drawing.Point(12, 30);
            this.panelServerUI.Name = "panelServerUI";
            this.panelServerUI.Size = new System.Drawing.Size(674, 304);
            this.panelServerUI.TabIndex = 7;
            this.panelServerUI.Visible = false;
            // 
            // listBoxPlayerList
            // 
            this.listBoxPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPlayerList.FormattingEnabled = true;
            this.listBoxPlayerList.Location = new System.Drawing.Point(526, 0);
            this.listBoxPlayerList.Name = "listBoxPlayerList";
            this.listBoxPlayerList.Size = new System.Drawing.Size(145, 264);
            this.listBoxPlayerList.TabIndex = 2;
            this.listBoxPlayerList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxPlayerList_MouseDown);
            this.listBoxPlayerList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listBoxPlayerList_MouseUp);
            // 
            // textBoxServerCommand
            // 
            this.textBoxServerCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServerCommand.Location = new System.Drawing.Point(3, 284);
            this.textBoxServerCommand.Name = "textBoxServerCommand";
            this.textBoxServerCommand.Size = new System.Drawing.Size(668, 20);
            this.textBoxServerCommand.TabIndex = 1;
            this.textBoxServerCommand.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxServerCommand_KeyUp);
            // 
            // richTextBoxChatLog
            // 
            this.richTextBoxChatLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChatLog.AutoScrollToCarret = true;
            this.richTextBoxChatLog.HiglightColor = Leayal.Forms.RtfColor.White;
            this.richTextBoxChatLog.Location = new System.Drawing.Point(2, 0);
            this.richTextBoxChatLog.Name = "richTextBoxChatLog";
            this.richTextBoxChatLog.ReadOnly = true;
            this.richTextBoxChatLog.Size = new System.Drawing.Size(260, 278);
            this.richTextBoxChatLog.TabIndex = 0;
            this.richTextBoxChatLog.Text = "";
            this.richTextBoxChatLog.TextColor = Leayal.Forms.RtfColor.Black;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(440, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // serverToolStripMenuItem
            // 
            this.serverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.serverToolStripMenuItem.Name = "serverToolStripMenuItem";
            this.serverToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.serverToolStripMenuItem.Text = "Server";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // contextMenuStripPlayerList
            // 
            this.contextMenuStripPlayerList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whisperToolStripMenuItem,
            this.kickToolStripMenuItem,
            this.banToolStripMenuItem});
            this.contextMenuStripPlayerList.Name = "contextMenuStripPlayerList";
            this.contextMenuStripPlayerList.Size = new System.Drawing.Size(118, 70);
            // 
            // whisperToolStripMenuItem
            // 
            this.whisperToolStripMenuItem.Name = "whisperToolStripMenuItem";
            this.whisperToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.whisperToolStripMenuItem.Text = "Whisper";
            this.whisperToolStripMenuItem.Click += new System.EventHandler(this.whisperToolStripMenuItem_Click);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // banToolStripMenuItem
            // 
            this.banToolStripMenuItem.Name = "banToolStripMenuItem";
            this.banToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.banToolStripMenuItem.Text = "Ban";
            this.banToolStripMenuItem.Click += new System.EventHandler(this.banToolStripMenuItem_Click);
            // 
            // exRichTextBoxCommandlog
            // 
            this.exRichTextBoxCommandlog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exRichTextBoxCommandlog.AutoScrollToCarret = true;
            this.exRichTextBoxCommandlog.HiglightColor = Leayal.Forms.RtfColor.White;
            this.exRichTextBoxCommandlog.Location = new System.Drawing.Point(263, 0);
            this.exRichTextBoxCommandlog.Name = "exRichTextBoxCommandlog";
            this.exRichTextBoxCommandlog.ReadOnly = true;
            this.exRichTextBoxCommandlog.Size = new System.Drawing.Size(260, 278);
            this.exRichTextBoxCommandlog.TabIndex = 3;
            this.exRichTextBoxCommandlog.Text = "";
            this.exRichTextBoxCommandlog.TextColor = Leayal.Forms.RtfColor.Black;
            // 
            // MyMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 343);
            this.Controls.Add(this.panelServerUI);
            this.Controls.Add(this.panelConfig);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(456, 290);
            this.Name = "MyMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factorio Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MyMainMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyMainMenu_FormClosed);
            this.Load += new System.EventHandler(this.MyMainMenu_Load);
            this.panelConfig.ResumeLayout(false);
            this.panelConfig.PerformLayout();
            this.panelServerUI.ResumeLayout(false);
            this.panelServerUI.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripPlayerList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEXELocation;
        private System.Windows.Forms.Button buttonBrowseEXE;
        private System.Windows.Forms.Button buttonBrowseSave;
        private System.Windows.Forms.TextBox textBoxSaveLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxArgs;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Panel panelServerUI;
        private System.Windows.Forms.TextBox textBoxServerCommand;
        private Leayal.Forms.ExRichTextBox richTextBoxChatLog;
        private System.Windows.Forms.ListBox listBoxPlayerList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.Button buttonBrowseServerConfig;
        private System.Windows.Forms.TextBox textBoxServerConfig;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripPlayerList;
        private System.Windows.Forms.ToolStripMenuItem whisperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banToolStripMenuItem;
        private Leayal.Forms.ExRichTextBox exRichTextBoxCommandlog;
    }
}

