using Hogwarts.DB.Model;
using Hogwarts.View.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationIdentityRole> _roleManager;
        public RoleController(RoleManager<ApplicationIdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult RoleList()
        {
            return View();
        }
        public async Task<IActionResult> Roles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            if (roles!=null)
            {
                List<RoleInfoViewModel> roleData = new List<RoleInfoViewModel>();
                for (int i = 0; i < roles.Count; i++)
                {
                    roleData.Add(new RoleInfoViewModel
                    {
                        RowId = (i + 1).ToString(),
                        RoleId = roles[i].Id,
                        GradeIcon = "icon-vip" + (roles[i].Id),
                        RoleName = roles[i].Name,
                    });
                }
                return Json(new { code = 0, msg = "职位列表", count = roles.Count, data = roleData });
            }
            return Json(new { code = 1, msg = "失败", count = 0, data =string.Empty });
        }
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleAddApi([FromBody]RoleAddViewModel roleAddViewModel)
        {
            if(roleAddViewModel==null)
            {
                return Json("FALSE");
            }
            var role = new ApplicationIdentityRole
            {
                Id = roleAddViewModel.RoleID,
                Name = roleAddViewModel.RoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Json("SUCCEED");
            }
            return Json("FALSE");
        }
        [HttpPost]
        public async Task<IActionResult> RoleDelete(Int32 roleId, string roleName)
        {
            //var roleId = Convert.ToInt32(Request.Form["roleId"]);
            if (roleId > 0)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return Json("SUCCEED");
                    }
                }
            }
            return Json("FALSE!");
        }
    }
}
