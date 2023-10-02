using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CrudApp.Models
{
    public partial class mydatabaseContext : DbContext
    {
        public mydatabaseContext()
        {
        }

        public mydatabaseContext(DbContextOptions<mydatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Student1> Students1 { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("student");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Students");

                entity.Property(e => e.FatherName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentGender)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
