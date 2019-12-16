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
    [Authorize(Roles = "系统管理员,校长")]
    [Authorize]
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
                ClassDean=x.Dean,
                ClassId=x.ClassId,
            }).ToListAsync();
            if (classes == null)
            {
                return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
            }
            List<object> datas = new List<object>();
            for (int i = 0; i < classes.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    ClassId= classes[i].ClassId,
                    classes[i].ClassName,
                    classes[i].ClassDean
                });
            }
            return Json(new { code = 0, msg = "SUCCEED", count = datas.Count, data = datas });
        }
        [HttpGet]
        public IActionResult AddClass(int classId)
        {
            Class @class = new Class();
            if (classId == 0)
            {
                return View(@class);
            }
            @class = _classManager.LoadEntities(x => x.ClassId == classId).FirstOrDefault();
            if (@class == null)
            {
                @class = new Class();
            }
            return View(@class);
        }
        [HttpPost]
        public IActionResult AddClass(ClassAddViewModel classAdd)
        {
            Class cla = new Class();
            if (classAdd == null)
            {
                return Json("FALSE");
            }
            if (classAdd.ClassId != 0)
            {
                cla = _classManager.LoadEntities(x => x.ClassId == classAdd.ClassId).FirstOrDefault();
                if (cla != null)
                {
                    cla.ClassName = classAdd.ClassName;
                    cla.Dean = classAdd.ClassDean;
                    if (_classManager.EditEntity(cla))
                    {
                        return Json("SUCCESS");
                    }
                }
            }
            var result = _classManager.AddEntity(new DB.Model.Class { ClassName = classAdd.ClassName, Dean = classAdd.ClassDean });
            if (result != null)
            {
                return Json("SUCCESS");
            }
            return Json("FALSE");
        }
        [HttpPost]
        public IActionResult DeleteClass(int classId)
        {
            if (classId == 0)
            {
                return Json("FALSE");
            }
            var cla = _classManager.LoadEntities(x => x.ClassId == classId).FirstOrDefault();
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
