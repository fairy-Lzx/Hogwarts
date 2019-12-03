using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hogwarts.Admin.Controllers
{
    public class AccountController:Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
