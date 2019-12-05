using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Class
    {
        public Class()
        {
            TbStudent = new HashSet<Student>();
        }

        public int ClassId { get; set; }
        public string CName { get; set; }
        public string Dean { get; set; }

        public virtual ICollection<Student> TbStudent { get; set; }
    }
}
