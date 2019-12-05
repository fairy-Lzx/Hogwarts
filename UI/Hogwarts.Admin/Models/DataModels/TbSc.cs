using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class TbSc
    {
        public string Sno { get; set; }
        public int Cno { get; set; }
        public string Score { get; set; }

        public virtual TbCourse CnoNavigation { get; set; }
        public virtual TbStudent SnoNavigation { get; set; }
    }
}
