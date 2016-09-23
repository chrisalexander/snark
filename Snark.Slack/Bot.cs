namespace Snark.Slack
{
    public static class Bot
    {
        public static Snark.Bot Create(string token)
        {
            return new Snark.Bot(new SlackClient(), token);
        }
    }
}
