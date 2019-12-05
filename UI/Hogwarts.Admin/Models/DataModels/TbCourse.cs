using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class TbCourse
    {
        public TbCourse()
        {
            TbSc = new HashSet<TbSc>();
            Tc = new HashSet<Tc>();
        }

        public int Cno { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<TbSc> TbSc { get; set; }
        public virtual ICollection<Tc> Tc { get; set; }
    }
}
