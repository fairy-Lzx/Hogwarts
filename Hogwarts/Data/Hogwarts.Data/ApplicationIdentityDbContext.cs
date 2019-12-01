using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.Data
{
    public class ApplicationIdentityDbContext: IdentityDbContext<ApplicationIdentityUser, ApplicationIdentityRole, string>
    {
        public ApplicationIdentityDbContext(DbContextOptions option):base(option)
        {}
    }
}
