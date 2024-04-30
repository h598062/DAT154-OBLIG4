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
    
    // public virtual DbSet<Room> Rooms { get; set; }

    
    public virtual DbSet<Roomservice_requests> Roomservice_requests { get; set; }
    
    public virtual DbSet<Maintenance_requests> Maintenance_requests { get; set; }
    
    public virtual DbSet<Cleaning> Cleaning { get; set; }

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
            entity.Property(e => e.AspNetUser_Id)
                .HasColumnType("nvarchar")
                .HasMaxLength(450)
                .HasDefaultValue(null)
                .HasColumnName("AspNetUser_Id");
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
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasConstraintName("FK__romdata__antall___02084FDA");
        });

        modelBuilder.Entity<Roomservice_requests>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__roomservice_requests__3213E83F5EF89C12");

            entity.ToTable("roomservice_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Room_id).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.Room_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__roomservice_requests__room_id__02084FDA");
        });
        
        modelBuilder.Entity<Maintenance_requests>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__maintenance_requests__3213E83F5EF89C12");

            entity.ToTable("maintenance_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Room_id).HasColumnName("room_id");
            entity.Property(e => e.User_id).HasColumnName("user_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.Room_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maintenance_requests__room_id__02084FDA");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.User_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maintenance_requests__user_id__03006BFF");
        });
        
        /*modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.NumberOfBeds);

            entity.Property(e => e.Quality)
                .IsRequired()
                .HasMaxLength(50);
        });*/
        
        modelBuilder.Entity<Cleaning>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Room_id).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Notes)
                .HasColumnType("text")
                .HasColumnName("notes");

            entity.HasOne(d => d.Room)
                .WithMany()
                .HasForeignKey(d => d.Room_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cleaning__room_id__02084FDA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}