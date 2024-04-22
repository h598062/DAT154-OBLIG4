using System;
using System.Collections.Generic;
using DatabaseLibrary.Migrations;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookingdatum> Bookingdata { get; set; }

    public virtual DbSet<Bookingdatum1> Bookingdata1 { get; set; }

    public virtual DbSet<Brukere> Brukeres { get; set; }

    public virtual DbSet<Prisdatum> Prisdata { get; set; }

    public virtual DbSet<Prisdatum1> Prisdata1 { get; set; }

    public virtual DbSet<Romdatum> Romdata { get; set; }

    public virtual DbSet<Romdatum1> Romdata1 { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookingdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bookingd__3213E83FFC66BD4D");

            entity.ToTable("bookingdata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntallPersoner).HasColumnName("antall_personer");
            entity.Property(e => e.Bruker).HasColumnName("bruker");
            entity.Property(e => e.RomId).HasColumnName("rom_id");
            entity.Property(e => e.Sluttdato)
                .HasColumnType("datetime")
                .HasColumnName("sluttdato");
            entity.Property(e => e.Startdato)
                .HasColumnType("datetime")
                .HasColumnName("startdato");

            entity.HasOne(d => d.BrukerNavigation).WithMany(p => p.Bookingdata)
                .HasForeignKey(d => d.Bruker)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__bruke__07C12930");

            entity.HasOne(d => d.Rom).WithMany(p => p.Bookingdata)
                .HasForeignKey(d => d.RomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__rom_i__06CD04F7");
        });

        modelBuilder.Entity<Bookingdatum1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bookingd__3213E83F2E9DE6DA");

            entity.ToTable("bookingdata", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntallPersoner).HasColumnName("antall_personer");
            entity.Property(e => e.Bruker)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("bruker");
            entity.Property(e => e.RomId).HasColumnName("rom_id");
            entity.Property(e => e.Sluttdato)
                .HasColumnType("datetime")
                .HasColumnName("sluttdato");
            entity.Property(e => e.Startdato)
                .HasColumnType("datetime")
                .HasColumnName("startdato");

            entity.HasOne(d => d.Rom).WithMany(p => p.Bookingdatum1s)
                .HasForeignKey(d => d.RomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__rom_i__619B8048");
        });

        modelBuilder.Entity<Brukere>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brukere__3213E83F0C61AA8E");

            entity.ToTable("brukere");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Epost)
                .HasColumnType("text")
                .HasColumnName("epost");
            entity.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnName("name");
            entity.Property(e => e.Tlf)
                .HasColumnType("text")
                .HasColumnName("tlf");
        });

        modelBuilder.Entity<Prisdatum>(entity =>
        {
            entity.HasKey(e => e.Kvalitet).HasName("PK__prisdata__6801686609B89173");

            entity.ToTable("prisdata");

            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");
            entity.Property(e => e.Pris).HasColumnName("pris");
        });

        modelBuilder.Entity<Prisdatum1>(entity =>
        {
            entity.HasKey(e => e.Kvalitet).HasName("PK__prisdata__680168666BF602A8");

            entity.ToTable("prisdata", "oblig4");

            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");
            entity.Property(e => e.Pris).HasColumnName("pris");
        });

        modelBuilder.Entity<Romdatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__romdata__3213E83F5EF89C12");

            entity.ToTable("romdata");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntallSenger).HasColumnName("antall_senger");
            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");

            entity.HasOne(d => d.KvalitetNavigation).WithMany(p => p.Romdata)
                .HasForeignKey(d => d.Kvalitet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__romdata__antall___02084FDA");
        });

        modelBuilder.Entity<Romdatum1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__romdata__3213E83F26FE1B60");

            entity.ToTable("romdata", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntallSenger).HasColumnName("antall_senger");
            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");

            entity.HasOne(d => d.KvalitetNavigation).WithMany(p => p.Romdatum1s)
                .HasForeignKey(d => d.Kvalitet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__romdata__kvalite__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
