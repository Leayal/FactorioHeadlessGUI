using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Leayal.Ini;

namespace FactorioHeadlessGUI
{
    public partial class MyMainMenu : Form
    {
        private IniFile config;
        private Classes.FactorioHeadlessWrapper server;
        private Classes.CommandLog cmdLog;

        public MyMainMenu() : this("FactorioHeadlessGUI.ini") { }

        public MyMainMenu(string configfile)
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(configfile))
                configfile = "FactorioHeadlessGUI.ini";
            this.config = new IniFile(configfile);
            this.cmdLog = new Classes.CommandLog();
        }

        private void MyMainMenu_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.factorio_lbv_icon;
            this.textBoxEXELocation.Text = this.config.GetValue("Executable", "Path", string.Empty);
            this.textBoxSaveLocation.Text = this.config.GetValue("Server", "Save", string.Empty);
            this.textBoxArgs.Text = this.config.GetValue("Executable", "Args", string.Empty);
            this.textBoxPort.Text = this.config.GetValue("Server", "Port", string.Empty);
            this.textBoxServerConfig.Text = this.config.GetValue("Server", "ServerSetting", string.Empty);
        }

        private bool pendingClose = false;
        private void MyMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
                if (server.IsRunning)
                {
                    e.Cancel = true;
                    pendingClose = true;
                    server.StopServer();
                }
        }

        private void MyMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.config.SetValue("Executable", "Path", this.textBoxEXELocation.Text);
            this.config.SetValue("Server", "Save", this.textBoxSaveLocation.Text);
            this.config.SetValue("Executable", "Args", this.textBoxArgs.Text);
            this.config.SetValue("Server", "Port", this.textBoxPort.Text);
            this.config.SetValue("Server", "ServerSetting", this.textBoxServerConfig.Text);
            this.config.Save();
        }

        private void buttonBrowseEXE_Click(object sender, EventArgs e)
        {
            if (this.textBoxEXELocation.ReadOnly) return;
            using (OpenFileDialog _fileopendialog = new OpenFileDialog())
            {
                _fileopendialog.CheckFileExists = true;
                _fileopendialog.CheckPathExists = true;
                _fileopendialog.DefaultExt = "exe";
                if (!string.IsNullOrWhiteSpace(this.textBoxEXELocation.Text) && File.Exists(this.textBoxEXELocation.Text))
                    _fileopendialog.FileName = this.textBoxEXELocation.Text;
                else
                    _fileopendialog.FileName = "factorio.exe";
                _fileopendialog.Title = "Select Factorio executable file";
                _fileopendialog.RestoreDirectory = true;
                _fileopendialog.Multiselect = false;
                _fileopendialog.Filter = "Factorio Executable|factorio.exe";
                if (_fileopendialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.textBoxEXELocation.Text = _fileopendialog.FileName;
                    if (string.IsNullOrWhiteSpace(this.textBoxServerConfig.Text))
                    {
                        string serversettingsFolder = Path.Combine(Microsoft.VisualBasic.FileIO.FileSystem.GetParentPath(_fileopendialog.FileName), "..", "..", "data"),
                            serversetting = Path.Combine(serversettingsFolder, "server-settings.json");
                        if (File.Exists(serversetting))
                            this.textBoxServerConfig.Text = Path.GetFullPath(serversetting);
                        else
                        {
                            serversetting = Path.Combine(serversettingsFolder, "server-settings.example.json");
                            if (File.Exists(serversetting))
                                this.textBoxServerConfig.Text = Path.GetFullPath(serversetting);
                        }
                    }
                }
            }
        }

        private void buttonBrowseSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxSaveLocation.ReadOnly) return;
            using (OpenFileDialog _fileopendialog = new OpenFileDialog())
            {
                _fileopendialog.CheckFileExists = true;
                _fileopendialog.CheckPathExists = true;
                _fileopendialog.DefaultExt = "zip";
                if (!string.IsNullOrWhiteSpace(this.textBoxSaveLocation.Text) && File.Exists(this.textBoxSaveLocation.Text))
                    _fileopendialog.FileName = this.textBoxSaveLocation.Text;
                _fileopendialog.Title = "Select Factorio save file";
                _fileopendialog.RestoreDirectory = true;
                _fileopendialog.Multiselect = false;
                _fileopendialog.Filter = "Factorio Save|*.zip";
                if (_fileopendialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.textBoxSaveLocation.Text = _fileopendialog.FileName;
                }
            }
        }

        private void buttonBrowseServerConfig_Click(object sender, EventArgs e)
        {
            if (this.textBoxServerConfig.ReadOnly) return;
            using (OpenFileDialog _fileopendialog = new OpenFileDialog())
            {
                _fileopendialog.CheckFileExists = true;
                _fileopendialog.CheckPathExists = true;
                _fileopendialog.DefaultExt = "json";
                if (!string.IsNullOrWhiteSpace(this.textBoxServerConfig.Text) && File.Exists(this.textBoxServerConfig.Text))
                    _fileopendialog.FileName = this.textBoxServerConfig.Text;
                _fileopendialog.Title = "Select Factorio Server setting file";
                _fileopendialog.RestoreDirectory = true;
                _fileopendialog.Multiselect = false;
                _fileopendialog.Filter = "Factorio Server Setting|*.json";
                if (_fileopendialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.textBoxServerConfig.Text = _fileopendialog.FileName;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.server != null) return;
            if (!File.Exists(this.textBoxEXELocation.Text) && !File.Exists(this.textBoxSaveLocation.Text) && !File.Exists(this.textBoxServerConfig.Text)) return;
            this.richTextBoxChatLog.Clear();
            //C:\Users\Dramiel Leayal\AppData\Roaming\Factorio\config
            string clientConfigFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Factorio", "config"),
                sha1digest = Leayal.Security.Cryptography.SHA1Wrapper.FromString(this.textBoxSaveLocation.Text.ToLower()),
                serverConfigPath = Path.Combine(clientConfigFolderPath, $"config-server-{sha1digest}.ini");

            IniFile _inifile = new IniFile(Path.Combine(clientConfigFolderPath, "config.ini"), new IniReadErrorEventHandler((x, y) => { if (y.Error != null) MessageBox.Show(y.Error.ToString()); }));
            _inifile.SetValue("path", "write-data", "__PATH__system-write-data__/server/" + sha1digest);
            using (StreamWriter sw = new StreamWriter(serverConfigPath, false, System.Text.Encoding.ASCII))
            {
                sw.WriteLine("; version=2");
                _inifile.SaveAs(sw);
            }
            
            if (!string.IsNullOrWhiteSpace(this.textBoxPort.Text) && Leayal.NumberHelper.TryParse(this.textBoxPort.Text, out var port))
            {
                this.server = Classes.FactorioHeadlessWrapper.FromSaveFile(this.textBoxEXELocation.Text, this.textBoxSaveLocation.Text, serverConfigPath, this.textBoxServerConfig.Text, port, false);
                this.exRichTextBoxCommandlog.Text = $"  [SYS] Server is started and is listening on port {port}.";
                this.richTextBoxChatLog.Text = $"  [SYS] Server is started and is listening on port {port}.";
            }
            else
            {
                this.exRichTextBoxCommandlog.Text = "  [SYS] Server is started and is listening on default port.";
                this.richTextBoxChatLog.Text = "  [SYS] Server is started and is listening on default port.";
                this.server = Classes.FactorioHeadlessWrapper.FromSaveFile(this.textBoxEXELocation.Text, this.textBoxSaveLocation.Text, serverConfigPath, this.textBoxServerConfig.Text);
            }
            _inifile.Close();
            this.server.VerboseLog += this.Server_VerboseLog;
            this.server.GameSaved += this.Server_GameSaved;
            this.server.ChatMessageArrived += this.Server_ChatMessageArrived;
            this.server.ErrorRaised += this.Server_ErrorRaised;
            this.server.PlayerJoined += this.Server_PlayerJoined;
            this.server.PlayerLeft += this.Server_PlayerLeft;
            this.server.ServerStarted += this.Server_ServerStarted;
            this.server.ServerStopping += this.Server_ServerStopping;
            this.server.ServerStopped += this.Server_ServerStopped;
            this.server.GameSaving += this.Server_GameSaving;
            this.server.PlayerBanned += this.Server_PlayerBanned;
            this.server.PlayerKicked += this.Server_PlayerKicked;
            this.server.StartServer();
        }

        #region "Server codes"
        private void Server_ServerStopping(object sender, Classes.ServerStoppingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to shut down the server???\n(This will kill the server without saving. Besure to make the gamesave before shutting down)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.textBoxServerCommand.Enabled = false;
                this.exRichTextBoxCommandlog.AppendText("  [SYS] Shutting down server....");
            }
            else
                e.Cancel = true;
        }

        private void Server_GameSaved(object sender, EventArgs e)
        {
            this.exRichTextBoxCommandlog.AppendText("  [SERVER] Game Saved!!!!", Leayal.Forms.RtfColor.Green);
        }

        private void Server_ErrorRaised(object sender, ErrorEventArgs e)
        {
            this.exRichTextBoxCommandlog.AppendText($"  [Error] {e.GetException().Message}", Leayal.Forms.RtfColor.Red);
        }

        private void Server_VerboseLog(object sender, Classes.VerboseLogEventArgs e)
        {
            this.exRichTextBoxCommandlog.AppendText($"  [LOG] {e.Log}", Leayal.Forms.RtfColor.Green);
        }

        private void Server_ChatMessageArrived(object sender, Classes.ChatMessageArrivedEventArgs e)
        {
            this.richTextBoxChatLog.AppendText($"  [CHAT] {e.PlayerInfo.PlayerID}: {e.Message}", Leayal.Forms.RtfColor.Black);
        }

        private void Server_PlayerLeft(object sender, Classes.PlayerEventArgs e)
        {
            this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.PlayerInfo.PlayerID} left the server.", Leayal.Forms.RtfColor.Green);
            if (this.listBoxPlayerList.Items.IndexOf(e.PlayerInfo.PlayerID) > -1)
                this.listBoxPlayerList.Items.Remove(e.PlayerInfo.PlayerID);
        }

        private void Server_PlayerJoined(object sender, Classes.PlayerEventArgs e)
        {
            this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.PlayerInfo.PlayerID} has joined the server.", Leayal.Forms.RtfColor.Green);
            if (this.listBoxPlayerList.Items.IndexOf(e.PlayerInfo.PlayerID) == -1)
                this.listBoxPlayerList.Items.Add(e.PlayerInfo.PlayerID);
        }

        private void Server_PlayerKicked(object sender, Classes.PlayerKickedEventArgs e)
        {
            if (e.Sender==null)
                this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.Target.PlayerID} was kicked by the server. Reason: {e.Reason}", Leayal.Forms.RtfColor.Green);
            else
                this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.Target.PlayerID} was kicked by '{e.Sender.PlayerID}'. Reason: {e.Reason}", Leayal.Forms.RtfColor.Green);
            if (this.listBoxPlayerList.Items.IndexOf(e.Target.PlayerID) > -1)
                this.listBoxPlayerList.Items.Remove(e.Target.PlayerID);
        }

        private void Server_PlayerBanned(object sender, Classes.PlayerBannedEventArgs e)
        {
            if (e.Sender == null)
                this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.Target.PlayerID} was banned by the server. Reason: {e.Reason}", Leayal.Forms.RtfColor.Green);
            else
                this.exRichTextBoxCommandlog.AppendText($"  [SERVER] {e.Target.PlayerID} was banned by '{e.Sender.PlayerID}'. Reason: {e.Reason}", Leayal.Forms.RtfColor.Green);
            if (this.listBoxPlayerList.Items.IndexOf(e.Target.PlayerID) > -1)
                this.listBoxPlayerList.Items.Remove(e.Target.PlayerID);
        }

        private void Server_GameSaving(object sender, EventArgs e)
        {
            if (this.server == null || string.IsNullOrWhiteSpace(this.server.GameSaveLocation)) return;
            this.exRichTextBoxCommandlog.AppendText("  [SERVER] Saving game....", Leayal.Forms.RtfColor.Green);
        }

        private void Server_ServerStopped(object sender, EventArgs e)
        {
            this.Text = "Factorio Server";
            this.menuStrip1.Visible = false;
            this.panelServerUI.Visible = false;
            this.panelConfig.Visible = true;
            this.server = null;
            if (this.pendingClose)
                this.Close();
        }

        private void Server_ServerStarted(object sender, EventArgs e)
        {
            // Clear command log when server started ????
            // this.cmdLog.Clear();
            this.Text = "Factorio Server: " + Path.GetFileNameWithoutExtension(this.textBoxSaveLocation.Text);
            this.listBoxPlayerList.Items.Clear();
            this.menuStrip1.Visible = true;
            this.textBoxServerCommand.ResetText();
            this.textBoxServerCommand.Enabled = true;
            this.panelServerUI.Visible = true;
            this.panelConfig.Visible = false;
        }

        private void textBoxServerCommand_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.server == null || !this.server.IsRunning) return;
            if (!e.Alt && !e.Control)
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (this.textBoxServerCommand.Enabled)
                        {
                            this.server.SendData(this.textBoxServerCommand.Text);
                            this.cmdLog.Log(this.textBoxServerCommand.Text);
                            if (!this.textBoxServerCommand.Text.StartsWith("/"))
                                this.richTextBoxChatLog.AppendText($"  [CHAT] Server: {this.textBoxServerCommand.Text}");
                            this.textBoxServerCommand.ResetText();
                            this.cmdLog.ResetPosition();
                        }
                        break;
                    case Keys.Up:
                        var nextLog = this.cmdLog.GetNext();
                        if (nextLog != null)
                        {
                            this.textBoxServerCommand.Text = nextLog;
                            if (!string.IsNullOrEmpty(this.textBoxServerCommand.Text))
                                this.textBoxServerCommand.SelectionStart = this.textBoxServerCommand.Text.Length;
                        }
                        break;
                    case Keys.Down:
                        var prevLog = this.cmdLog.GetPrevious();
                        if (prevLog != null)
                        {
                            this.textBoxServerCommand.Text = prevLog;
                            if (!string.IsNullOrEmpty(this.textBoxServerCommand.Text))
                                this.textBoxServerCommand.SelectionStart = this.textBoxServerCommand.Text.Length;
                        }
                        break;
                }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.server == null || !this.server.IsRunning) return;
            this.server.StopServer();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.server == null || !this.server.IsRunning) return;
            this.server.SaveAsync();
        }

        private void listBoxPlayerList_MouseUp(object sender, MouseEventArgs e)
        {
            if (listBoxPlayerList.SelectedIndex == -1) return;
            switch (e.Button)
            {
                case MouseButtons.Right:
                    this.contextMenuStripPlayerList.Show(this.listBoxPlayerList, e.Location);
                    break;
            }
        }

        private void whisperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.server == null || listBoxPlayerList.SelectedIndex == -1) return;
            string prefix = $"/whisper {this.listBoxPlayerList.SelectedItem}";
            if (!string.IsNullOrWhiteSpace(this.textBoxServerCommand.Text))
                if (this.textBoxServerCommand.Text.ToLower().StartsWith(prefix.ToLower()))
                    return;
            this.textBoxServerCommand.Text = prefix;
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.server == null || listBoxPlayerList.SelectedIndex == -1) return;
            this.server.Ban((string)listBoxPlayerList.SelectedItem);
        }

        private void kickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.server == null || listBoxPlayerList.SelectedIndex == -1) return;
            this.server.Kick((string)listBoxPlayerList.SelectedItem);
        }

        private void listBoxPlayerList_MouseDown(object sender, MouseEventArgs e)
        {
            listBoxPlayerList.SelectedIndex = listBoxPlayerList.IndexFromPoint(e.Location);
        }
        #endregion
    }
}
