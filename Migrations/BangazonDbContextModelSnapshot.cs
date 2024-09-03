﻿// <auto-generated />
using System;
using Bangazon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    partial class BangazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Oil"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Vehicle"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Tire"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Light Bulb"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Accessory"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Bangazon.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            ProductId = 2,
                            UserId = 1
                        },
                        new
                        {
                            OrderItemId = 2,
                            ProductId = 3,
                            UserId = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            ProductId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Bangazon.Models.OrderProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductNumber")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("SellerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeMade")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4,
                            Description = "A new and universally fitting blinker bulb",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR9F9dbIleMgaQn1Ss-CGcX_i1SXN1Av8EmHw&s",
                            Name = "Blinker bulb",
                            Price = 7.99m,
                            Quantity = 10,
                            TimeMade = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Description = "Premium synthetic engine oil for all vehicles",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQnw1Rsm0jsi34mKiOieNRQ1cmWm1ZgTmWTwQ&s",
                            Name = "Car Engine Oil",
                            Price = 29.99m,
                            Quantity = 25,
                            TimeMade = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 3,
                            Description = "Durable all-season tire suitable for all terrains",
                            ImageUrl = "https://the-antiqueology.myshopify.com/cdn/shop/products/image_fe749231-26a4-4eeb-86d8-ec7980874775.jpg?v=1660339348&width=1445",
                            Name = "All-Season Tire",
                            Price = 99.99m,
                            Quantity = 15,
                            TimeMade = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2,
                            Description = "Long-lasting vehicle battery with extended warranty",
                            ImageUrl = "https://greentumble.com/wp-content/uploads/2016/12/How-To-Produce-Electricity-From-A-Potato.jpg",
                            Name = "Vehicle Battery",
                            Price = 79.99m,
                            Quantity = 20,
                            TimeMade = new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 4,
                            Description = "Energy-efficient LED headlight bulb for better visibility",
                            ImageUrl = "https://cdn.sealite.com/wp-content/uploads/20201114143005/universal-led-controller-e1592894075755.jpg",
                            Name = "LED Headlight Bulb",
                            Price = 14.99m,
                            Quantity = 30,
                            TimeMade = new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 5,
                            Description = "Aromatic air freshener for a pleasant driving experience",
                            ImageUrl = "https://s3.amazonaws.com/production.mediajoint.prx.org/public/piece_images/709800/ScratchSniffPodcast_Logo_Orange-02_square.png",
                            Name = "Car Air Freshener",
                            Price = 4.99m,
                            Quantity = 50,
                            TimeMade = new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("Seller")
                        .HasColumnType("boolean");

                    b.Property<string>("StoreDescription")
                        .HasColumnType("text");

                    b.Property<string>("StoreName")
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "Mrthincrisp@gmail.com",
                            Seller = false,
                            StoreDescription = "",
                            StoreName = "",
                            Uid = "Whs5IAAH2wM5wdM8ConMeCP61HC3",
                            UserName = "Mrthincrisp"
                        },
                        new
                        {
                            Id = 2,
                            Email = "johndoe@example.com",
                            Seller = true,
                            StoreDescription = "A trusted store for all your vehicle needs, offering a wide range of products including tires, oils, and accessories.",
                            StoreName = "Doe parts",
                            Uid = "vZWoK9Q49vgj2JIxXU52Muoti0z2",
                            UserName = "Derek"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.OrderItem", b =>
                {
                    b.HasOne("Bangazon.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany("OrderItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.OrderProducts", b =>
                {
                    b.HasOne("Bangazon.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
