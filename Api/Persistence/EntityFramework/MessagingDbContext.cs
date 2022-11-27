using Api.Persistence.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistence.EntityFramework
{
    public class MessagingDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=postgres");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.Entity<Message>().Property(m => m.MessageId).ValueGeneratedOnAdd();
    }
}