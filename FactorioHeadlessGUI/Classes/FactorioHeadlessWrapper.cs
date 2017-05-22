using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Leayal;
using System.IO;
using System.ComponentModel;

namespace FactorioHeadlessGUI.Classes
{
    class FactorioHeadlessWrapper : IDisposable
    {
#region "Quick Contrustor"
        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string configfile, string serversettingfile, int port, bool verbose)
        {
            List<string> paramList = new List<string>();
            
            paramList.Add("-c");
            paramList.Add(configfile);
            paramList.Add("--server-settings");
            paramList.Add(serversettingfile);
            paramList.Add("--port");
            paramList.Add(port.ToString());
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string configfile, string serversettingfile, int port, bool verbose, params string[] args)
        {
            List<string> paramList = new List<string>(args);
            
            int index = paramList.IndexOf("--port");
            if (index > -1)
            {
                paramList[index] = "--port";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = port.ToString();
                else
                    paramList.Add(port.ToString());
            }
            else
            {
                paramList.Add("--port");
                paramList.Add(port.ToString());
            }

            index = paramList.IndexOf("--server-settings");
            if (index > -1)
            {
                paramList[index] = "--server-settings";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = serversettingfile;
                else
                    paramList.Add(serversettingfile);
            }
            else
            {
                paramList.Add("--server-settings");
                paramList.Add(serversettingfile);
            }

            index = paramList.IndexOf("-c");
            if (index > -1)
            {
                paramList[index] = "-c";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = configfile;
                else
                    paramList.Add(configfile);
            }
            else
            {
                paramList.Add("-c");
                paramList.Add(configfile);
            }
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string configfile, string serversettingfile)
        {
            List<string> paramList = new List<string>();

            paramList.Add("-c");
            paramList.Add(configfile);
            paramList.Add("--server-settings");
            paramList.Add(serversettingfile);
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = false };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string configfile, string serversettingfile, params string[] args)
        {
            List<string> paramList = new List<string>(args);

            int index = paramList.IndexOf("--server-settings");
            if (index > -1)
            {
                paramList[index] = "--server-settings";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = serversettingfile;
                else
                    paramList.Add(serversettingfile);
            }
            else
            {
                paramList.Add("--server-settings");
                paramList.Add(serversettingfile);
            }

            index = paramList.IndexOf("-c");
            if (index > -1)
            {
                paramList[index] = "-c";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = configfile;
                else
                    paramList.Add(configfile);
            }
            else
            {
                paramList.Add("-c");
                paramList.Add(configfile);
            }
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = false };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string serversettingfile, int port, bool verbose)
        {
            List<string> paramList = new List<string>();
            
            paramList.Add("--server-settings");
            paramList.Add(serversettingfile);
            paramList.Add("--port");
            paramList.Add(port.ToString());
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, string serversettingfile, int port, bool verbose, params string[] args)
        {
            List<string> paramList = new List<string>(args);
            
            int index = paramList.IndexOf("--port");
            if (index > -1)
            {
                paramList[index] = "--port";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = port.ToString();
                else
                    paramList.Add(port.ToString());
            }
            else
            {
                paramList.Add("--port");
                paramList.Add(port.ToString());
            }

            index = paramList.IndexOf("--server-settings");
            if (index > -1)
            {
                paramList[index] = "--server-settings";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = serversettingfile;
                else
                    paramList.Add(serversettingfile);
            }
            else
            {
                paramList.Add("--server-settings");
                paramList.Add(serversettingfile);
            }
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, int port, bool verbose)
        {
            List<string> paramList = new List<string>();
            
            paramList.Add("--port");
            paramList.Add(port.ToString());
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, int port, bool verbose, params string[] args)
        {
            List<string> paramList = new List<string>(args);
            
            int index = paramList.IndexOf("--port");
            if (index > -1)
            {
                paramList[index] = "--port";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = port.ToString();
                else
                    paramList.Add(port.ToString());
            }
            else
            {
                paramList.Add("--port");
                paramList.Add(port.ToString());
            }
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList) { Verbose = verbose };
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, int port)
        {
            List<string> paramList = new List<string>();
            
            paramList.Add("--port");
            paramList.Add(port.ToString());
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList);
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath, int port, params string[] args)
        {
            List<string> paramList = new List<string>(args);
            
            int index = paramList.IndexOf("--port");
            if (index > -1)
            {
                paramList[index] = "--port";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = port.ToString();
                else
                    paramList.Add(port.ToString());
            }
            else
            {
                paramList.Add("--port");
                paramList.Add(port.ToString());
            }
            return new FactorioHeadlessWrapper(executable, savefilepath, paramList);
        }

        public static FactorioHeadlessWrapper FromSaveFile(string executable, string savefilepath)
        {
            return new FactorioHeadlessWrapper(executable, savefilepath);
        }
        #endregion

        FileWatcherSlim fsw;
        Process myProcess;
        ProcessStartInfo procInfo;
        StreamWriter inputStream;
        SynchronizationContext synccontext;
        private ConcurrentDictionary<string, UserInfo> _userlist;

        private static char[] spaceonly = { ' ' };

        public FactorioHeadlessWrapper(string executable, string savefilepath, IEnumerable<string> args) : this(executable, savefilepath, Leayal.ProcessHelper.TableStringToArgs(args)) { }
        public FactorioHeadlessWrapper(string executable, string savefilepath, params string[] args) : this(executable, savefilepath, Leayal.ProcessHelper.TableStringToArgs(args)) { }
        public FactorioHeadlessWrapper(string executable, string savefilepath) : this(executable, savefilepath, string.Empty) { }
        public FactorioHeadlessWrapper(string executable, string savefilepath, string args)
        {
            List<string> paramList = new List<string>();

            int index = paramList.IndexOf("--start-server");
            if (index > -1)
            {
                paramList[index] = "--start-server";
                if (index < (paramList.Count - 1))
                    paramList[index + 1] = savefilepath;
                else
                    paramList.Add(savefilepath);
            }
            else
            {
                paramList.Add("--start-server");
                paramList.Add(savefilepath);
            }

            this.GameSaveLocation = savefilepath;

            this.synccontext = SynchronizationContext.Current;
            this._userlist = new ConcurrentDictionary<string, UserInfo>(StringComparer.OrdinalIgnoreCase);
            this.procInfo = new ProcessStartInfo(executable);
            if (!string.IsNullOrWhiteSpace(args))
                this.procInfo.Arguments = ProcessHelper.TableStringToArgs(paramList) + " " + args;
            this.procInfo.UseShellExecute = false;
            this.procInfo.RedirectStandardInput = true;
            this.procInfo.StandardErrorEncoding = Encoding.UTF8;
            this.procInfo.StandardOutputEncoding = Encoding.UTF8;
            this.procInfo.RedirectStandardOutput = true;
            this.procInfo.RedirectStandardError = true;
            this.procInfo.ErrorDialog = true;
            this.procInfo.CreateNoWindow = false;//*/

            this.fsw = null;
            /*this.fsw = new FileWatcherSlim(this.GameSaveLocation);
            this.fsw.Changed += this.Fsw_Changed;
            this.fsw.Created += this.Fsw_Created;//*/
        }

        public string GameSaveLocation { get; }

        public bool IsRunning
        {
            get
            {
                if (this.myProcess == null || this.myProcess.HasExited)
                    return false;
                else
                    return true;
            }
        }

        public UserInfo GetUserInfo(string playerid)
        {
            if (this._userlist.TryGetValue(playerid, out var value))
                return value;
            return null;
        }

        public bool Verbose
        {
            get
            {
                if (procInfo.Arguments.Split(spaceonly, StringSplitOptions.RemoveEmptyEntries).Contains("-v"))
                    return true;
                else
                    return false;
            }
            set
            {
                if (this.myProcess != null && !this.myProcess.HasExited) throw new Exception("Server is already running. This property can only set before the server started.");
                if (value)
                {
                    if (!this.Verbose)
                        procInfo.Arguments = "-v " + procInfo.Arguments;
                }
                else
                {
                    if (this.Verbose)
                    {
                        if (procInfo.Arguments.EndsWith(" -v"))
                            procInfo.Arguments = procInfo.Arguments.Remove(procInfo.Arguments.Length - 3, 3);
                        else
                            procInfo.Arguments = procInfo.Arguments.Replace("-v ", "");
                    }
                }
            }
        }

        public void StartServer()
        {
            if (myProcess != null && !myProcess.HasExited) return;
            myProcess = new Process();
            myProcess.StartInfo = this.procInfo;
            myProcess.EnableRaisingEvents = true;
            myProcess.Exited += MyProcess_Exited;
            myProcess.OutputDataReceived += MyProcess_OutputDataReceived;
            myProcess.ErrorDataReceived += MyProcess_OutputDataReceived;
            myProcess.Start();
            myProcess.BeginOutputReadLine();
            myProcess.BeginErrorReadLine();
            this.inputStream = new StreamWriter(myProcess.StandardInput.BaseStream, new UTF8Encoding(false));
            this._userlist.Clear();
            this.OnServerStarted(EventArgs.Empty);
        }

        public void SaveAsync()
        {
            this.OnGameSaving(EventArgs.Empty);
            this.SendData("/silent-command game.server_save()");
        }

        public void SaveAsAsync(string path)
        {
            this.OnGameSaving(EventArgs.Empty);
            this.SendData($"/silent-command game.server_save('{path}')");
        }

        public void Kick(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID)) return;
            this.SendData($"/kick {playerID}");
        }

        public void Ban(string playerID)
        {
            if (string.IsNullOrWhiteSpace(playerID)) return;
            this.SendData($"/ban {playerID}");
        }

        public void SendData(string data)
        {
            if (myProcess == null || myProcess.HasExited) return;
            if (this.inputStream != null)
            {
                this.inputStream.WriteLine(data);
                this.inputStream.Flush();
            }
        }

        private bool pendingShutdown = false;
        public void StopServer()
        {
            if (this.myProcess == null || this.myProcess.HasExited) return;
            if (pendingShutdown) return;
            ServerStoppingEventArgs myevent = new ServerStoppingEventArgs();
            this.OnServerStopping(myevent);
            if (myevent.Cancel) return;

            pendingShutdown = true;
            // Save the game
            this.SaveAsync();
            // this.inputStream.Dispose();
        }

        private void MyProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e == null || string.IsNullOrEmpty(e.Data)) return;
            //System.Windows.Forms.MessageBox.Show(e.Data);
            string[] splitteddata = e.Data.Split(spaceonly, StringSplitOptions.RemoveEmptyEntries);
            if (splitteddata.Length == 0) return;
            try
            {
                if (splitteddata[1] == "Verbose")
                {
                    if (splitteddata[3] == "Saving")
                    {
                        this.OnGameSaved(EventArgs.Empty);
                    }
                    else
                        this.OnVerboseLog(new VerboseLogEventArgs(e.Data));
                }
                else if (splitteddata[1] == "Info")
                {
                    if (e.Data.Contains("mapTick(") && e.Data.Contains("Changing state from(Disconnected) to(Closed)"))
                    {
                        if (!this.myProcess.HasExited)
                        {
                            this.myProcess.CancelOutputRead();
                            this.myProcess.CloseMainWindow();
                            this.myProcess.WaitForExit(100);
                            if (!this.myProcess.HasExited)
                                this.myProcess.Kill();
                        }
                    }
                    else
                        this.OnVerboseLog(new VerboseLogEventArgs(e.Data));
                }
                else if (splitteddata[1] == "Error")
                {
                    this.OnErrorRaised(new ErrorEventArgs(new Exception(e.Data)));
                }
                else if (splitteddata[1] == "Goodbye")
                {
                    if (!this.myProcess.HasExited)
                    {
                        this.myProcess.CancelOutputRead();
                        this.myProcess.CloseMainWindow();
                        this.myProcess.WaitForExit(100);
                        if (!this.myProcess.HasExited)
                            this.myProcess.Kill();
                    }
                }
                else
                {
                    if (splitteddata.Length > 1)
                    {
                        if (splitteddata[2].IsEqual("[LEAVE]", true))
                        {
                            if (this._userlist.TryRemove(splitteddata[3], out var dundun))
                                this.OnPlayerLeft(new PlayerEventArgs(dundun));
                        }
                        else if (splitteddata[2].IsEqual("[JOIN]", true))
                        {
                            UserInfo dudududud = new UserInfo(splitteddata[3]);
                            if (this._userlist.TryAdd(splitteddata[3], dudududud))
                                this.OnPlayerJoined(new PlayerEventArgs(dudududud));
                        }
                        else if (splitteddata[2].IsEqual("[KICK]", true))
                        {
                            UserInfo dudududud = new UserInfo(splitteddata[3]);
                            if (this._userlist.TryRemove(splitteddata[3], out var dundun))
                            {
                                string kicker = splitteddata[7].EndsWith(".") ? splitteddata[7].Remove(splitteddata[7].Length -1, 1) : splitteddata[7];
                                if (kicker.IsEqual("<server>", true))
                                {
                                    this.OnPlayerKicked(new PlayerKickedEventArgs(null, dundun, e.Data.Substring(e.Data.IndexOf(". Reason:") + ". Reason:".Length).TrimStart()));
                                }
                                else
                                {
                                    if (this._userlist.TryGetValue(kicker, out var kickerInfo))
                                        this.OnPlayerKicked(new PlayerKickedEventArgs(kickerInfo, dundun, e.Data.Substring(e.Data.IndexOf(". Reason:") + ". Reason:".Length).TrimStart()));
                                }
                            }
                        }
                        else if (splitteddata[2].IsEqual("[BAN]", true))
                        {
                            UserInfo dudududud = new UserInfo(splitteddata[3]);
                            if (this._userlist.TryRemove(splitteddata[3], out var dundun))
                            {
                                string kicker = splitteddata[7].EndsWith(".") ? splitteddata[7].Remove(splitteddata[7].Length - 1, 1) : splitteddata[7];
                                if (kicker.IsEqual("<server>", true))
                                {
                                    this.OnPlayerBanned(new PlayerBannedEventArgs(null, dundun, e.Data.Substring(e.Data.IndexOf(". Reason:") + ". Reason:".Length).TrimStart()));
                                }
                                else
                                {
                                    if (this._userlist.TryGetValue(kicker, out var kickerInfo))
                                        this.OnPlayerBanned(new PlayerBannedEventArgs(kickerInfo, dundun, e.Data.Substring(e.Data.IndexOf(". Reason:") + ". Reason:".Length).TrimStart()));
                                }
                            }
                        }
                        else if (splitteddata[2].IsEqual("[CHAT]", true))
                        {
                            if (splitteddata[3].EndsWith(":"))
                                splitteddata[3] = splitteddata[3].Substring(0, splitteddata[3].Length - 1);
                            if (this._userlist.TryGetValue(splitteddata[3], out var msgSender))
                            {
                                StringBuilder sb = new StringBuilder(e.Data.Length);
                                for (int i = 4; i < splitteddata.Length; i++)
                                {
                                    if (i == 4)
                                        sb.Append(splitteddata[i]);
                                    else
                                        sb.Append(" " + splitteddata[i]);
                                }
                                this.OnChatMessageArrived(new ChatMessageArrivedEventArgs(msgSender, sb.ToString()));
                            }
                        }
                        else
                            this.OnVerboseLog(new VerboseLogEventArgs(e.Data));
                    }
                    else
                        this.OnVerboseLog(new VerboseLogEventArgs(e.Data));
                }
            }
            catch (IndexOutOfRangeException)
            {
                this.OnVerboseLog(new VerboseLogEventArgs(e.Data));
            }
        }

        private void MyProcess_Exited(object sender, EventArgs e)
        {
            myProcess.OutputDataReceived -= MyProcess_OutputDataReceived;
            myProcess.ErrorDataReceived -= MyProcess_OutputDataReceived;
            if (this.inputStream != null)
            {
                this.inputStream.Dispose();
                this.inputStream = null;
            }
            this.OnServerStopped(e);
            myProcess.Dispose();
            myProcess = null;
        }

        public event EventHandler GameSaving;
        protected virtual void OnGameSaving(EventArgs e)
        {
            if (this.GameSaving != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.GameSaving.Invoke(this, e); }), null);
            if (this.fsw == null || string.IsNullOrWhiteSpace(this.GameSaveLocation))
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(delegate
                {
                    Thread.Sleep(3000);
                    this.OnGameSaved(EventArgs.Empty);
                }));
            }
            else
            {
                this.fsw.Start();
            }
        }

        private void Fsw_Created(object sender, EventArgs e)
        {
            this.fsw.Stop();
            this.OnGameSaved(EventArgs.Empty);
        }

        private void Fsw_Changed(object sender, EventArgs e)
        {
            this.fsw.Stop();
            this.OnGameSaved(EventArgs.Empty);
        }

        public event EventHandler GameSaved;
        protected virtual void OnGameSaved(EventArgs e)
        {
            if (this.GameSaved != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.GameSaved.Invoke(this, e); }), null);

            if (pendingShutdown)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                {
                    Methods.Common.SendSIGINT(this.myProcess);
                    this.myProcess.CancelOutputRead();
                    this.myProcess.CancelErrorRead();

                    this.myProcess.CloseMainWindow();
                    this.myProcess.WaitForExit(2000);
                    if (!this.myProcess.HasExited)
                        this.myProcess.Kill();
                }));
            }
        }

        public event EventHandler<VerboseLogEventArgs> VerboseLog;
        protected virtual void OnVerboseLog(VerboseLogEventArgs e)
        {
            if (this.VerboseLog != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.VerboseLog.Invoke(this, e); }), null);
        }

        public event EventHandler<PlayerEventArgs> PlayerJoined;
        protected virtual void OnPlayerJoined(PlayerEventArgs e)
        {
            if (this.PlayerJoined != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.PlayerJoined.Invoke(this, e); }), null);
        }

        public event EventHandler<PlayerBannedEventArgs> PlayerBanned;
        protected virtual void OnPlayerBanned(PlayerBannedEventArgs e)
        {
            if (this.PlayerBanned != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.PlayerBanned.Invoke(this, e); }), null);
        }

        public event EventHandler<PlayerKickedEventArgs> PlayerKicked;
        protected virtual void OnPlayerKicked(PlayerKickedEventArgs e)
        {
            if (this.PlayerKicked != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.PlayerKicked.Invoke(this, e); }), null);
        }

        public event EventHandler<ServerStoppingEventArgs> ServerStopping;
        protected virtual void OnServerStopping(ServerStoppingEventArgs e)
        {
            if (this.ServerStopping != null)
                this.synccontext?.Send(new SendOrPostCallback(delegate { this.ServerStopping.Invoke(this, e); }), null);
        }

        public event EventHandler ServerStopped;
        protected virtual void OnServerStopped(EventArgs e)
        {
            if (this.ServerStopped != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.ServerStopped.Invoke(this, e); }), null);
        }

        public event EventHandler<PlayerEventArgs> PlayerLeft;
        protected virtual void OnPlayerLeft(PlayerEventArgs e)
        {
            if (this.PlayerLeft != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.PlayerLeft.Invoke(this, e); }), null);
        }

        public event EventHandler<ChatMessageArrivedEventArgs> ChatMessageArrived;
        protected virtual void OnChatMessageArrived(ChatMessageArrivedEventArgs e)
        {
            if (this.ChatMessageArrived != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.ChatMessageArrived.Invoke(this, e); }), null);
        }

        public event EventHandler<ErrorEventArgs> ErrorRaised;
        protected virtual void OnErrorRaised(ErrorEventArgs e)
        {
            if (this.ErrorRaised != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.ErrorRaised.Invoke(this, e); }), null);
        }

        public event EventHandler ServerStarted;
        protected virtual void OnServerStarted(EventArgs e)
        {
            if (this.ServerStarted != null)
                this.synccontext?.Post(new SendOrPostCallback(delegate { this.ServerStarted.Invoke(this, e); }), null);
        }

        public void Dispose()
        {
            if (this.fsw != null)
                this.fsw.Dispose();
            if (this.myProcess != null)
            {
                if (!this.myProcess.HasExited)
                    this.myProcess.Kill();
                this.Dispose();
            }
        }
    }
}
