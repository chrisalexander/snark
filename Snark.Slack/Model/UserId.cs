namespace Snark.Slack.Model
{
    class UserId : SlackId
    {
        public UserId(string value) : base(value) { }

        protected override char Prefix => 'U';

        public static implicit operator UserId(string value)
        {
            return new UserId(value);
        }
    }
}
