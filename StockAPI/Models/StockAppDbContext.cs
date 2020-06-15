using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.IndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Companies_ibfk_1");
            });

            modelBuilder.Entity<CompanyStock>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.CompanyId)
                    .HasName("CompanyId");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.SharePrice).HasColumnType("decimal(15,2)");

                entity.Property(e => e.Shares).HasColumnType("int(11)");

                entity.HasOne(d => d.Company)
                    .WithMany()
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CompanyStock_ibfk_1");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.Property(e => e.IndustryId).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organizations>(entity =>
            {
                entity.HasKey(e => e.OrgNr)
                    .HasName("PRIMARY");

                entity.Property(e => e.OrgNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.UserId)
                    .HasName("UserId");

                entity.Property(e => e.AddressRow1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressRow2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddressRow3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UserAddress_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrgNr)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.PersonNr)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
