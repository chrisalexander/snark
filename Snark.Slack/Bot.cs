using Snark.Slack.Client;
using Snark.Slack.Client.Sources.Model;

namespace Snark.Slack
{
    public static class Bot
    {
        public static Bot<Token> Create(Token token)
        {
            return new Bot<Token>(new SlackClient(), token);
        }
    }
}
