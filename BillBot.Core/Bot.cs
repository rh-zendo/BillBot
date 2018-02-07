using BillBot.Core.Exceptions;
using BillBot.Core.Modules;
using BillBot.Core.Modules.User;
using BillBot.Database;
using BillBot.Database.DataModels;
using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillBot.Core
{
    public class Bot
    {
        // Fields
        //private DiscordShardedClient client;
        private DiscordSocketClient client;
        private List<BillBotModule> modules;

        // Setting Fields
        private string settingDiscordBotToken;
        private int settingDiscordClientShardCount;

        public Bot()
        {
            Console.WriteLine("[BillBot] Initializing");

            this.modules = new List<BillBotModule>();

            Console.WriteLine("[BillBot] Initialized");
        }

        public async Task Initialize()
        {
            // Initialize Settings
            await this.InitializeSettings();

            // Creating Client
            /*
            this.client = new DiscordShardedClient(new DiscordSocketConfig()
            {
                TotalShards = settingDiscordClientShardCount,
                LogLevel = LogSeverity.Info,
                ConnectionTimeout = 150000,
                LargeThreshold = 250,
            });
            */
            this.client = new DiscordSocketClient();
            this.client.Log += Client_Log;

            // Loggin In
            await LoginAsync(settingDiscordBotToken);

            //foreach (DiscordSocketClient socket in client.Shards)
            //{
                this.modules.Add(new UserModule(this.client));
                //this.modules.Add(new AgreeModule(socket));
                //this.modules.Add(new BadLanguageModule(socket));
                //this.modules.Add(new CommandModule(socket));
            //}
        }

        private async Task InitializeSettings()
        {
            using (var unitOfWork = new UnitOfWork())
            {
                // Token
                var tokenSetting = await unitOfWork.BillBotSettingRepository.GetByNameAsync("token");
                if (tokenSetting == null)
                {
                    tokenSetting = new BillBotSetting { Name = "token", Value = "", CreatedAt = DateTime.Now, UpdateAt = DateTime.Now };
                    unitOfWork.BillBotSettingRepository.Add(tokenSetting);
                    await unitOfWork.CompleteAsync();
                }
                this.settingDiscordBotToken = tokenSetting.Value;

                if (string.IsNullOrEmpty(this.settingDiscordBotToken))
                    throw new BillBotTokenNotSetupException();

                // Client
                var clientShardCountSetting = await unitOfWork.BillBotSettingRepository.GetByNameAsync("client.shardcount");
                if (clientShardCountSetting == null)
                {
                    clientShardCountSetting = new BillBotSetting { Name = "client.shardcount", Value = "8", CreatedAt = DateTime.Now, UpdateAt = DateTime.Now };
                    unitOfWork.BillBotSettingRepository.Add(clientShardCountSetting);
                    await unitOfWork.CompleteAsync();
                }
                this.settingDiscordClientShardCount = int.Parse(clientShardCountSetting.Value);
            }
        }

        #region Login Methods
        private async Task LoginAsync(string token)
        {
            Console.WriteLine("[BillBot] Logging In");
            await this.client.LoginAsync(TokenType.Bot, token);
            await this.client.StartAsync();
            Console.WriteLine("[BillBot] Logged In");
        }

        public async Task LogoutAsync()
        {
            Console.WriteLine("[BillBot] Logging Out");
            await this.client.LogoutAsync();
            Console.WriteLine("[BillBot] Logged Out");
        }
        #endregion
        
        #region Client Event Methods
        private Task Client_Log(LogMessage logMessage)
        {
            Console.WriteLine($"[BillBot][ClientLog] {logMessage.Message}");

             return null;
        }
        #endregion
    }
}
