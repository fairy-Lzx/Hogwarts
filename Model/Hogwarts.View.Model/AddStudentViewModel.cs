using System;
using System.Collections.Generic;
using System.Text;

namespace Hogwarts.View.Model
{
    public class AddStudentViewModel
    {
        public string StudentName { get; set; }
        public string EnglishName { get; set; }
        public string Sex { get; set; }
        public string Character { get; set; }
        public int ClassId { get; set; }
        public int Year { get; set; }
    }
}
