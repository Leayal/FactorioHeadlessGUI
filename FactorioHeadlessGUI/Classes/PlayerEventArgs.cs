using System;

namespace FactorioHeadlessGUI.Classes
{
    public class PlayerEventArgs : EventArgs
    {
        public UserInfo PlayerInfo { get; }
        public PlayerEventArgs(UserInfo _info)
        {
            this.PlayerInfo = _info;
        }
    }
}
