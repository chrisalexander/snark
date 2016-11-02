using Snark.Client;

namespace Snark.Chat
{
    public class ReplyToken
    {
        public ReplyToken(ServiceIdentifier service)
        {
            this.Service = service;
        }

        public ServiceIdentifier Service;
    }
}
