using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class RentalAPIDbContext : DbContext
    {
        public RentalAPIDbContext(DbContextOptions<RentalAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Rental entity
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(r => r.RentalId);
                entity.Property(r => r.RentalId).ValueGeneratedOnAdd();
                // Configure other properties of the Rental entity if needed
            });

            // Add any additional configurations for other entities if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
/*using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class RentalAPIDbContext : DbContext
    {
        public RentalAPIDbContext(DbContextOptions<RentalAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Customers entity
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.HasKey(r => r.RentalId);
                entity.Property(r => r.RentalId).ValueGeneratedOnAdd();
                // Configure other properties of the Customers entity if needed
            });

            // Add any additional configurations for other entities if needed

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("RentalVideoAPIConnection");
            }
        }
    }
}*/

