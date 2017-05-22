using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactorioHeadlessGUI.Classes
{
    public class UserInfo
    {
        public string PlayerID { get; }

        public UserInfo(string _playerID)
        {
            this.PlayerID = _playerID;
        }
    }
}
