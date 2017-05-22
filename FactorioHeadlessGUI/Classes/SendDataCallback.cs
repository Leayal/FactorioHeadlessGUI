using System;
namespace FactorioHeadlessGUI.Classes
{
    public class SendDataCallback
    {
        public EventHandler CallbackMethod { get; }
        public string CallbackCondition { get; }
        public SendDataCallback(string condition, EventHandler callback)
        {
            this.CallbackCondition = condition;
            this.CallbackMethod = callback;
        }
    }
}
