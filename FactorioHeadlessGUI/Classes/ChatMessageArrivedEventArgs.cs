namespace FactorioHeadlessGUI.Classes
{
    public class ChatMessageArrivedEventArgs : PlayerEventArgs
    {
        public string Message { get; }
        public ChatMessageArrivedEventArgs(UserInfo playerid, string msg) : base(playerid)
        {
            this.Message = msg;
        }
    }
}
