using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace BillBot.Core.Modules
{
    public class BadLanguageModule : BillBotModule
    {
        private List<string> badWords;

        public BadLanguageModule(DiscordSocketClient client) : base(client)
        {
            Console.WriteLine("[BadLanguageModule] Loading");
            this.badWords = new List<string>();

            this.badWords.Add("fuck");
            this.badWords.Add("shit");
            this.badWords.Add("bs");
            this.badWords.Add("jävlar");
            
            Console.WriteLine("[BadLanguageModule] Loaded");
        }

        protected async override Task MessageReceived(SocketMessage message)
        { 
            var author = message.Author;
            
            if (!badWords.Any(s => message.Content.ToLower().Contains(s)))
                return;

            await message.Channel.SendMessageAsync($"Hi {author.Username} could you please mind your language");
        }

        protected override Task MessageUpdated(SocketMessage message)
        {
            return null;
        }
    }
}
