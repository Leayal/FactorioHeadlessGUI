using System;
using System.IO;
using System.Timers;

namespace FactorioHeadlessGUI.Classes
{
    public class FileWatcherSlim : IDisposable
    {
        private Timer myTimer;
        private FileInfo fi;

        public FileWatcherSlim(string filepath)
        {
            this.myTimer = new Timer(50d);
            this.fi = new FileInfo(filepath);
            this.myTimer.Elapsed += this.MyTimer_Elapsed;
            this.myTimer.AutoReset = true;            
        }

        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.fi.Refresh();
            if (this.initial_Exists != this.fi.Exists)
            {
                this.initial_Exists = this.fi.Exists;
                if (this.initial_Exists)
                    this.OnCreated(EventArgs.Empty);
                else
                    this.OnDeleted(EventArgs.Empty);
            }
            else
            {
                if (this.initial_Length != this.fi.Length || this.initial_LastWriteTime != this.fi.LastWriteTime)
                {
                    this.initial_Length = this.fi.Length;
                    this.initial_LastWriteTime = this.fi.LastWriteTime;
                    this.OnChanged(EventArgs.Empty);
                }
            }
        }

        public event EventHandler Changed;
        protected virtual void OnChanged(EventArgs e)
        {
            this.Changed?.Invoke(this, e);
        }

        public event EventHandler Deleted;
        protected virtual void OnDeleted(EventArgs e)
        {
            this.Deleted?.Invoke(this, e);
        }

        public event EventHandler Created;
        protected virtual void OnCreated(EventArgs e)
        {
            this.Created?.Invoke(this, e);
        }

        public bool Enabled => this.myTimer.Enabled;

        private bool initial_Exists;
        private long initial_Length;
        private DateTime initial_LastWriteTime;

        public void Start()
        {
            this.fi.Refresh();
            this.initial_Exists = this.fi.Exists;
            this.initial_Length = this.fi.Length;
            this.initial_LastWriteTime = this.fi.LastWriteTime;
            this.myTimer.Start();
        }

        public void Stop()
        {
            this.myTimer.Stop();
        }

        public void Dispose()
        {
            if (this.myTimer != null)
                this.myTimer.Dispose();
        }
    }
}
