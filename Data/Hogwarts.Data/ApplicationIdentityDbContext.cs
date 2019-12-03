using Hogwarts.DB.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hogwarts.Data
{
    public class ApplicationIdentityDbContext: IdentityDbContext<Teacher, Role, string>
    {
        public ApplicationIdentityDbContext(DbContextOptions option):base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Teacher>(b =>
            {
                b.ToTable("Teacher");
            });
            builder.Entity<Role>(b =>
            {
                b.ToTable("IdentityRole");
            });
        }
    }
}
