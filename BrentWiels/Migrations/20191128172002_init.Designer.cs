﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrentWiels.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20191128172002_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entities.Adres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BusNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gemeente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HuisNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StraatNaam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adressen");
                });

            modelBuilder.Entity("DataLayer.Entities.ContactInformatie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BtwNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TelefoonNummer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Contacten");
                });

            modelBuilder.Entity("DataLayer.Entities.Factuur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BetaaldOp")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Btw")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FactuurNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBetaald")
                        .HasColumnType("bit");

                    b.Property<int?>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Facturen");
                });

            modelBuilder.Entity("DataLayer.Entities.Klant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<int?>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdresId");

                    b.HasIndex("ContactId");

                    b.ToTable("Klanten");
                });

            modelBuilder.Entity("DataLayer.Entities.Offerte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Btw")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KlantId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OfferteNummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VersieNummer")
                        .HasColumnType("int");

                    b.Property<DateTime>("VervalDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("KlantId");

                    b.ToTable("Offertes");
                });

            modelBuilder.Entity("DataLayer.Entities.WerkLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FactuurId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NettoPrijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("OfferteId")
                        .HasColumnType("int");

                    b.Property<int?>("OmschrijvingId")
                        .HasColumnType("int");

                    b.Property<decimal>("PercentageWinst")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FactuurId");

                    b.HasIndex("OfferteId");

                    b.HasIndex("OmschrijvingId");

                    b.ToTable("Werken");
                });

            modelBuilder.Entity("DataLayer.Entities.WerkOmschrijving", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFavoriet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Omschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Omschrijvingen");
                });

            modelBuilder.Entity("DataLayer.Entities.Factuur", b =>
                {
                    b.HasOne("DataLayer.Entities.Klant", "Klant")
                        .WithMany("Facturen")
                        .HasForeignKey("KlantId");
                });

            modelBuilder.Entity("DataLayer.Entities.Klant", b =>
                {
                    b.HasOne("DataLayer.Entities.Adres", "Adres")
                        .WithMany()
                        .HasForeignKey("AdresId");

                    b.HasOne("DataLayer.Entities.ContactInformatie", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("DataLayer.Entities.Offerte", b =>
                {
                    b.HasOne("DataLayer.Entities.Klant", "Klant")
                        .WithMany("Offertes")
                        .HasForeignKey("KlantId");
                });

            modelBuilder.Entity("DataLayer.Entities.WerkLine", b =>
                {
                    b.HasOne("DataLayer.Entities.Factuur", null)
                        .WithMany("Werklijnen")
                        .HasForeignKey("FactuurId");

                    b.HasOne("DataLayer.Entities.Offerte", null)
                        .WithMany("Werklijnen")
                        .HasForeignKey("OfferteId");

                    b.HasOne("DataLayer.Entities.WerkOmschrijving", "Omschrijving")
                        .WithMany()
                        .HasForeignKey("OmschrijvingId");
                });
#pragma warning restore 612, 618
        }
    }
}
