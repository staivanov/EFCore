﻿// <auto-generated />
using System;
using CarData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarData.Migrations
{
    [DbContext(typeof(CarContext))]
    partial class CarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BrandProductionCountry", b =>
                {
                    b.Property<int>("BrandsBrandId")
                        .HasColumnType("int");

                    b.Property<int>("ProductionCountriesProductionCountryId")
                        .HasColumnType("int");

                    b.HasKey("BrandsBrandId", "ProductionCountriesProductionCountryId");

                    b.HasIndex("ProductionCountriesProductionCountryId");

                    b.ToTable("BrandProductionCountry");
                });

            modelBuilder.Entity("CarDomain.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            Name = "Porsche"
                        },
                        new
                        {
                            BrandId = 2,
                            Name = "BMW"
                        },
                        new
                        {
                            BrandId = 3,
                            Name = "Mercedes"
                        },
                        new
                        {
                            BrandId = 4,
                            Name = "VW"
                        },
                        new
                        {
                            BrandId = 5,
                            Name = "Toyota"
                        },
                        new
                        {
                            BrandId = 6,
                            Name = "Lexus"
                        });
                });

            modelBuilder.Entity("CarDomain.Headquarter", b =>
                {
                    b.Property<int>("HeadquarterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HeadquarterId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HeadquarterId");

                    b.HasIndex("BrandId")
                        .IsUnique();

                    b.ToTable("Headquarter");
                });

            modelBuilder.Entity("CarDomain.Model", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModelId"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("BuildedNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CarDomain.ProductionCountry", b =>
                {
                    b.Property<int>("ProductionCountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionCountryId"), 1L, 1);

                    b.Property<string>("ISO3166Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductionCountryId");

                    b.ToTable("ProductionCountries");
                });

            modelBuilder.Entity("BrandProductionCountry", b =>
                {
                    b.HasOne("CarDomain.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandsBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarDomain.ProductionCountry", null)
                        .WithMany()
                        .HasForeignKey("ProductionCountriesProductionCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarDomain.Headquarter", b =>
                {
                    b.HasOne("CarDomain.Brand", "Brand")
                        .WithOne("Headquarter")
                        .HasForeignKey("CarDomain.Headquarter", "BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarDomain.Model", b =>
                {
                    b.HasOne("CarDomain.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("CarDomain.Brand", b =>
                {
                    b.Navigation("Headquarter")
                        .IsRequired();

                    b.Navigation("Models");
                });
#pragma warning restore 612, 618
        }
    }
}
