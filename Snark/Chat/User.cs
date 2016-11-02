using Snark.Client;

namespace Snark.Chat
{
    public class User
    {
        public User(ServiceIdentifier service)
        {
            this.Service = service;
        }

        public ServiceIdentifier Service { get; }

        public UserId Id { get; set; }

        public TeamId TeamId { get; set; }
    }
}
