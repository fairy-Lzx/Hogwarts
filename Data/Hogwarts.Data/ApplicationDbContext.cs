using Hogwarts.DB.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions option):base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationIdentityUser>(b =>
            {
                b.ToTable("IdentityUser");
            });
            builder.Entity<ApplicationIdentityRole>(b =>
            {
                b.ToTable("IdentityRole");
            });
            builder.Entity<ApplicationIdentityUser>().HasOne(l => l.Teacher).WithOne(l => l.Identityuser).HasForeignKey<ApplicationIdentityUser>(l => l.Tid);

            builder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.ToTable("tb_class");

                entity.Property(e => e.ClassId)
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

            builder.Entity<Course>(entity =>
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

            builder.Entity<Sc>(entity =>
            {
                entity.HasKey(e => new { e.Sno, e.Cno });

                entity.ToTable("tb_SC");

                entity.Property(e => e.Sno)
                    .HasColumnName("sno");

                entity.Property(e => e.Cno).HasColumnName("cno");

                entity.Property(e => e.Score)
                    .HasColumnName("score")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.CourseNavigation)
                    .WithMany(p => p.Sc)
                    .HasForeignKey(d => d.Cno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SC_tb_course");

                entity.HasOne(d => d.StudentNavigation)
                    .WithMany(p => p.Sc)
                    .HasForeignKey(d => d.Sno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_SC_tb_student");
            });

            builder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Sno);

                entity.ToTable("tb_student");

                entity.Property(e => e.Sno)
                    .HasColumnName("sno")
                    .ValueGeneratedNever();

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("datetime");

                entity.Property(e => e.Character)
                    .HasColumnName("character")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ClassId).HasColumnName("ClassId");

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

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.TbStudent)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_tb_student_tb_class");
            });

            builder.Entity<Teacher>(entity =>
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

            builder.Entity<Tc>(entity =>
            {
                entity.HasKey(e => new { e.TId, e.Cno });

                entity.ToTable("tb_TC");

                entity.Property(e => e.TId).HasColumnName("t_id");

                entity.Property(e => e.Cno).HasColumnName("cno");

                entity.HasOne(d => d.CnoNavigation)
                    .WithMany(p => p.Tc)
                    .HasForeignKey(d => d.Cno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_TC_tb_course");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Tc)
                    .HasForeignKey(d => d.TId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_TC_tb_teacher");
            });

        }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Sc> Sc { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Tc> Tc { get; set; }
    }
}
