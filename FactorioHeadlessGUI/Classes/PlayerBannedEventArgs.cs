namespace FactorioHeadlessGUI.Classes
{
    public class PlayerBannedEventArgs : PlayerKickedEventArgs
    {
        public PlayerBannedEventArgs(UserInfo _sender, UserInfo _target, string _reason) : base(_sender, _target, _reason) { }
    }
}
