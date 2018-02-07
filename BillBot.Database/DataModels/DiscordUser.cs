using System.ComponentModel.DataAnnotations.Schema;

namespace BillBot.Database.DataModels
{
    [Table("DiscordUsers")]
    public class DiscordUser : DataModelBase
    {
        public ulong DiscordId { get; set; }

        public string DiscordUsername { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public int Karma { get; set; }
    }
}
