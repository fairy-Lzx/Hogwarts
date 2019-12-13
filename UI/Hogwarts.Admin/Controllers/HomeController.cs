using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hogwarts.Admin.Controllers
{
    //[Authorize(Roles = "系统管理员")]
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Main()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
