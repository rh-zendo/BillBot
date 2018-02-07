using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillBot.Core.Modules
{
    public class CommandModule : BillBotModule
    {
        public CommandModule(DiscordSocketClient socket) : base(socket)
        {
            Console.WriteLine("[CommandModule] Loading");

            Console.WriteLine("[CommandModule] Loaded");
        }

        protected async override Task MessageReceived(SocketMessage message)
        {
            var author = message.Author;

            var msgArr = message.Content.Split(' ');
            if (msgArr[0] == "!hug")
            {
                if (msgArr[1] != "@everyone")
                {
                    var targetUser = message.MentionedUsers.SingleOrDefault();
                    if (targetUser == null)
                        return;

                    await message.Channel.SendMessageAsync($"{author.Username} hugs {targetUser.Username}! <3");
                }
                else
                {
                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\teampg.png", $"GROUP HUG MOFOS!");
                }

            }

            if (msgArr[0] == "!nano")
            {
                if (msgArr[1] != "@everyone")
                {
                    var targetUser = message.MentionedUsers.SingleOrDefault();
                    if (targetUser == null)
                        return;

                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\nano2.png", $"{author.Username} nanoed {targetUser.Username}!");
                }

            }

            if (msgArr[0] == "!gn")
            {
                if (msgArr[1] != "@everyone")
                {
                    var targetUser = message.MentionedUsers.SingleOrDefault();
                    if (targetUser == null)
                        return;

                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\ng.jpg", $"{author.Username} put {targetUser.Username} to sleep");
                }
            }


            if (msgArr[0] == "!pat")
            {
                if (msgArr[1] != "@everyone")
                {
                    var targetUser = message.MentionedUsers.SingleOrDefault();
                    if (targetUser == null)
                        return;

                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\clap.gif", $"{author.Username} pats {targetUser.Username} on head");
                }
            }


            if (msgArr[0] == "!letitgo")
            {
                if (author.Username == "spicyjim")
                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\letitgo.gif", $"{author.Username} is letting it go");
                else
                    await message.Channel.SendMessageAsync($"Sorry {author.Username} only Jim is allowed to let it go (FUCK YOU)");
            }


            if (msgArr[0] == "!hackerman")
            {
                if (author.Username == "spicyjim")
                    await message.Channel.SendFileAsync(@"C:\src\BillBot\BillBot.Core\letitgo.gif", $"{author.Username} is letting it go");
                else
                    await message.Channel.SendMessageAsync($"Sorry {author.Username} only Jim is allowed to let it go (FUCK YOU)");
            }
        }

        protected override Task MessageUpdated(SocketMessage message)
        {
            return null;
        }
    }
}
