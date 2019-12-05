using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class Harry_textContext : DbContext
    {
        public Harry_textContext()
        {
        }

        public Harry_textContext(DbContextOptions<Harry_textContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbClass> TbClass { get; set; }
        public virtual DbSet<TbCourse> TbCourse { get; set; }
        public virtual DbSet<TbSc> TbSc { get; set; }
        public virtual DbSet<TbStudent> TbStudent { get; set; }
        public virtual DbSet<TbTeacher> TbTeacher { get; set; }
        public virtual DbSet<Tc> Tc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=129.211.76.135;Initial Catalog=Harry_text;User ID=spy;Password=Aa2439739932;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TbClass>(entity =>
            {
                entity.HasKey(e => e.CId);

                entity.ToTable("tb_class");

                entity.Property(e => e.CId)
                    .HasColumnName("c_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .HasColumnName("c_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dean)
                    .HasColumnName("dean")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCourse>(entity =>
            {
                entity.HasKey(e => e.Cno);

                entity.ToTable("tb_course");

                entity.Property(e => e.Cno)
                    .HasColumnName("cno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cname)
                    .HasColumnName("cname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSc>(entity =>
            {
                entity.HasKey(e => new { e.Sno, e.Cno });

                entity.ToTable("tb_SC");

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Cno).HasColumnName("cno");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.CnoNavigation)
                    .WithMany(p => p.TbSc)
                    .HasForeignKey(d => d.Cno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SC_tb_course");

                entity.HasOne(d => d.SnoNavigation)
                    .WithMany(p => p.TbSc)
                    .HasForeignKey(d => d.Sno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SC_tb_student");
            });

            modelBuilder.Entity<TbStudent>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("tb_student");

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Character)
                    .HasColumnName("character")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Classno).HasColumnName("classno");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnName("year");

                entity.HasOne(d => d.ClassnoNavigation)
                    .WithMany(p => p.TbStudent)
                    .HasForeignKey(d => d.Classno)
                    .HasConstraintName("FK_tb_student_tb_class");
            });

            modelBuilder.Entity<TbTeacher>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.ToTable("tb_teacher");

                entity.Property(e => e.TId)
                    .HasColumnName("t_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Cno)
                    .HasColumnName("cno")
                    .HasMaxLength(10);

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasMaxLength(10);

                entity.Property(e => e.TName)
                    .HasColumnName("t_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tc>(entity =>
            {
                entity.HasKey(e => new { e.TId, e.Cno });

                entity.ToTable("TC");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.Cno).HasColumnName("cno");

                entity.HasOne(d => d.CnoNavigation)
                    .WithMany(p => p.Tc)
                    .HasForeignKey(d => d.Cno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_tb_course");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Tc)
                    .HasForeignKey(d => d.TId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TC_tb_teacher");
            });
        }
    }
}
