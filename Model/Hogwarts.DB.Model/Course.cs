using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Course
    {
        public Course()
        {
            Sc = new HashSet<Sc>();
            Tc = new HashSet<Tc>();
        }

        public int Cno { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<Sc> Sc { get; set; }
        public virtual ICollection<Tc> Tc { get; set; }
    }
}
