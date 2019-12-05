using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class TbStudent
    {
        public TbStudent()
        {
            TbSc = new HashSet<TbSc>();
        }

        public string Sno { get; set; }
        public string Sname { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Year { get; set; }
        public int? Classno { get; set; }
        public string Character { get; set; }
        public string Pwd { get; set; }

        public virtual TbClass ClassnoNavigation { get; set; }
        public virtual ICollection<TbSc> TbSc { get; set; }
    }
}
