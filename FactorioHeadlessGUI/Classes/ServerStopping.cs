using System;

namespace FactorioHeadlessGUI.Classes
{
    public class ServerStoppingEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
        public ServerStoppingEventArgs() : base() { this.Cancel = false; }
    }
}
