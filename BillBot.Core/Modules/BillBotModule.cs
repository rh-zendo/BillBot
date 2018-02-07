using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BillBot.Core.Modules
{
    public abstract class BillBotModule
    {
        // Fields
        private readonly DiscordSocketClient socket;

        public BillBotModule(DiscordSocketClient socket)
        {
            this.socket = socket;
            
            // Message Events
            this.socket.MessageReceived += Socket_MessageReceived;
            this.socket.MessageUpdated += Socket_MessageUpdated;
        }
        
        #region Message Events Methods
        protected abstract Task MessageReceived(SocketMessage message);
        protected abstract Task MessageUpdated(SocketMessage message);

        private async Task Socket_MessageReceived(SocketMessage message)
        {
            // TODO: Remove Training room
            if (message.Channel.Id != 410173873154162689)
                return;

            await MessageReceived(message);
        }

        private async Task Socket_MessageUpdated(Cacheable<IMessage, ulong> arg1, SocketMessage message, ISocketMessageChannel arg3)
        {
            // TODO: Remove Training room
            if (message.Channel.Id != 410173873154162689)
                return;

            await MessageUpdated(message);
        }
        #endregion
    }
}
