namespace AspNetLesson.Services
{
    public class MessageService
    {
        private IMessageSender _sender;

        public MessageService(IMessageSender sender)
        {
            _sender = sender;
        }

        public string Send()
        {
            return _sender.Send();
        }
    }
}
