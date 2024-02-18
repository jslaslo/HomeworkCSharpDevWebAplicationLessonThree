using System;
using Market.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Market.Context
{
    public class MarketContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public MarketContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("");

            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=Market").UseLazyLoadingProxies();


            //base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("product_pkey");
                entity.ToTable("Products");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Description).HasMaxLength(250);

                entity.HasOne(e => e.Store).WithMany(e => e.Products).HasForeignKey(p => p.StoreId);
                entity.HasOne(e => e.Category).WithMany(e => e.Products).HasForeignKey(e => e.CategoryId);

            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("category_pkey");
                entity.ToTable("Categories");
                entity.HasIndex(e => e.Name).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(d => d.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(p => p.Id).HasName("store_pkey");
                entity.ToTable("Stores");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

