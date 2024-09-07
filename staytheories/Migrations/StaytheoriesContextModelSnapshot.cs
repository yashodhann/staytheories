﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using staytheories.Repository;

#nullable disable

namespace staytheories.Migrations
{
    [DbContext(typeof(StaytheoriesContext))]
    partial class StaytheoriesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("staytheories.Model.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductSerial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("staytheories.Model.ProductSale", b =>
                {
                    b.Property<int>("ProductSaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("TenantID")
                        .HasColumnType("int");

                    b.HasKey("ProductSaleID");

                    b.HasIndex("ProductID");

                    b.HasIndex("TenantID");

                    b.ToTable("ProductSales");
                });

            modelBuilder.Entity("staytheories.Model.Tenant", b =>
                {
                    b.Property<int>("TenantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TenantID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("staytheories.Model.ProductSale", b =>
                {
                    b.HasOne("staytheories.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("staytheories.Model.Tenant", "Tenant")
                        .WithMany("ProductSales")
                        .HasForeignKey("TenantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("staytheories.Model.Tenant", b =>
                {
                    b.Navigation("ProductSales");
                });
#pragma warning restore 612, 618
        }
    }
}
