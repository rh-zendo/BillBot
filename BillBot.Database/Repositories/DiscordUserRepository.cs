using BillBot.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BillBot.Database.Repositories
{
    public class DiscordUserRepository : RepositoryBase<DiscordUser>
    {
        public DiscordUserRepository(DatabaseContext context) : base(context)
        {
        }

        #region Get Methods
        public async Task<DiscordUser> GetByDiscordIdAsync(ulong discordId)
        {
            return await this.context.DiscordUsers.SingleOrDefaultAsync(du => du.DiscordId == discordId);
        }
        #endregion
    }
}
