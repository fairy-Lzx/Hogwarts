using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class TbTeacher
    {
        public TbTeacher()
        {
            Tc = new HashSet<Tc>();
        }

        public int TId { get; set; }
        public string TName { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Cno { get; set; }

        public virtual ICollection<Tc> Tc { get; set; }
    }
}
