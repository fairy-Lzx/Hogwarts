using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hogwarts.DB.Model
{
    public partial class Class
    {
        public Class()
        {
            TbStudent = new HashSet<Student>();
        }
        [Key]
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string Dean { get; set; }

        public virtual ICollection<Student> TbStudent { get; set; }
    }
}
