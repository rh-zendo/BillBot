using BillBot.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BillBot.Database
{
    public class UnitOfWork : IDisposable
    {
        // Fields
        private bool disposed = false;
        private DatabaseContext context;

        // Repos
        public BillBotSettingRepository BillBotSettingRepository;

        public DiscordUserRepository DiscordUserRepository;

        public UnitOfWork()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseMySql("server=localhost;database=billbot;user=billbot;password=billbot");
            this.context = new DatabaseContext(builder.Options);

            this.BillBotSettingRepository = new BillBotSettingRepository(context);
            this.DiscordUserRepository = new DiscordUserRepository(context);
        }

        #region Complete Methods
        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
        #endregion

        #region Dispose Methods
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
