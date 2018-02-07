using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillBot.Core.Utils
{
    public static class SocketMessageUtils
    {
        public static bool IsBotMentioned(SocketMessage message)
        {
            if (message.MentionedUsers.SingleOrDefault(u => u.Id == 410168907211603970) == null)
                return false;
            else
                return true;
        }

        public static string GetCommand(SocketMessage message)
        {
            var msgArr = message.Content.Split(' ');

            var firstWord = msgArr[0];
            if (firstWord == null)
                return null;
            
            // Checks if command flag
            if (!firstWord.Contains('!'))
                return null;

            return firstWord.Replace("!","");
        }
    }
}
