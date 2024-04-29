﻿// <auto-generated />
using System;
using DatabaseLibrary.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseLibrary.Migrations
{
    [DbContext(typeof(Oblig4Context))]
    partial class Oblig4ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("DatabaseLibrary.Models.Bookingdata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("AntallPersoner")
                        .HasColumnType("INTEGER")
                        .HasColumnName("antall_personer");

                    b.Property<int>("Bruker")
                        .HasColumnType("INTEGER")
                        .HasColumnName("bruker");

                    b.Property<int>("RomId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("rom_id");

                    b.Property<DateTime>("Sluttdato")
                        .HasColumnType("datetime")
                        .HasColumnName("sluttdato");

                    b.Property<DateTime>("Startdato")
                        .HasColumnType("datetime")
                        .HasColumnName("startdato");

                    b.HasKey("Id")
                        .HasName("PK__bookingd__3213E83FFC66BD4D");

                    b.HasIndex("Bruker");

                    b.HasIndex("RomId");

                    b.ToTable("bookingdata", (string)null);
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Brukere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Epost")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("epost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Tlf")
                        .HasColumnType("text")
                        .HasColumnName("tlf");

                    b.HasKey("Id")
                        .HasName("PK__brukere__3213E83F0C61AA8E");

                    b.ToTable("brukere", (string)null);
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Prisdata", b =>
                {
                    b.Property<string>("Kvalitet")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("kvalitet");

                    b.Property<int>("Pris")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pris");

                    b.HasKey("Kvalitet")
                        .HasName("PK__prisdata__6801686609B89173");

                    b.ToTable("prisdata", (string)null);
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Romdata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("AntallSenger")
                        .HasColumnType("INTEGER")
                        .HasColumnName("antall_senger");

                    b.Property<string>("Kvalitet")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("kvalitet");

                    b.HasKey("Id")
                        .HasName("PK__romdata__3213E83F5EF89C12");

                    b.HasIndex("Kvalitet");

                    b.ToTable("romdata", (string)null);
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Bookingdata", b =>
                {
                    b.HasOne("DatabaseLibrary.Models.Brukere", "BrukerNavigation")
                        .WithMany("Bookingdata")
                        .HasForeignKey("Bruker")
                        .IsRequired()
                        .HasConstraintName("FK__bookingda__bruke__07C12930");

                    b.HasOne("DatabaseLibrary.Models.Romdata", "Rom")
                        .WithMany("Bookingdata")
                        .HasForeignKey("RomId")
                        .IsRequired()
                        .HasConstraintName("FK__bookingda__rom_i__06CD04F7");

                    b.Navigation("BrukerNavigation");

                    b.Navigation("Rom");
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Romdata", b =>
                {
                    b.HasOne("DatabaseLibrary.Models.Prisdata", "KvalitetNavigation")
                        .WithMany("Romdata")
                        .HasForeignKey("Kvalitet")
                        .IsRequired()
                        .HasConstraintName("FK__romdata__antall___02084FDA");

                    b.Navigation("KvalitetNavigation");
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Brukere", b =>
                {
                    b.Navigation("Bookingdata");
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Prisdata", b =>
                {
                    b.Navigation("Romdata");
                });

            modelBuilder.Entity("DatabaseLibrary.Models.Romdata", b =>
                {
                    b.Navigation("Bookingdata");
                });
#pragma warning restore 612, 618
        }
    }
}