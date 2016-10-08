namespace Snark.Slack.Model
{
    class ChannelId : SlackId
    {
        public ChannelId(string value) : base(value) { }

        protected override char Prefix => 'C';

        public static implicit operator ChannelId(string value)
        {
            return new ChannelId(value);
        }
    }
}
