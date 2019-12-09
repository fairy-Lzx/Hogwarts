using Hogwarts.Data;
using Hogwarts.DB.Model;
using Hogwarts.IRepository;
using Hogwarts.Repository.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.Repository
{
    public class CourseManager:BaseManager<Course>,ICourseManager
    {
        public CourseManager(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}
