﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Bai1.Models
{
    public partial class QuanLyBenhNhanDBContext : DbContext
    {
        public QuanLyBenhNhanDBContext()
        {
        }

        public QuanLyBenhNhanDBContext(DbContextOptions<QuanLyBenhNhanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BenhNhan> BenhNhans { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-LDTQM3QE\\SQLEXPRESS;Initial Catalog=QuanLyBenhNhanDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<BenhNhan>(entity =>
            {
                entity.HasKey(e => e.MaBn)
                    .HasName("PK__BenhNhan__272475AD6FE5F53C");

                entity.ToTable("BenhNhan");

                entity.Property(e => e.MaBn)
                    .ValueGeneratedNever()
                    .HasColumnName("MaBN");

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.HasOne(d => d.MaKhoaNavigation)
                    .WithMany(p => p.BenhNhans)
                    .HasForeignKey(d => d.MaKhoa)
                    .HasConstraintName("FK__BenhNhan__MaKhoa__267ABA7A");
            });

            modelBuilder.Entity<Khoa>(entity =>
            {
                entity.HasKey(e => e.MaKhoa)
                    .HasName("PK__Khoa__65390405EC1DC4D9");

                entity.ToTable("Khoa");

                entity.Property(e => e.MaKhoa).ValueGeneratedNever();

                entity.Property(e => e.TenKhoa).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
