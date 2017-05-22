using System;

namespace FactorioHeadlessGUI.Classes
{
    public class VerboseLogEventArgs : EventArgs
    {
        public string Log { get; }
        public VerboseLogEventArgs(string _log)
        {
            this.Log = _log;
        }
    }
}
