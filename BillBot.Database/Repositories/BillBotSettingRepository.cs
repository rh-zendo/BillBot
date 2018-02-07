using BillBot.Database.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BillBot.Database.Repositories
{
    public class BillBotSettingRepository : RepositoryBase<BillBotSetting>
    {
        public BillBotSettingRepository(DatabaseContext context) : base(context)
        {
        }

        #region Get Methods
        public async Task<BillBotSetting> GetByNameAsync(string settingName)
        {
            return await this.context.BillBotSettings.SingleOrDefaultAsync(bbs => bbs.Name == settingName);
        }
        #endregion

    }
}
