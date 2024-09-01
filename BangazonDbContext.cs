﻿namespace Bangazon;
using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

    public class BangazonDbContext : DbContext
    {
    public DbSet<User>? Users { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<Product>? Products { get; set; }

        public BangazonDbContext(DbContextOptions<BangazonDbContext> options) : base(options)
    { 

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
        [
            new Category {CategoryId = 1, CategoryName = "Oil"},
            new Category {CategoryId = 2, CategoryName = "Vehicle" },
            new Category {CategoryId = 3, CategoryName = "Tire" },
            new Category {CategoryId = 4, CategoryName = "Light Bulb" },
            new Category {CategoryId = 5, CategoryName = "Accessory" }
        ]);

        modelBuilder.Entity<Product>().HasData(
            [
                new Product { ProductId = 1, UserId = 2, Name = "Blinker bulb", Description = "A new and universally fitting blinker bulb", Price = 7.99M, Quantity = 10, CategoryId = 4, TimeMade = new DateTime(2024, 1, 01), ImageUrl = "this is the image of a small bulb" },
                new Product { ProductId = 2, UserId = 2, Name = "Car Engine Oil", Description = "Premium synthetic engine oil for all vehicles", Price = 29.99M, Quantity = 25, CategoryId = 1, TimeMade = new DateTime(2024, 2, 15), ImageUrl = "this is the image of an oil bottle" },
                new Product { ProductId = 3, UserId = 2, Name = "All-Season Tire", Description = "Durable all-season tire suitable for all terrains", Price = 99.99M, Quantity = 15, CategoryId = 3, TimeMade = new DateTime(2024, 3, 10), ImageUrl = "this is the image of a tire" },
                new Product { ProductId = 4, UserId = 2, Name = "Vehicle Battery", Description = "Long-lasting vehicle battery with extended warranty", Price = 79.99M, Quantity = 20, CategoryId = 2, TimeMade = new DateTime(2024, 4, 20), ImageUrl = "this is the image of a battery" },
                new Product { ProductId = 5, UserId = 2, Name = "LED Headlight Bulb", Description = "Energy-efficient LED headlight bulb for better visibility", Price = 14.99M, Quantity = 30, CategoryId = 4, TimeMade = new DateTime(2024, 5, 05), ImageUrl = "this is the image of an LED bulb" },
                new Product { ProductId = 6, UserId = 2, Name = "Car Air Freshener", Description = "Aromatic air freshener for a pleasant driving experience", Price = 4.99M, Quantity = 50, CategoryId = 5, TimeMade = new DateTime(2024, 6, 12), ImageUrl = "this is the image of an air freshener" }
            ]);

        modelBuilder.Entity<OrderItem>().HasData(
            [
                new OrderItem { OrderItemId = 1, UserId = 1, ProductId = 2},
                new OrderItem { OrderItemId = 2, UserId = 1, ProductId = 3},
                new OrderItem { OrderItemId = 3, UserId = 1, ProductId = 1}
            ]);

        modelBuilder.Entity<User>().HasData(
            [
               new User { Id = 1, Uid = "Whs5IAAH2wM5wdM8ConMeCP61HC3", UserName = "Mrthincrisp", Email = "Mrthincrisp@gmail.com", Seller = false, StoreName = "", StoreDescription = ""},
               new User { Id = 2, Uid ="vZWoK9Q49vgj2JIxXU52Muoti0z2", UserName = "Derek", Email = "johndoe@example.com", Seller = true, StoreName = "Doe parts", StoreDescription = "A trusted store for all your vehicle needs, offering a wide range of products including tires, oils, and accessories."}
            ]);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderItems)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<User>()
            .HasMany(u => u.OrderItems)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Product)
            .WithMany(p => p.OrderItems)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.User)
            .WithMany(u => u.OrderItems)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

    }

}

