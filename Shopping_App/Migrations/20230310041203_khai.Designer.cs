﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_App.Models;

#nullable disable

namespace Shopping_App.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20230310041203_khai")]
    partial class khai
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shopping_App.Models.Bill", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Datetime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("Shopping_App.Models.BillDetails", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IDHD");

                    b.HasIndex("IDSP");

                    b.ToTable("billDetails");
                });

            modelBuilder.Entity("Shopping_App.Models.Cart", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("UserID");

                    b.ToTable("giohang", (string)null);
                });

            modelBuilder.Entity("Shopping_App.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IDSP");

                    b.HasIndex("UserID");

                    b.ToTable("cartDetails");
                });

            modelBuilder.Entity("Shopping_App.Models.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nchar(1000)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("ID");

                    b.ToTable("sanpham", (string)null);
                });

            modelBuilder.Entity("Shopping_App.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.ToTable("chucvu", (string)null);
                });

            modelBuilder.Entity("Shopping_App.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<Guid>("role")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("role");

                    b.ToTable("nguoidung", (string)null);
                });

            modelBuilder.Entity("Shopping_App.Models.Bill", b =>
                {
                    b.HasOne("Shopping_App.Models.User", "User")
                        .WithMany("bill")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping_App.Models.BillDetails", b =>
                {
                    b.HasOne("Shopping_App.Models.Bill", "bill")
                        .WithMany("Details")
                        .HasForeignKey("IDHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping_App.Models.Product", "product")
                        .WithMany("BillDetails")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bill");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Shopping_App.Models.Cart", b =>
                {
                    b.HasOne("Shopping_App.Models.User", "User")
                        .WithOne("Carts")
                        .HasForeignKey("Shopping_App.Models.Cart", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping_App.Models.CartDetail", b =>
                {
                    b.HasOne("Shopping_App.Models.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Product");

                    b.HasOne("Shopping_App.Models.Cart", "Cart")
                        .WithMany("cartdetail")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CART");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shopping_App.Models.User", b =>
                {
                    b.HasOne("Shopping_App.Models.Role", "Roles")
                        .WithMany("Users")
                        .HasForeignKey("role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Shopping_App.Models.Bill", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Shopping_App.Models.Cart", b =>
                {
                    b.Navigation("cartdetail");
                });

            modelBuilder.Entity("Shopping_App.Models.Product", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("Shopping_App.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shopping_App.Models.User", b =>
                {
                    b.Navigation("Carts")
                        .IsRequired();

                    b.Navigation("bill");
                });
#pragma warning restore 612, 618
        }
    }
}
