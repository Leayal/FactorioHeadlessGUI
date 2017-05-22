using System;

namespace FactorioHeadlessGUI.Classes
{
    public class PlayerKickedEventArgs : EventArgs
    {
        public UserInfo Sender { get; }
        public UserInfo Target { get; }
        public string Reason { get; }

        public PlayerKickedEventArgs(UserInfo _sender, UserInfo _target, string _reason) : base()
        {
            this.Sender = _sender;
            this.Target = _target;
            this.Reason = _reason;
        }
    }
}
