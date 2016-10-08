using System;

namespace Snark.Slack.Model
{
    abstract class SlackId
    {
        public SlackId(string value)
        {
            if (!value.StartsWith(this.Prefix.ToString()))
            {
                throw new ArgumentException($"Value {value} must have prefix {this.Prefix}", nameof(value));
            }

            this.Value = value;
        }

        public string Value { get; }

        protected abstract char Prefix { get; }
    }
}
