using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Course
    {
        public Course()
        {
            Sc = new HashSet<Sc>();
            Teachers = new HashSet<Teacher>();
        }

        public int Cno { get; set; }
        public string Cname { get; set; }
        public string CScore { get; set; }
        public virtual ICollection<Sc> Sc { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
