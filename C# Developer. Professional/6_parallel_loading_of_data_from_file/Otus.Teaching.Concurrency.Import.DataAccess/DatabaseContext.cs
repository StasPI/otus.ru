using Microsoft.EntityFrameworkCore;
using Otus.Teaching.Concurrency.Import.Core.AppSettings;
using Otus.Teaching.Concurrency.Import.Handler.Entities;

namespace Otus.Teaching.Concurrency.Import.DataAccess
{
    public class DatabaseContext : DbContext
    {
        private readonly string _connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }

        public DatabaseContext(ISettings settings)
        {
            _connectionString = settings.ConnectionString;
            Database.EnsureCreated();
        }

        public void DropDatabase()
        {
            Database.EnsureDeleted();
        }
        public DbSet<Customer> Customers { get; set; }
    }
}