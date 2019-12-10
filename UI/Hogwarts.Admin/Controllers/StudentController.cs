using Hogwarts.DB.Model;
using Hogwarts.IRepository;
using Hogwarts.View.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentManager _studentManager;
        private readonly IClassManager _classManager;
        public StudentController(IStudentManager studentManager, IClassManager classManager)
        {
            _studentManager = studentManager ?? throw new NullReferenceException("空引用异常");
            _classManager = classManager ?? throw new NullReferenceException("空引用异常");
        }
        public IActionResult SchoolRollList()
        {
            return View();
        }
        public async Task<IActionResult> SchoolRolls(int page,int limit)
        {
            var students = _studentManager.GetAllEntities().ToList();
            var schoolRolls =await _studentManager.LoadPageEntities(page, limit, out int totalCount, x => true, x => x.Sno, true).Select(x => new
            {
                StudentId=x.Sno,
                StudentName=x.Sname,
                EnglishName=x.EnglishName,
                Sex=x.Sex,
                Birthday=x.Birthday,
                Year=x.Year,
                ClassName=x.ClassNavigation.ClassName,
                Character=x.Character,
            }).ToListAsync();
            if (schoolRolls == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < schoolRolls.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    schoolRolls[i].StudentId,
                    schoolRolls[i].StudentName,
                    schoolRolls[i].EnglishName,
                    schoolRolls[i].Sex,
                    schoolRolls[i].Birthday,
                    schoolRolls[i].Year,
                    schoolRolls[i].ClassName,
                    schoolRolls[i].Character,
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public IActionResult EditSchoolRoll(int StudentId)
        {
            SchoolRollViewModel viewModel = new SchoolRollViewModel();
            if (StudentId == 0)
            {
                return View(viewModel);
            }
            var student = _studentManager.LoadEntities(x => x.Sno == StudentId).Include(x=>x.ClassNavigation).FirstOrDefault();
            if (student == null)
            {
                return View(viewModel);
            }
            var classes = _classManager.GetAllEntities().ToList();
            if (classes == null)
            {
                return View(viewModel);
            }
            viewModel.Area = student.Area;
            viewModel.Birthday = student.Birthday;
            viewModel.Character = student.Character;
            viewModel.City = student.City;
            viewModel.ClassId = student.ClassId;
            viewModel.Province = student.Province;
            viewModel.Sex = student.Sex;
            viewModel.ClassName = student.ClassNavigation.ClassName;
            viewModel.EnglishName = student.EnglishName;
            viewModel.StudentName = student.Sname;
            viewModel.StudentId = student.Sno;
            viewModel.Password = student.Pwd;
            viewModel.Classes = classes;
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateSchoolRoll(SchoolRollViewModel viewModel)
        {
            if (viewModel == null)
            {
                return Json("FALSE");
            }
            var student = _studentManager.LoadEntities(x => x.Sno == viewModel.StudentId).FirstOrDefault();
            if (student == null)
            {
                return Json("FALSE");
            }
            student.Province = viewModel.Province;
            student.City = viewModel.City;
            student.Area = viewModel.Area;
            student.Birthday = viewModel.Birthday;
            student.Character = viewModel.Character;
            student.ClassId = viewModel.ClassId;
            student.Sname = viewModel.StudentName;
            student.EnglishName = viewModel.EnglishName;
            student.Pwd = viewModel.Password;
            student.Sex = viewModel.Sex;
            var result = _studentManager.EditEntity(student);
            if (result)
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        public IActionResult NewStudentList()
        {
            return View();
        }
        public async Task<IActionResult> NewStudents(int page,int limit)
        {
            var students =await _studentManager.LoadPageEntities(page, limit, out int totalCount, x => x.Year==DateTime.Now.Year, x => x.Sno, true).Select(x => new
            {
                StudentId = x.Sno,
                StudentName = x.Sname,
                EnglishName = x.EnglishName,
                Sex = x.Sex,
                Birthday = x.Birthday,
                Year = x.Year,
                ClassName = x.ClassNavigation.ClassName,
                Character = x.Character,
            }).ToListAsync();
            if (students == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < students.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    students[i].StudentId,
                    students[i].StudentName,
                    students[i].EnglishName,
                    students[i].Sex,
                    students[i].Birthday,
                    students[i].Year,
                    students[i].ClassName,
                    students[i].Character,
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public IActionResult AddStudent(AddStudentViewModel viewModel)
        {
            string StudentId;
            int ClassId = 0;
            switch (viewModel.Character)
            {
                case "正直":
                    ClassId = 1;
                    break;
                case "博学":
                    ClassId = 2;
                    break;
                case "理智":
                    ClassId = 3;
                    break;
                case "勇敢":
                    ClassId = 4;
                    break;
            }
            string yearNow= DateTime.Now.Year.ToString();
            var lastStudent = _studentManager.LoadEntities(x => x.Year == DateTime.Now.Year && x.ClassId == ClassId).LastOrDefault();
            if (lastStudent == null)
            {
                StudentId = yearNow +"0"+ ClassId + "01";
            }
            else
            {
                StudentId = (lastStudent.Sno + 1).ToString();
            }
            Student student = new Student
            {
                Sno = Convert.ToInt32(StudentId),
                ClassId = ClassId,
                EnglishName = viewModel.EnglishName,
                Sname = viewModel.StudentName,
                Pwd = StudentId,
                Character = viewModel.Character,
                Year = DateTime.Now.Year,
                Sex = viewModel.Sex,
            };
            var result = _studentManager.AddEntity(student);
            if (result!=null)
            {
                return Json("SUCCEED");
            }
            else
            {
                return Json("FALSE");
            }
        }
    }
}
