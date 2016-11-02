namespace Snark.Chat
{
    public class TeamId
    {
        public TeamId(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public static implicit operator TeamId(string value)
        {
            return new TeamId(value);
        }
    }
}
