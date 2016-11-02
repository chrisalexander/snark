namespace Snark.Chat
{
    public class ChannelId
    {
        public ChannelId(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public static implicit operator ChannelId(string value)
        {
            return new ChannelId(value);
        }
    }
}
