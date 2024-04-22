using System;
using System.Collections.Generic;
using DatabaseLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLibrary.Context;

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

    public virtual DbSet<Brukere> Brukeres { get; set; }

    public virtual DbSet<Prisdata> Prisdata { get; set; }
    
    public virtual DbSet<Romdata> Romdata { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        
        modelBuilder.Entity<Bookingdata>(entity =>
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

        modelBuilder.Entity<Prisdata>(entity =>
        {
            entity.HasKey(e => e.Kvalitet).HasName("PK__prisdata__6801686609B89173");

            entity.ToTable("prisdata");

            entity.Property(e => e.Kvalitet)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("kvalitet");
            entity.Property(e => e.Pris).HasColumnName("pris");
        });

        modelBuilder.Entity<Romdata>(entity =>
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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
