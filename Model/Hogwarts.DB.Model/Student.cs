using System;
using System.Collections.Generic;

namespace Hogwarts.DB.Model
{
    public partial class Student
    {
        public Student()
        {
            Sc = new HashSet<Sc>();
        }

        public int Sno { get; set; }
        public string Sname { get; set; }
        public string EnglishName { get; set; }
        public string Sex { get; set; }
        public string Birthday { get; set; }
        public int? Year { get; set; }
        public int? ClassId { get; set; }
        public string Character { get; set; }
        public string Pwd { get; set; }
        /// <summary>
        /// 家庭地址/省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 家庭地址/市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 家庭地址/区
        /// </summary>
        public string Area { get; set; }
        public virtual Class ClassNavigation { get; set; }
        public virtual ICollection<Sc> Sc { get; set; }
    }
}
