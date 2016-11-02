using Snark.Chat;
using Snark.Slack.Client;

namespace Snark.Slack.Chat
{
    class Channel : Snark.Chat.Channel
    {
        public Channel() : base(SlackClient.Id)
        {
        }

        public string Name { get; set; }

        public bool IsChannel { get; set; }

        public long Created { get; set; }

        public UserId Creator { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
