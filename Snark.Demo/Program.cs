using System;
using System.Threading.Tasks;

namespace Snark.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args[0]).Wait();

            Console.ReadLine();
        }

        static async Task MainAsync(string token)
        {
            var bot = Slack.Bot.Create(token);

            await bot.ConnectAsync();
        }
    }
}
