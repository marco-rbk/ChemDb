using Microsoft.EntityFrameworkCore;
using VibeMapper.Core.Models;

namespace VibeMapper.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Chemical> Chemicals { get; set; }
        public DbSet<DNEL> DNELs { get; set; }
        public DbSet<PNEC> PNECs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships if needed, for example:
            modelBuilder.Entity<Chemical>()
                .HasMany(c => c.DNELs)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chemical>()
                .HasMany(c => c.PNECs)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DNEL>()
                .Property(d => d.Value)
                .HasColumnType("decimal(18, 6)");

            modelBuilder.Entity<PNEC>()
                .Property(p => p.Value)
                .HasColumnType("decimal(18, 6)");
        }
    }
}
