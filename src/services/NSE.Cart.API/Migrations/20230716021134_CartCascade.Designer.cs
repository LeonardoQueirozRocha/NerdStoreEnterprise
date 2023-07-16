﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NSE.Cart.API.Data;

#nullable disable

namespace NSE.Cart.API.Migrations
{
    [DbContext(typeof(CartContext))]
    [Migration("20230716021134_CartCascade")]
    partial class CartCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NSE.Cart.API.Model.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("NSE.Cart.API.Model.CustomerCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("UsedVoucher")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("IDX_Customer");

                    b.ToTable("CustomerCart");
                });

            modelBuilder.Entity("NSE.Cart.API.Model.CartItem", b =>
                {
                    b.HasOne("NSE.Cart.API.Model.CustomerCart", "CustomerCart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerCart");
                });

            modelBuilder.Entity("NSE.Cart.API.Model.CustomerCart", b =>
                {
                    b.OwnsOne("NSE.Cart.API.Model.Voucher", "Voucher", b1 =>
                        {
                            b1.Property<Guid>("CustomerCartId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Code")
                                .HasColumnType("VARCHAR(50)")
                                .HasColumnName("VoucherCode");

                            b1.Property<int>("DiscountType")
                                .HasColumnType("int")
                                .HasColumnName("DiscountType");

                            b1.Property<decimal?>("DiscountValue")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("DiscountValue");

                            b1.Property<decimal?>("Percentage")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Percentage");

                            b1.HasKey("CustomerCartId");

                            b1.ToTable("CustomerCart");

                            b1.WithOwner()
                                .HasForeignKey("CustomerCartId");
                        });

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("NSE.Cart.API.Model.CustomerCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
