
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Wedding.Models;

namespace Wedding.Data {
    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Models.Wedding> Weddings { get; private set; }
        public DbSet<Models.GuestMessage> Messages { get; private set; }
        public DbSet<Models.WeddingEvent> WeddingEvents { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Wedding>().HasIndex(w => w.Alias).IsUnique();
        }
    }
}
