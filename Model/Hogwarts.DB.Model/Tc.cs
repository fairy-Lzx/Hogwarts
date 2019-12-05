using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Tc
    {
        public int TId { get; set; }
        public int Cno { get; set; }

        public virtual Course CnoNavigation { get; set; }
        public virtual Teacher T { get; set; }
    }
}
