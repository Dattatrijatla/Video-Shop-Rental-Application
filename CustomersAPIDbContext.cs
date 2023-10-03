/*using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class CustomersAPIDbContext : DbContext
    {
        public CustomersAPIDbContext(DbContextOptions options) : base(options:)
        {
        }
        public DbSet<Customers> Customers { get; set; }

    }
}*/
using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class CustomersAPIDbContext : DbContext
    {
        public CustomersAPIDbContext(DbContextOptions<CustomersAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Customers entity
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
               // entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();
                // Configure other properties of the Customers entity if needed
            });

            // Add any additional configurations for other entities if needed

            base.OnModelCreating(modelBuilder);
        }

    }
}/*
using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class CustomersAPIDbContext : DbContext
    {
        public CustomersAPIDbContext(DbContextOptions<CustomersAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Customers entity
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();
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
}
/*
using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class CustomersAPIDbContext : DbContext
    {
        public CustomersAPIDbContext(DbContextOptions<CustomersAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Customers entity
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerId).ValueGeneratedOnAdd();
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
}
*/

