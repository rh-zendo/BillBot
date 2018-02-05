using BillBot.Core.Models;
using BillBot.Core.Modules;
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
        private DiscordSocketClient client;
        private BillBotSettings settings;
        private List<BillBotModule> modules;

        public Bot()
        {
            Console.WriteLine("[BillBot] Initializing");

            this.client = new DiscordSocketClient();

            // Loading Settings File
            using (StreamReader settingsFile = File.OpenText("settings.json"))
            { 
                JsonSerializer serializer = new JsonSerializer();
                settings = (BillBotSettings)serializer.Deserialize(settingsFile, typeof(BillBotSettings));
            }
            
            this.modules = new List<BillBotModule>();

            Console.WriteLine("[BillBot] Initialized");
        }

        public async Task Initialize()
        {
            // Login
            await LoginAsync();

            // Loading Modules
            this.modules.Add(new BadLanguageModule(this.client)); 
            this.modules.Add(new CommandModule(this.client)); 

            await Task.Delay(-1);
        }

        private async Task LoginAsync()
        {
            Console.WriteLine("[BillBot] Logging In");
            await this.client.LoginAsync(TokenType.Bot, settings.Token);
            await this.client.StartAsync();
            Console.WriteLine("[BillBot] Logged In");
        }
    }
}
