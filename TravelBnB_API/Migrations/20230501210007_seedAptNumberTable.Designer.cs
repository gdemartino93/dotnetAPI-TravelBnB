﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBnB_API.Data;

#nullable disable

namespace TravelBnB_API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230501210007_seedAptNumberTable")]
    partial class seedAptNumberTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelBnB_API.Models.Apartment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Mq2")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Apartments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "Parcheggio gratuito, Wi-Fi gratuito",
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1498),
                            Details = "Questo appartamento si trova in una posizione panoramica con vista sulla città.",
                            ImageUrl = "https://esempio.com/immagine1.jpg",
                            Mq2 = 80,
                            Name = "Casa David",
                            Occupancy = 4,
                            Rate = 5.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "Aria condizionata, Accesso per disabili",
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1548),
                            Details = "Appartamento moderno nel cuore del centro città.",
                            ImageUrl = "https://esempio.com/immagine2.jpg",
                            Mq2 = 60,
                            Name = "Appartamento Sofia",
                            Occupancy = 3,
                            Rate = 4.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amenity = "Piscina, Giardino, Cucina completamente attrezzata",
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1550),
                            Details = "Villa spaziosa con piscina privata e giardino.",
                            ImageUrl = "https://esempio.com/immagine3.jpg",
                            Mq2 = 150,
                            Name = "Villa Maria",
                            Occupancy = 8,
                            Rate = 5.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amenity = "TV via cavo, Cucinino, Balcone con vista mare",
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1578),
                            Details = "Monolocale accogliente vicino al mare.",
                            ImageUrl = "https://esempio.com/immagine4.jpg",
                            Mq2 = 30,
                            Name = "Monolocale Giovanni",
                            Occupancy = 2,
                            Rate = 3.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amenity = "Palestra, Terrazza, Lavatrice",
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1581),
                            Details = "Appartamento colorato con arredamento moderno.",
                            ImageUrl = "https://esempio.com/immagine5.jpg",
                            Mq2 = 70,
                            Name = "Appartamento Rosa",
                            Occupancy = 4,
                            Rate = 4.0,
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("TravelBnB_API.Models.ApartmentNumber", b =>
                {
                    b.Property<int>("VillaNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VillaNo");

                    b.ToTable("ApartmentNumbers");

                    b.HasData(
                        new
                        {
                            VillaNo = 12,
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1711),
                            SpecialDetails = " parcheggio gratuito",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            VillaNo = 193,
                            CreatedDate = new DateTime(2023, 5, 1, 23, 0, 7, 572, DateTimeKind.Local).AddTicks(1713),
                            SpecialDetails = "piscina coperta",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
