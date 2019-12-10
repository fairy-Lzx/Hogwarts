using Hogwarts.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.View.Model
{
    public class SchoolRollViewModel
    {
        public SchoolRollViewModel()
        {
            Classes = new List<Class>();
        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Password { get; set; }
        public string EnglishName { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Year { get; set; }
        public int? ClassId { get; set; }
        public string ClassName { get; set; }
        public string Character { get; set; }
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
        public List<Class> Classes { get; set; }
    }
}
