using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class MoviesAPIDbContext : DbContext
    {
        public MoviesAPIDbContext(DbContextOptions<MoviesAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Movies entity
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.MovieId).ValueGeneratedOnAdd();
                // Configure other properties of the Movies entity if needed
            });

            // Add any additional configurations for other entities if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
/*
using Microsoft.EntityFrameworkCore;
using RentalVideoWebAPI.Models;

namespace RentalVideoWebAPI.Data
{
    public class MoviesAPIDbContext : DbContext
    {
        public MoviesAPIDbContext(DbContextOptions<MoviesAPIDbContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Movies entity
            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.MovieId).ValueGeneratedOnAdd();
                // Configure other properties of the Movies entity if needed
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

