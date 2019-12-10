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
        public GradeController(IGradeManager gradeManager, ICourseManager courseManager)
        {
            _gradeManager = gradeManager ?? throw new NullReferenceException("IGradeManager服务注入失败");
            _courseManager = courseManager ?? throw new NullReferenceException("IGradeManager服务注入失败");
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
        public IActionResult GetGrade(int studentId,int courseId)
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
                return Json(new { code = 0, msg = "SUCCEED", count = 1, data = string.Empty});
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public IActionResult SearchGrade()
        {
            return View();
        }
    }
}
