using ATM.Models;
using Microsoft.EntityFrameworkCore;

namespace ATM.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Operation> Operations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Card");
            modelBuilder.Entity<Operation>().ToTable("Operation");
            modelBuilder.Seed();
        }
    }
}
