using Microsoft.EntityFrameworkCore;
using RPS.Contracts.Models;

namespace RPS.Infrastructure
{
    public class GamesContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "GameDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasKey(o => o.Id);
            modelBuilder.Entity<User>().HasKey(o => o.Id);
            modelBuilder.Entity<Tournament>().HasKey(o => o.Id);
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Tournament> Tournaments { get; set; }
    }
}
