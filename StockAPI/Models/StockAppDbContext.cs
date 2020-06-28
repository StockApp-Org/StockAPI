﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockAPI.Models.Views;

namespace StockAPI.Models
{
    public partial class StockAppDbContext : DbContext
    {
        public StockAppDbContext()
        {
        }

        public StockAppDbContext(DbContextOptions<StockAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompanyStock> CompanyStock { get; set; }
        public virtual DbSet<Industry> Industry { get; set; }
        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<UserAddress> UserAddress { get; set; }
        public virtual DbSet<UserShares> UserShares { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserShareView> UserShareView { get; set; }
        public virtual DbSet<CompanyShareView> CompanyShareView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyShareView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("CompanyShareView");
                entity.Property(si => si.ShareId).HasColumnName("ShareId");
                entity.Property(c => c.CompanyId).HasColumnName("CompanyId");
                entity.Property(i => i.IndustryId).HasColumnName("IndustryId");
            });

            modelBuilder.Entity<UserShareView>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("UserShareView");
                entity.Property(u => u.UserId).HasColumnName("UserId");
                entity.Property(s => s.ShareId).HasColumnName("ShareId");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IndustryId)
                    .HasName("IndustryId");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.IndustryId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Companies_ibfk_1");
            });

            modelBuilder.Entity<CompanyStock>(entity =>
            {
                entity.HasKey(e => e.ShareId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("CompanyId");

                entity.Property(e => e.ShareId).HasColumnType("int(11)");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.SharePrice).HasColumnType("decimal(15,2)");

                entity.Property(e => e.Shares).HasColumnType("int(11)");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyStock)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CompanyStock_ibfk_1");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.IndustryId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.HasKey(e => e.OrgNr)
                    .HasName("PRIMARY");

                entity.Property(e => e.OrgNr)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.AddressId).HasColumnType("int(11)");

                entity.Property(e => e.AddressRow1)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.AddressRow2)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.AddressRow3)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.City)
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.ZipCode)
                    .HasColumnType("varchar(10)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAddress)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserAddress_ibfk_1");
            });

            modelBuilder.Entity<UserShares>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ShareId })
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.ShareId)
                    .HasName("ShareId");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.ShareId).HasColumnType("int(11)");

                entity.Property(e => e.Count).HasColumnType("int(11)");

                entity.HasOne(d => d.Share)
                    .WithMany(p => p.UserShares)
                    .HasForeignKey(d => d.ShareId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("UserShares_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserShares)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserShares_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.OrgNr)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnType("varchar(4000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PersonNr)
                    .HasColumnType("varchar(12)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(25)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}