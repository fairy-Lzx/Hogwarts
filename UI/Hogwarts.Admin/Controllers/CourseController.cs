using Hogwarts.DB.Model;
using Hogwarts.IRepository;
using Hogwarts.View.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    [Authorize(Roles = "系统管理员,校长,院长")]
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseManager _courseManager;
        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        public IActionResult CourseList()
        {
            return View();
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        public async Task<IActionResult> Courses()
        {
            var courses = await _courseManager.GetAllEntities().ToListAsync();
            if (courses == null)
            {
                Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < courses.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    CourseName = courses[i].Cname,
                    CourseId = courses[i].Cno,
                    CourseScore = courses[i].CScore,
                    EnglishName = courses[i].EnglishName,
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        [HttpPost]
        public IActionResult DeleteCourse(int courseId)
        {
            if (courseId == 0)
            {
                return Json("FALSE");
            }
            var course = _courseManager.LoadEntities(x => x.Cno == courseId).FirstOrDefault();
            if (course == null)
            {
                return Json("FALSE");
            }
            if (_courseManager.DeleteEntity(course))
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        public IActionResult AddCourse(int courseId)
        {
            Course course = new Course();
            if (courseId == 0)
            {
                return View(course);
            }
            course = _courseManager.LoadEntities(x => x.Cno == courseId).FirstOrDefault();
            return View(course);
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        [HttpPost]
        public IActionResult AddCourse(CourseAddViewModel viewModel)
        {
            if (viewModel == null)
            {
                return Json("FALSE");
            }
            var oldCourse = _courseManager.LoadEntities(x => x.Cno == viewModel.CourseId).FirstOrDefault();
            if (oldCourse != null)
            {
                oldCourse.Cname = viewModel.CourseName;
                oldCourse.EnglishName = viewModel.EnglishName;
                oldCourse.CScore = viewModel.CourseScore;
                var editEesult = _courseManager.EditEntity(oldCourse);
                if (editEesult)
                {
                    return Json("SUCCEED");
                }
            }
            Course course = new Course
            {
                Cno = viewModel.CourseId,
                Cname = viewModel.CourseName,
                CScore = viewModel.CourseScore,
                EnglishName = viewModel.EnglishName,
            };
            var result = _courseManager.AddEntity(course);
            if (result != null)
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        [HttpPost]
        public IActionResult GetCourse(string courseInfo)
        {
            if (courseInfo == null)
            {
                return Json(new { code = 1, count = 0, msg = "FALSE", data = string.Empty });
            }
            var course = _courseManager.LoadEntities(x => x.Cno.ToString() == courseInfo || x.Cname == courseInfo || x.EnglishName == courseInfo).FirstOrDefault();
            if (course != null)
            {
                return Json(new { code = 0, count = 1, msg = "SUCCEED", data = string.Empty });
            }
            return Json(new { code = 1, count = 0, msg = "FALSE", data = string.Empty });
        }
        public async Task<IActionResult> SearchCourseFuzzy(string keyWords)
        {
            List<Course> courses = new List<Course>();
            if (keyWords == null)
            {
                courses = await _courseManager.GetAllEntities().ToListAsync();
            }
            else
            {
                courses = await _courseManager.LoadEntities(x => x.Cno.ToString().Contains(keyWords) || x.Cname.Contains(keyWords) || x.EnglishName.Contains(keyWords)||x.CScore.Contains(keyWords)).ToListAsync();
            }
            if (courses == null)
            {
                return Json(new { code = 1, count = 0, msg = "FALSE", data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < courses.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    CourseName = courses[i].Cname,
                    CourseId = courses[i].Cno,
                    CourseScore = courses[i].CScore,
                    EnglishName = courses[i].EnglishName,
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        [Authorize(Roles = "系统管理员,校长,院长")]
        public IActionResult DeleteCourses(List<int> courseIds)
        {
            int successCount = 0;
            if (courseIds != null)
            {
                for (int i = 0; i < courseIds.Count; i++)
                {
                    var course = _courseManager.LoadEntities(x => x.Cno == courseIds[i]).FirstOrDefault();
                    if (course != null)
                    {
                        var result = _courseManager.DeleteEntity(course);
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
