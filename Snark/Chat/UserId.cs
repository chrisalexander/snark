namespace Snark.Chat
{
    public class UserId
    {
        public UserId(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public static implicit operator UserId(string value)
        {
            return new UserId(value);
        }
    }
}
