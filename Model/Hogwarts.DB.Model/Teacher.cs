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
        }
        [Key]
        public int TId { get; set; }
        public string TName { get; set; }
        public string EnglishName { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public int Cno { get; set; }
        public virtual Course Course { get; set; }
        public ApplicationIdentityUser IdentityUser { get; set; }
    }
}
