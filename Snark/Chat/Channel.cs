using Snark.Client;

namespace Snark.Chat
{
    public class Channel
    {
        public Channel(ServiceIdentifier service)
        {
            this.Service = service;
        }

        public ServiceIdentifier Service { get; }

        public ChannelId Id { get; set; }
    }
}
