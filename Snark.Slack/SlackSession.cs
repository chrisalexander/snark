using System.Collections.Generic;
using System.Linq;
using Snark.Client;
using Snark.Slack.Model;

namespace Snark.Slack
{
    class SlackSession : ISession<User, Channel>
    {
        private IReadOnlyCollection<Channel> channels;
        private IReadOnlyCollection<User> users;
        private Token credentials;
        private RealtimeConnectionDetails realtimeConnectionDetails;

        public SlackSession(
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

        public IReadOnlyCollection<Channel> Channels => this.channels;

        public IReadOnlyCollection<User> Users => this.users;

        public Token Credentials => this.credentials;

        public RealtimeConnectionDetails RealtimeConnectionDetails => this.realtimeConnectionDetails;
    }
}
