using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;

namespace SPY.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasOne(l => l.Desk).WithOne(l => l.Student).HasForeignKey<Student>(l => l.DeskID);
            //modelBuilder.Entity<Teacher>().HasOne(l => l.School).WithMany(l => l.Teachers).HasForeignKey(l => l.SchoolID);
            //modelBuilder.Entity<RelationShip>().HasKey(l => new { l.ChildID, l.ParentID });
            //modelBuilder.Entity<Comment>().HasOne(l => l.Article).WithMany(l => l.Comments).HasForeignKey(l => l.ArticleId);
            //modelBuilder.Entity<RelationShip>().HasOne(l => l.Child).WithMany(l => l.RelationShips)
            //    .HasForeignKey(l => l.ChildID);

            //modelBuilder.Entity<RelationShip>().HasOne(l => l.Parent).WithMany(l => l.RelationShips)
            //    .HasForeignKey(l => l.ParentID);
        }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Desk> Desks { get; set; } 
        //public DbSet<Article> Articles { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        //public DbSet<School> Schools { get; set; }
        //public DbSet<Child> children { get; set; }
        //public DbSet<Parent> parents { get; set; }
        //public DbSet<RelationShip> relationShips { get; set; }
        //public DbSet<Comment> Comments{ get; set; }
    }
}