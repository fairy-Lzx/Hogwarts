using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hogwarts.DB.Model
{
    public partial class Teacher
    {
        public Teacher()
        {
            Tc = new HashSet<Tc>();
        }
        [Key]
        public int TId { get; set; }
        public string TName { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Cno { get; set; }
        public virtual ICollection<Tc> Tc { get; set; }
        public ApplicationIdentityUser IdentityUser { get; set; }
    }
}
