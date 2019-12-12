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
        public async Task<IActionResult> SchoolRolls(int page, int limit)
        {
            var students = _studentManager.GetAllEntities().ToList();
            var schoolRolls = await _studentManager.LoadPageEntities(page, limit, out int totalCount, x => true, x => x.Sno, true).Select(x => new
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
                    Birthday = schoolRolls[i].Birthday,
                    schoolRolls[i].Year,
                    schoolRolls[i].ClassName,
                    schoolRolls[i].Character,
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentManager.GetAllEntities().Select(x => new
            {
                StudentId = x.Sno,
                StudentName = x.Sname,
                EnglishName = x.EnglishName,
                Sex = x.Sex,
                Birthday = x.Birthday,
                Year = x.Year,
                ClassName = x.ClassNavigation.ClassName,
                Character = x.Character,
                Province = x.Province,
                City = x.City,
                Area = x.Area,
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
                    students[i].Province,
                    students[i].City,
                    students[i].Area,

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
            var student = _studentManager.LoadEntities(x => x.Sno == StudentId).Include(x => x.ClassNavigation).FirstOrDefault();
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
            List<Class> classes = _classManager.GetAllEntities().ToList();
            if (classes == null)
            {
                classes = new List<Class>();
            }
            return View(classes);
        }
        public async Task<IActionResult> NewStudents(int page, int limit)
        {
            var students = await _studentManager.LoadPageEntities(page, limit, out int totalCount, x => x.Year == DateTime.Now.Year, x => x.Sno, true).Select(x => new
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
            string yearNow = "2019";
            var cla = _classManager.LoadEntities(x => x.ClassId == viewModel.ClassId).FirstOrDefault();
            if (cla == null)
            {
                return Json("FALSE");
            }

            if (viewModel.Year == 0)
            {
                yearNow = DateTime.Now.Year.ToString();
            }
            else
            {
                yearNow = viewModel.Year.ToString();
            }
            var lastStudent = _studentManager.LoadEntities(x => x.Year.ToString() == yearNow && x.ClassId == viewModel.ClassId).LastOrDefault();
            if (lastStudent == null)
            {
                if (viewModel.ClassId.ToString().Length == 1)
                {
                    StudentId = yearNow + "0" + viewModel.ClassId + "01";
                }
                else
                {
                    StudentId = yearNow + viewModel.ClassId + "01";
                }
            }
            else
            {
                StudentId = (lastStudent.Sno + 1).ToString();
            }
            Student student = new Student
            {
                Sno = Convert.ToInt32(StudentId),
                ClassId = viewModel.ClassId,
                EnglishName = viewModel.EnglishName,
                Sname = viewModel.StudentName,
                Pwd = StudentId,
                Character = viewModel.Character,
                Year = Convert.ToInt32(yearNow),
                Sex = viewModel.Sex,
                Birthday = DateTime.MinValue.ToString("yyyy年MM月dd日"),
            };
            var result = _studentManager.AddEntity(student);
            if (result != null)
            {
                return Json("SUCCEED");
            }
            else
            {
                return Json("FALSE");
            }
        }
        public IActionResult SearchStudent()
        {
            return View();
        }
        public async Task<IActionResult> SearchStudents(string keyWords)
        {
            if (keyWords == null)
            {
                return Json(new { code = 1, msg = "请输入关键字", count = 0, data = string.Empty });
            }
            var students = await _studentManager.LoadEntities(x => x.Sno.ToString() == keyWords || x.Sname == keyWords || x.Province == keyWords || x.City == keyWords || x.Area == keyWords
               || x.Birthday.ToString() == keyWords || x.Year.ToString() == keyWords || x.Sex == keyWords || x.EnglishName == keyWords || x.Character == keyWords || x.ClassNavigation.ClassName == keyWords
               || x.ClassId.ToString() == keyWords).Select(x => new
               {
                   StudentId = x.Sno,
                   StudentName = x.Sname,
                   EnglishName = x.EnglishName,
                   Sex = x.Sex,
                   Birthday = x.Birthday,
                   Year = x.Year,
                   ClassName = x.ClassNavigation.ClassName,
                   Character = x.Character,
                   Province = x.Province,
                   City = x.City,
                   Area = x.Area,
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
                    students[i].Province,
                    students[i].City,
                    students[i].Area,

                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public async Task<IActionResult> FuzzySearchStudents(string keyWords)
        {
            if (keyWords == null)
            {
                return Json(new { code = 1, msg = "请输入关键字", count = 0, data = string.Empty });
            }
            var students = await _studentManager.LoadEntities(x => x.Sno.ToString().Contains(keyWords)
                || x.Sname.Contains(keyWords)
                || ((x.Province == null) ? x.Province == keyWords : x.Province.Contains(keyWords))
                || ((x.City == null) ? x.City == keyWords : x.City.Contains(keyWords))
                || ((x.Area == null) ? x.Area == keyWords : x.Area.Contains(keyWords))
                || x.Birthday.ToString().Contains(keyWords) || x.Year.ToString().Contains(keyWords) || x.Sex == keyWords
                || x.EnglishName.Contains(keyWords) || x.Character.Contains(keyWords)
                || x.ClassNavigation.ClassName.Contains(keyWords)
                || x.ClassId.ToString().Contains(keyWords)
               ).Select(x => new
               {
                   StudentId = x.Sno,
                   StudentName = x.Sname,
                   EnglishName = x.EnglishName,
                   Sex = x.Sex,
                   Birthday = x.Birthday,
                   Year = x.Year,
                   ClassName = x.ClassNavigation.ClassName,
                   Character = x.Character,
                   Province = x.Province,
                   City = x.City,
                   Area = x.Area,
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
                    students[i].Province,
                    students[i].City,
                    students[i].Area,

                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public IActionResult GetStudent(int studentId)
        {
            if (studentId == 0)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var student = _studentManager.LoadEntities(x => x.Sno == studentId).FirstOrDefault();
            if (student == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = 1, data = new { StudentName = student.Sname } });
        }
        public IActionResult Allocate(string character)
        {
            int ClassIndex = 1;
            switch (character)
            {
                case "正直":
                    ClassIndex = 1;
                    break;
                case "博学":
                    ClassIndex = 2;
                    break;
                case "理智":
                    ClassIndex = 3;
                    break;
                case "勇敢":
                    ClassIndex = 4;
                    break;
            }
            var classes = _classManager.GetAllEntities().ToList();
            if (classes == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            if (ClassIndex > classes.Count)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = 0, data = classes[ClassIndex - 1] });
        }
        [HttpPost]
        public IActionResult GetStudentByNane(string StudentName)
        {
            if (StudentName == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var student = _studentManager.LoadEntities(x => x.Sname == StudentName || x.EnglishName == StudentName).FirstOrDefault();
            if (student == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            else
            {
                return Json(new { code = 0, msg = "SUCCEED", count = 0, data = student });
            }
        }
        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            if (studentId != 0)
            {
                var student = _studentManager.LoadEntities(x => x.Sno == studentId).FirstOrDefault();
                if (student != null)
                {
                    var result = _studentManager.DeleteEntity(student);
                    if (result)
                    {
                        return Json(new { code = 0, msg = "SUCCEED", count = 0, data = string.Empty });
                    }
                }
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        [HttpPost]
        public IActionResult DeleteStudents(List<int> studentIds)
        {
            int successCount = 0;
            if (studentIds != null)
            {
                for (int i = 0; i < studentIds.Count; i++)
                {
                    var student = _studentManager.LoadEntities(x => x.Sno == studentIds[i]).FirstOrDefault();
                    if (student != null)
                    {
                        var result = _studentManager.DeleteEntity(student);
                        if (result)
                        {
                            successCount++;
                        }
                    }
                }
                return Json(new { code = 0, msg = "SUCCEED", count = successCount, data = string.Empty });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
    }
}
