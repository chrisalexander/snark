using Snark.Chat;

namespace Snark.Slack.Model
{
    class Channel : IChannel
    {
        public ChannelId Id { get; set; }

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
