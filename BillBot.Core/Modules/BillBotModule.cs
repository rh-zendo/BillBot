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
        private DiscordSocketClient client;

        public BillBotModule(DiscordSocketClient client)
        {
            this.client = client;

            // Events
            this.client.MessageReceived += Client_MessageReceived;
        }

        #region Abstact Classes
        protected abstract Task MessageReceived(SocketMessage message);
        #endregion
        
        #region Event Methods
        private async Task Client_MessageReceived(SocketMessage message)
        {
            // TODO: Remove Training room
            if (message.Channel.Id != 410173873154162689) return;

            await MessageReceived(message);
        }
        #endregion
    }
}
