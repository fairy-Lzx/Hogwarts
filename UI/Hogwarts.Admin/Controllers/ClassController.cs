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
    public class ClassController:Controller
    {
        private readonly IClassManager _classManager;
        public ClassController(IClassManager classManager)
        {
            _classManager = classManager;
        }
        public IActionResult ClassList()
        {
            return View();
        }
        public async Task<IActionResult> Classes()
        {
            var classes =await _classManager.GetAllEntities().Select(x=>new
            {
                x.ClassName,
                ClassDean=x.Dean
            }).ToListAsync();
            List<object> datas = new List<object>();
            for (int i = 0; i < classes.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    classes[i].ClassName,
                    classes[i].ClassDean
                }) ;
            }
            if (classes != null)
            {
                return Json(new { code = 0, msg = "SUCCEED", count = classes.Count, data = datas });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        [HttpGet]
        public IActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(ClassAddViewModel classAdd)
        {
            if (classAdd == null)
            {
                return Json("FALSE");
            }
            var cla = _classManager.LoadEntities(x => x.ClassName == classAdd.ClassName).FirstOrDefault();
            if (cla != null)
            {
                return Json("FALSE");
            }
            var result = _classManager.AddEntity(new DB.Model.Class { ClassName = classAdd.ClassName, Dean = classAdd.ClassDean });
            if (result != null)
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        [HttpPost]
        public IActionResult DeleteClass(string className)
        {
            if (className == null)
            {
                return Json("FALSE");
            }
            var cla = _classManager.LoadEntities(x => x.ClassName == className).FirstOrDefault();
            if (cla != null)
            {
                if (_classManager.DeleteEntity(cla))
                {
                    return Json("SUCCEED");
                }
            }
            return Json("FALSE");
        }
    }
}
