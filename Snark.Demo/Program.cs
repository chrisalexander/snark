using System.Threading.Tasks;

namespace Snark.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args[0]).Wait();
        }

        static async Task MainAsync(string token)
        {
            var bot = Slack.Bot.Create(token);

            await bot.ConnectAsync();

            await Task.Delay(10000);
        }
    }
}
