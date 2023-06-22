﻿using Microsoft.EntityFrameworkCore;
using NSE.Cart.API.Model;

namespace NSE.Cart.API.Data
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CustomerCart> CustomerCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model
                .GetEntityTypes()
                    .SelectMany(e => e.GetProperties()
                        .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("VARCHAR(100)");

            modelBuilder.Entity<CustomerCart>()
                .HasIndex(c => c.CustomerId)
                .HasDatabaseName("IDX_Customer");

            modelBuilder.Entity<CustomerCart>()
                .HasMany(c => c.Items)
                .WithOne(i => i.CustomerCart)
                .HasForeignKey(c => c.CartId);

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                    .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
        }
    }
}
