using Hogwarts.DB.Model;
using Hogwarts.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    public class GradeController : Controller
    {
        private readonly IGradeManager _gradeManager;
        private readonly ICourseManager _courseManager;
        private readonly IStudentManager _studentManager;
        public GradeController(IGradeManager gradeManager, ICourseManager courseManager, IStudentManager studentManager)
        {
            _gradeManager = gradeManager ?? throw new NullReferenceException("IGradeManager服务注入失败");
            _courseManager = courseManager ?? throw new NullReferenceException("IGradeManager服务注入失败");
            _studentManager = studentManager ?? throw new NullReferenceException("IGradeManager服务注入失败");
        }
        public async Task<IActionResult> GradeList()
        {
            List<Course> courses = new List<Course>();
            courses = await _courseManager.GetAllEntities().ToListAsync();
            return View(courses);
        }
        public async Task<IActionResult> Grades(int courseId, int page, int limit)
        {
            int totalCount = 0;
            var grades = await _gradeManager.LoadPageEntities(page, limit, out totalCount, x => true, x => x.Sno, true).Select(x => new
            {
                StudentId = x.Sno,
                StudentName = x.StudentNavigation.Sname,
                EnglishName = x.StudentNavigation.EnglishName,
                CourseId = x.Cno,
                CourseName = x.CourseNavigation.Cname,
                CourseCredit = x.CourseNavigation.CScore,
                Score = x.Score
            }).ToListAsync();
            if (courseId != 0)
            {
                grades = await _gradeManager.LoadPageEntities(page, limit, out totalCount, x => x.Cno == courseId, x => x.Sno, true).Select(x => new
                {
                    StudentId = x.Sno,
                    StudentName = x.StudentNavigation.Sname,
                    EnglishName = x.StudentNavigation.EnglishName,
                    CourseId = x.Cno,
                    CourseName = x.CourseNavigation.Cname,
                    CourseCredit = x.CourseNavigation.CScore,
                    Score = x.Score
                }).ToListAsync();
            }
            if (grades == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < grades.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    StudentId = grades[i].StudentId,
                    StudentName = grades[i].StudentName,
                    EnglishName = grades[i].EnglishName,
                    CourseId = grades[i].CourseId,
                    CourseName = grades[i].CourseName,
                    CourseCredit = grades[i].CourseCredit,
                    Score = grades[i].Score
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public IActionResult AddGrade(Sc viewSc)
        {
            var student = _studentManager.LoadEntities(x => x.Sno == viewSc.Sno).FirstOrDefault();
            var course = _courseManager.LoadEntities(x => x.Cno == viewSc.Cno).FirstOrDefault();
            if (student == null || course == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            if (viewSc == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var sc = _gradeManager.LoadEntities(x => x.Cno == viewSc.Cno && x.Sno == viewSc.Sno).FirstOrDefault();
            if (sc != null)
            {
                sc.Score = viewSc.Score;
                var resultUpddate = _gradeManager.EditEntity(sc);
                if (resultUpddate)
                {
                    return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
                }
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var result = _gradeManager.AddEntity(viewSc);
            if (result != null)
            {
                return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
            }
            else
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
        }
        [HttpPost]
        public IActionResult GetGrade(int studentId, int courseId)
        {
            if (studentId == 0 || courseId == 0)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var sc = _gradeManager.LoadEntities(x => x.Cno == courseId && x.Sno == studentId).FirstOrDefault();
            if (sc == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = 1, data = sc });
        }
        public async Task<IActionResult> SearchByStudentId(int studentId)
        {
            if (studentId == 0)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var scs = await _gradeManager.LoadEntities(x=>x.Sno.ToString().Contains(studentId.ToString())).Include(x => x.CourseNavigation).Include(x => x.StudentNavigation).ToListAsync();
            if (scs == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < scs.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    StudentId = scs[i].Sno,
                    StudentName = scs[i].StudentNavigation.Sname,
                    EnglishName = scs[i].StudentNavigation.EnglishName,
                    CourseId = scs[i].CourseNavigation.Cno,
                    CourseName = scs[i].CourseNavigation.Cname,
                    CourseCredit = scs[i].CourseNavigation.CScore,
                    Score = scs[i].Score
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        [HttpPost]
        public IActionResult DeleteGrade(int studentId, int courseId)
        {
            if (studentId == 0 || courseId == 0)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var sc = _gradeManager.LoadEntities(x => x.Cno == courseId && x.Sno == studentId).FirstOrDefault();
            if (sc == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            var result = _gradeManager.DeleteEntity(sc);
            if (result)
            {
                return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        [HttpPost]
        public IActionResult DeleteGrades(List<int> studentIds,List<int> courseIds)
        {
            int successCount = 0;
            if (studentIds != null && courseIds != null)
            {
                for (int i = 0; i < studentIds.Count; i++)
                {
                    var grades = _gradeManager.LoadEntities(x => x.Sno == studentIds[i] && x.Cno == courseIds[i]).FirstOrDefault();
                    if (grades != null)
                    {
                        var result = _gradeManager.DeleteEntity(grades);
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
        public IActionResult SearchGrade()
        {
            return View();
        }
        public async Task<IActionResult> SearchGradeAccurate(string keyWords)
        {
            if (keyWords == null)
            {
                return Json(new { code = 1, msg = "请输入关键字", count = 0, data = string.Empty });
            }
            var scs = await _gradeManager.LoadEntities(x => x.StudentNavigation.Sno.ToString().Contains(keyWords) || x.StudentNavigation.Sname == keyWords
             || x.StudentNavigation.Province == keyWords || x.StudentNavigation.City == keyWords || x.StudentNavigation.Area == keyWords
                 || x.StudentNavigation.Birthday.ToString() == keyWords || x.StudentNavigation.Year.ToString() == keyWords
                 || x.StudentNavigation.Sex == keyWords || x.StudentNavigation.EnglishName == keyWords || x.StudentNavigation.Character == keyWords
                 || x.StudentNavigation.ClassNavigation.ClassName == keyWords
                 || x.StudentNavigation.ClassId.ToString() == keyWords || x.CourseNavigation.Cno.ToString() == keyWords || x.CourseNavigation.Cname == keyWords
                 || x.CourseNavigation.CScore.ToString() == keyWords).Include(x => x.CourseNavigation).Include(x => x.StudentNavigation).ToListAsync();
            if (scs == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < scs.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    StudentId = scs[i].Sno,
                    StudentName = scs[i].StudentNavigation.Sname,
                    EnglishName = scs[i].StudentNavigation.EnglishName,
                    CourseId = scs[i].CourseNavigation.Cno,
                    CourseName = scs[i].CourseNavigation.Cname,
                    CourseCredit = scs[i].CourseNavigation.CScore,
                    Score = scs[i].Score
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public async Task<IActionResult> SearchGradeFuzzy(string keyWords)
        {
            if (keyWords == null)
            {
                return Json(new { code = 1, msg = "请输入关键字", count = 0, data = string.Empty });
            }
            var scs = await _gradeManager.LoadEntities(x => x.StudentNavigation.Sno.ToString().Contains(keyWords) || x.StudentNavigation.Sname.Contains(keyWords)
                 || ((x.StudentNavigation.Province == null) ? x.StudentNavigation.Province == keyWords : x.StudentNavigation.Province.Contains(keyWords))
                 || ((x.StudentNavigation.City == null) ? x.StudentNavigation.City == keyWords : x.StudentNavigation.City.Contains(keyWords))
                 || ((x.StudentNavigation.Area == null) ? x.StudentNavigation.Area == keyWords : x.StudentNavigation.Area.Contains(keyWords))
                 || x.StudentNavigation.Birthday.ToString().Contains(keyWords) || x.StudentNavigation.Year.ToString().Contains(keyWords)
                 || x.StudentNavigation.Sex == keyWords || x.StudentNavigation.EnglishName.Contains(keyWords) || x.StudentNavigation.Character.Contains(keyWords)
                 || x.StudentNavigation.ClassNavigation.ClassName.Contains(keyWords)
                 || x.StudentNavigation.ClassId.ToString().Contains(keyWords)
                 || x.CourseNavigation.Cno.ToString().Contains(keyWords) || x.CourseNavigation.Cname.Contains(keyWords)
                 || x.CourseNavigation.CScore.ToString().Contains(keyWords)).Include(x => x.CourseNavigation).Include(x => x.StudentNavigation).ToListAsync();
            if (scs == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < scs.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    StudentId = scs[i].Sno,
                    StudentName = scs[i].StudentNavigation.Sname,
                    EnglishName = scs[i].StudentNavigation.EnglishName,
                    CourseId = scs[i].CourseNavigation.Cno,
                    CourseName = scs[i].CourseNavigation.Cname,
                    CourseCredit = scs[i].CourseNavigation.CScore,
                    Score = scs[i].Score
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        public async Task<IActionResult> GetAllGrades()
        {
            var scs = await _gradeManager.GetAllEntities().Include(x=>x.CourseNavigation).Include(x=>x.StudentNavigation).ToListAsync();
            if (scs == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < scs.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    StudentId = scs[i].Sno,
                    StudentName = scs[i].StudentNavigation.Sname,
                    EnglishName = scs[i].StudentNavigation.EnglishName,
                    CourseId = scs[i].CourseNavigation.Cno,
                    CourseName = scs[i].CourseNavigation.Cname,
                    CourseCredit = scs[i].CourseNavigation.CScore,
                    Score = scs[i].Score
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
    }
}
