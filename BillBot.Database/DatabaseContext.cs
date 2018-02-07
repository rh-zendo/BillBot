using BillBot.Database.DataModels;
using Microsoft.EntityFrameworkCore;

namespace BillBot.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        #region BillBot DbSets
        public DbSet<BillBotSetting> BillBotSettings { get; set; }
        public DbSet<BillBotFile> BillBotFiles { get; set; }
        #endregion

        #region Discord DbSets
        public DbSet<DiscordUser> DiscordUsers { get; set; }
        #endregion
    }
}