using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Sc
    {
        public int Sno { get; set; }
        public int Cno { get; set; }
        public string Score { get; set; }

        public virtual Course CourseNavigation { get; set; }
        public virtual Student StudentNavigation { get; set; }
    }
}
