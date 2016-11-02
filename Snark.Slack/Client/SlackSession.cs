using System.Collections.Generic;
using System.Linq;
using Snark.Client;
using Snark.Slack.Client.Sources.Model;
using Snark.Slack.Chat;

namespace Snark.Slack.Client
{
    class Session : ISession
    {
        private IReadOnlyCollection<Channel> channels;
        private IReadOnlyCollection<User> users;
        private Token credentials;
        private RealtimeConnectionDetails realtimeConnectionDetails;

        public Session(
            IEnumerable<User> users,
            IEnumerable<Channel> channels,
            Token credentials,
            RealtimeConnectionDetails realtimeConnectionDetails)
        {
            this.users = users.ToList().AsReadOnly();
            this.channels = channels.ToList().AsReadOnly();
            this.credentials = credentials;
            this.realtimeConnectionDetails = realtimeConnectionDetails;
        }

        public IReadOnlyCollection<Snark.Chat.Channel> Channels => this.channels;

        public IReadOnlyCollection<Snark.Chat.User> Users => this.users;

        public Token Credentials => this.credentials;

        public RealtimeConnectionDetails RealtimeConnectionDetails => this.realtimeConnectionDetails;
    }
}
