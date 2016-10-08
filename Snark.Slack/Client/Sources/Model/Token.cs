using Snark.Client;

namespace Snark.Slack.Client.Sources.Model
{
    public class Token : ICredentials
    {
        private string value;

        public Token(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return this.value;
        }

        public static implicit operator Token(string value)
        {
            return new Token(value);
        }
    }
}
