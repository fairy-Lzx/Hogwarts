using Hogwarts.Core;
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
    public class AccountController:Controller
    {
        private readonly SignInManager<ApplicationIdentityUser> _signInManager;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        public AccountController(SignInManager<ApplicationIdentityUser> signInManager,UserManager<ApplicationIdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginView)
        {
            if(userLoginView==null)
            {
                //return View("Login",userLoginView);
                return JsonHelper.StandardJsonResult(1, 0, "数据上传失败", new List<object> { });
            }
            if(userLoginView.UserName==null||userLoginView.Password==null)
            {
                //return View("Login", userLoginView);
                return JsonHelper.StandardJsonResult(1, 0, "用户名或密码上传失败", new List<object> { });
            }
            var user =await _userManager.FindByNameAsync(userLoginView.UserName);
            if(user==null)
            {
                //return View("Login", userLoginView);
                return JsonHelper.StandardJsonResult(1, 0, "用户不存在", new List<object>());
            }
            var result =await _signInManager.PasswordSignInAsync(user, userLoginView.Password,false,false);
            if (result.Succeeded)
            {
                //return RedirectToAction("Index", "Home");
                return JsonHelper.StandardJsonResult(0, 0, "登陆成功", new List<object>());
            }
            //return View("Login", userLoginView);
            return JsonHelper.StandardJsonResult(1, 0, "密码错误", new List<object>());
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterApi(UserLoginViewModel viewModel)
        {
            if (viewModel == null)
            {
                return JsonHelper.StandardJsonResult(1, 0, "数据上传失败", new List<object> { });
            }
            if (viewModel.UserName == null || viewModel.Password == null)
            {
                return JsonHelper.StandardJsonResult(1, 0, "用户名或密码上传失败", new List<object> { });
            }
            var identityUser = await _userManager.FindByNameAsync(viewModel.UserName);
            Teacher teacher = new Teacher();
            if (identityUser == null)
            {
                identityUser = new ApplicationIdentityUser
                {
                    UserName = viewModel.UserName,
                    Teacher = teacher,
                };
                var result =await _userManager.CreateAsync(identityUser, viewModel.Password);
                if(result.Succeeded)
                {
                    return JsonHelper.StandardJsonResult(0, 0, "注册成功", new List<object> { });
                }
                else
                {
                    return JsonHelper.StandardJsonResult(1, 0, "注册失败", new List<object> { });
                }
            }
            else
            {
                return JsonHelper.StandardJsonResult(1, 0, "用户已经存在", new List<object> { });
            }
        }
        public async Task<IActionResult> LogOutApi()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult UserList()
        {
            return View();
        }
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.Select(x=>new {
                x.UserName,
                RealName=x.Teacher.TName,
                x.Teacher.EnglishName,
                x.Teacher.Sex,
                x.RoleName
            }).ToListAsync();
            if (users != null)
            {
                List<UserListInfoViewModel> userInfoViews = new List<UserListInfoViewModel>();
                for (int i = 0; i < users.Count; i++)
                {
                    userInfoViews.Add(new UserListInfoViewModel
                    {
                        RowId = i + 1,
                        EnglishName=users[i].EnglishName,
                        RealName=users[i].RealName,
                        RoleName=users[i].RoleName,
                        Sex=users[i].Sex,
                        UserName=users[i].UserName
                    }) ;
                }
                return Json(new { code = 0, msg = "SUCCEED", count = users.Count, data = userInfoViews });
            }
            return Json(new { code = 1, msg = "FALSE", count = 0, data = string.Empty });
        }
        public async Task<IActionResult> AddUser(string userName)
        {
            UserInfoViewModel userInfoViewModel;
            if (userName != null)
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    userInfoViewModel = new UserInfoViewModel
                    {
                        //NickName = user.NickName,
                        //UserDesc = user.UserDescription,
                        //UserEmail = user.Email,
                        //UserGrade = user.RoleName,
                        //UserSex = user.Sex,
                        //UserName = user.UserName,
                        //UserStatus = user.IsInUsing
                    };
                    return View(userInfoViewModel);
                }
            }
            userInfoViewModel = new UserInfoViewModel();
            return View(userInfoViewModel);
        }
    }
}
