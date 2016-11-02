using Snark.Slack.Client;
using Snark.Slack.Client.Sources.Model;

namespace Snark.Slack
{
    public static class Bot
    {
        public static Snark.Bot Create(Token token)
        {
            return new Snark.Bot(new SlackClient(), token);
        }
    }
}
