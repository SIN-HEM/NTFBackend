using Microsoft.EntityFrameworkCore;
using NIFTWebApp.Modules.BiddingModule.Entities;
using NIFTWebApp.Modules.CarouselModule.Entities;
using NIFTWebApp.Modules.ProductModule.Entities;
using NIFTWebApp.Modules.UserModule.Entities;
using NIFTWebApp.Modules.VendorModule.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NIFTWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CarouselCard> CarouselCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Category hierarchy
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete loops

            // Product ↔ Vendor
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Vendor)
                .WithMany(v => v.Products)
                .HasForeignKey(p => p.VendorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product ↔ Category
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Bid ↔ Product
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Product)
                .WithMany(p => p.Bids)
                .HasForeignKey(b => b.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // Bid ↔ User
            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User: Email unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(); 
        }
    }
}
