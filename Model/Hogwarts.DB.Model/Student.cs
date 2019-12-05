using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Student
    {
        public Student()
        {
            Sc = new HashSet<Sc>();
        }

        public int Sno { get; set; }
        public string Sname { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Year { get; set; }
        public int? ClassId { get; set; }
        public string Character { get; set; }
        public string Pwd { get; set; }

        public virtual Class ClassNavigation { get; set; }
        public virtual ICollection<Sc> Sc { get; set; }
    }
}
