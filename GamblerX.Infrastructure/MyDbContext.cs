using GamblerX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamblerX.Infrastructure
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            
        }
        
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Betting> Bettings { get; set; }
        public DbSet<Bettor> Bettors { get; set; }

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
