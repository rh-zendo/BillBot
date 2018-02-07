using System;
using System.Threading.Tasks;
using BillBot.Core.Utils;
using BillBot.Database;
using BillBot.Database.DataModels;
using Discord.WebSocket;

namespace BillBot.Core.Modules.User
{
    public class UserModule : BillBotModule
    {
        public UserModule(DiscordSocketClient socket) : base(socket)
        {
        }

        protected override async Task MessageReceived(SocketMessage message)
        {
            var user = await UpdateUser(message.Author);

            var command = SocketMessageUtils.GetCommand(message);
            switch (command)
            {
                case "profile": await CommandStats(message, user); break;
            }
        }

        protected override async Task MessageUpdated(SocketMessage message)
        {
            var user = await UpdateUser(message.Author);
        }
        
        #region UpdateUser Method
        private async Task<DiscordUser> UpdateUser(SocketUser user)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var discordUser = await unitOfWork.DiscordUserRepository.GetByDiscordIdAsync(user.Id);
                if (discordUser == null)
                {
                    discordUser = new DiscordUser
                    {
                        DiscordId = user.Id,
                        Level = 1,
                        Experience = 0,
                        Karma = 1000,
                        CreatedAt = DateTime.Now
                    };
                    unitOfWork.DiscordUserRepository.Add(discordUser);
                    Console.WriteLine($"[BillBot] Added Discord User {discordUser.DiscordUsername}");
                }

                discordUser.DiscordUsername = user.Username;
                discordUser.UpdateAt = DateTime.Now;

                await unitOfWork.CompleteAsync();

                return discordUser;
            }
        }
        #endregion

        #region Command Methods
        private async Task CommandStats(SocketMessage message, DiscordUser user)
        {
            await message.Channel.SendMessageAsync($"{user.DiscordUsername} stats");
        }
        #endregion

    }
}
