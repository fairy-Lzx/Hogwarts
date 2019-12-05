using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class Tc
    {
        public int TId { get; set; }
        public int Cno { get; set; }

        public virtual TbCourse CnoNavigation { get; set; }
        public virtual TbTeacher T { get; set; }
    }
}
