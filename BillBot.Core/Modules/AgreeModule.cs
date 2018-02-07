using BillBot.Core.Utils;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillBot.Core.Modules
{
    public class AgreeModule : BillBotModule
    {
        // Fields
        private List<string> agreeWords;

        public AgreeModule(DiscordSocketClient socket) : base(socket)
        {
            Console.WriteLine("[AgreeModule] Loading");

            this.agreeWords = new List<string>
            {
                "right",
                "agree"
            };

            Console.WriteLine("[AgreeModule] Loaded");
        }

        protected async override Task MessageReceived(SocketMessage message)
        {
            if (!SocketMessageUtils.IsBotMentioned(message))
                return;
                        
            if (!agreeWords.Any(w => message.Content.ToLower().Contains(w)))
                return;
            
            await message.Channel.SendMessageAsync($"I agree with { message.Author.Username}");
        }

        protected override Task MessageUpdated(SocketMessage message)
        {
            return null;
        }
    }
}
