using Microsoft.EntityFrameworkCore;

namespace BillBot.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}