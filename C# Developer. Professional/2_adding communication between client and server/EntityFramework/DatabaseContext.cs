using Microsoft.EntityFrameworkCore;
using Entities;

namespace EntityFramework
{
   public class DatabaseContext : DbContext
   {
      public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
      {
      }

      public DbSet<Customer> Customer { get; set; }
   }
}