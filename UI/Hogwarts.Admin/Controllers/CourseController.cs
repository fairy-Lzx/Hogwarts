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
    public class CourseController:Controller
    {
        private readonly ICourseManager _courseManager;
        public CourseController(ICourseManager courseManager)
        {
            _courseManager = courseManager;
        }
        public IActionResult CourseList()
        {
            return View();
        }
        public async Task<IActionResult> Courses()
        {
            var courses =await _courseManager.GetAllEntities().ToListAsync();
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
                    CourseName=courses[i].Cname,
                    CourseId=courses[i].Cno,
                    CourseScore= courses[i].CScore
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
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
            if(_courseManager.DeleteEntity(course))
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        public IActionResult AddCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCourse(CourseAddViewModel viewModel)
        {
            if (viewModel == null)
            {
                return Json("FALSE");
            }
            Course course = new Course
            {
                Cno = viewModel.CourseId,
                Cname = viewModel.CourseName,
                CScore = viewModel.CourseScore
            };
            var result = _courseManager.AddEntity(course);
            if(result!=null)
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
    }
}
