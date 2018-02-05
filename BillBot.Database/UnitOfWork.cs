using Microsoft.EntityFrameworkCore;
using System;

namespace BillBot.Database
{
    public class UnitOfWork : IDisposable
    {
        // Fields
        private bool disposed = false;
        private DatabaseContext databaseContext;

        public UnitOfWork()
        {
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseMySQL("server=localhost;database=mimmo;user=mimmo;password=mimmo");

            this.databaseContext = new DatabaseContext(builder.Options);
        }

        #region Dispose Methods
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    databaseContext.Dispose();

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
