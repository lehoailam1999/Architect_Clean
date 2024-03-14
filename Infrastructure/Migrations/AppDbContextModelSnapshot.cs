﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Model.ProductVariant", b =>
                {
                    b.Property<int>("VariantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VariantId"));

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ShellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("VariantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VariantId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductVariants");
                });

            modelBuilder.Entity("Domain.Model.PropertyDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetailId"));

                    b.Property<string>("DetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<int?>("variantPropertyPropertyId")
                        .HasColumnType("int");

                    b.HasKey("DetailId");

                    b.HasIndex("variantPropertyPropertyId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("Domain.Model.VariantProperty", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PropertyId"));

                    b.Property<string>("PropertyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VariantId")
                        .HasColumnType("int");

                    b.Property<int?>("productVariantVariantId")
                        .HasColumnType("int");

                    b.HasKey("PropertyId");

                    b.HasIndex("productVariantVariantId");

                    b.ToTable("VariantProperties");
                });

            modelBuilder.Entity("Domain.Model.ProductVariant", b =>
                {
                    b.HasOne("Domain.Model.Product", "product")
                        .WithMany("productVariants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("Domain.Model.PropertyDetail", b =>
                {
                    b.HasOne("Domain.Model.VariantProperty", "variantProperty")
                        .WithMany("propertyDetails")
                        .HasForeignKey("variantPropertyPropertyId");

                    b.Navigation("variantProperty");
                });

            modelBuilder.Entity("Domain.Model.VariantProperty", b =>
                {
                    b.HasOne("Domain.Model.ProductVariant", "productVariant")
                        .WithMany("variantProperties")
                        .HasForeignKey("productVariantVariantId");

                    b.Navigation("productVariant");
                });

            modelBuilder.Entity("Domain.Model.Product", b =>
                {
                    b.Navigation("productVariants");
                });

            modelBuilder.Entity("Domain.Model.ProductVariant", b =>
                {
                    b.Navigation("variantProperties");
                });

            modelBuilder.Entity("Domain.Model.VariantProperty", b =>
                {
                    b.Navigation("propertyDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
