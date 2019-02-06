using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CVDotNet.Models
{
    public partial class cvDBContext : DbContext
    {
        public cvDBContext()
        {
        }

        public cvDBContext(DbContextOptions<cvDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<Portfolio> Portfolio { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Work> Work { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=eucnvs121294;database=cvDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("education", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Certificate)
                    .HasColumnName("certificate")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasColumnName("to")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("language", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Percent)
                    .HasColumnName("percent")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Portfolio>(entity =>
            {
                entity.ToTable("portfolio", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Links)
                    .IsRequired()
                    .HasColumnName("links")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Percent)
                    .HasColumnName("percent")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("int(128)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("work", "cvDB");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasColumnName("to")
                    .HasColumnType("date");
            });
        }
    }
}
