using Devin.Pages;

namespace Devin.Data
{
    public class MessageService
    {
        private Message messageComponent;

        public void SetMessageComponent(Message messageComponent)
        {
            this.messageComponent = messageComponent;
        }

        public void SetMessage(string message)
        {
            messageComponent.SetMessage(message);
        }
    }
}