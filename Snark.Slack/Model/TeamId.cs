namespace Snark.Slack.Model
{
    class TeamId : SlackId
    {
        public TeamId(string value) : base(value) { }

        protected override char Prefix => 'T';

        public static implicit operator TeamId(string value)
        {
            return new TeamId(value);
        }
    }
}
