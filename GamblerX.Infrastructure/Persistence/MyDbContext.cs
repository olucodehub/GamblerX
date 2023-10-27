using GamblerX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamblerX.Infrastructure.Persistence
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // UseSqlServer method for SQL Server
                optionsBuilder.UseSqlServer("Server=.;Database=tete;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
