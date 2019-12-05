using System;
using System.Collections.Generic;

namespace Hogwarts.Admin.Models.DataModels
{
    public partial class TbClass
    {
        public TbClass()
        {
            TbStudent = new HashSet<TbStudent>();
        }

        public int CId { get; set; }
        public string CName { get; set; }
        public string Dean { get; set; }

        public virtual ICollection<TbStudent> TbStudent { get; set; }
    }
}
