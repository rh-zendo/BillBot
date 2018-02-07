using Discord;
using Discord.WebSocket;
using System;
using System.Linq;
using System.Threading.Tasks;


// Bot Invite Link: https://discordapp.com/oauth2/authorize?client_id=410168907211603970&scope=bot
namespace BillBot.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            bot.Initialize().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to logout");
            Console.ReadKey(true);

            bot.LogoutAsync().GetAwaiter().GetResult();
        }
    }
}
