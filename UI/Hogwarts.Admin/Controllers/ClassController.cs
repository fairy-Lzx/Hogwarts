using Hogwarts.IRepository;
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
                x.Dean
            }).ToListAsync();
            List<object> datas = new List<object>();
            for (int i = 0; i < classes.Count; i++)
            {
                datas.Add(new
                {
                    RowId = i + 1,
                    classes[i].ClassName,
                    classes[i].Dean
                }) ;
            }
            if (classes != null)
            {
                return Json(new { code = 0, msg = "SUCCEED", count = classes.Count, data = datas });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public IActionResult AddClass()
        {
            return View();
        }
    }
}
