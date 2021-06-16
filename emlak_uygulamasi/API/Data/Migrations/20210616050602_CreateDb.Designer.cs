﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210616050602_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("API.Entities.Emlak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Alan")
                        .HasColumnType("integer");

                    b.Property<int>("BinaKati")
                        .HasColumnType("integer");

                    b.Property<string>("EmlakTuru")
                        .HasColumnType("text");

                    b.Property<string>("Kat")
                        .HasColumnType("text");

                    b.Property<int>("MusteriSaticiId")
                        .HasColumnType("integer");

                    b.Property<int>("OdaSayisi")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturmaTarihi")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("MusteriSaticiId");

                    b.ToTable("Emlak");
                });

            modelBuilder.Entity("API.Entities.IsletmeSahibi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Fax")
                        .HasColumnType("integer");

                    b.Property<string>("IsletmeAdi")
                        .HasColumnType("text");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<int>("TelefonNo")
                        .HasColumnType("integer");

                    b.Property<string>("Yetkili")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmlakIsletmesi");
                });

            modelBuilder.Entity("API.Entities.MusteriAlici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CepTelefonNo")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EvTuru")
                        .HasColumnType("text");

                    b.Property<string>("Isim")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AliciMusteriler");
                });

            modelBuilder.Entity("API.Entities.MusteriSatici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CepTelefonNo")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("EvTuru")
                        .HasColumnType("text");

                    b.Property<string>("Isim")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SaticiMusteriler");
                });

            modelBuilder.Entity("API.Entities.Emlak", b =>
                {
                    b.HasOne("API.Entities.MusteriSatici", "MusteriSatici")
                        .WithMany("EmlakIlanlari")
                        .HasForeignKey("MusteriSaticiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MusteriSatici");
                });

            modelBuilder.Entity("API.Entities.MusteriSatici", b =>
                {
                    b.Navigation("EmlakIlanlari");
                });
#pragma warning restore 612, 618
        }
    }
}