using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StudyBuddyApp.Models;

namespace StudyBuddyApp.Data
{
    public partial class StudyBuddyDbContext : DbContext
    {
        public StudyBuddyDbContext()
        {
        }

        public StudyBuddyDbContext(DbContextOptions<StudyBuddyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavoriteQa> FavoriteQAs { get; set; } = null!;
        public virtual DbSet<QuestionAndAnswerDetail> QuestionAndAnswerDetails { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code.
                //You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration
                //- see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings,
                //see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StudyBuddyDb;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteQa>(entity =>
            {
                entity.ToTable("FavoriteQA");

                entity.Property(e => e.FavoriteQaid)
                    .ValueGeneratedNever()
                    .HasColumnName("FavoriteQAId");

                entity.Property(e => e.Qaid).HasColumnName("QAId");
            });

            modelBuilder.Entity<QuestionAndAnswerDetail>(entity =>
            {
                entity.HasKey(e => e.Qaid)
                    .HasName("PK__Question__DFA593A0A502D345");

                entity.ToTable("QuestionAndAnswerDetail");

                entity.Property(e => e.Qaid)
                    .ValueGeneratedNever()
                    .HasColumnName("QAId");

                entity.Property(e => e.Answer).IsUnicode(false);

                entity.Property(e => e.Qacategory)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("QACategory");

                entity.Property(e => e.Question).IsUnicode(false);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__1788CC4C11ED2925");

                entity.ToTable("UserDetail");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
