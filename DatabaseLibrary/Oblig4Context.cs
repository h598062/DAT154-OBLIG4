using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary;

public partial class Oblig4Context : DbContext
{
    public Oblig4Context()
    {
    }

    public Oblig4Context(DbContextOptions<Oblig4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookingdata> Bookingdata { get; set; }

    public virtual DbSet<Prisdata> Prisdata { get; set; }

    public virtual DbSet<Romdata> Romdata { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookingdata>(entity =>
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

            entity.HasOne(d => d.Rom).WithMany(p => p.Bookingdata)
                .HasForeignKey(d => d.RomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bookingda__rom_i__619B8048");
        });

        modelBuilder.Entity<Prisdata>(entity =>
        {
            entity.HasKey(e => e.Kvalitet).HasName("PK__prisdata__680168666BF602A8");

            entity.ToTable("prisdata", "oblig4");

            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");
            entity.Property(e => e.Pris).HasColumnName("pris");
        });

        modelBuilder.Entity<Romdata>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__romdata__3213E83F26FE1B60");

            entity.ToTable("romdata", "oblig4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AntallSenger).HasColumnName("antall_senger");
            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");

            entity.HasOne(d => d.KvalitetNavigation).WithMany(p => p.Romdata)
                .HasForeignKey(d => d.Kvalitet)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__romdata__kvalite__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
