using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderDbContext _context;

        public HomeController(OrderDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login(string returnUrl = null)
        {
            TempData["returnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            var list = new List<dynamic> {
                new { UserName = "admin", Password = "111aaa", Role = "admin" },
                new { UserName = "vip1", Password = "111aaa", Role = "system" }
            };

            var user = list.SingleOrDefault(s => s.UserName == model.UserName && s.Password == model.Password);
            if (user != null)
            {
                //用户标识
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Sid, model.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));

                var authenticationProperties = new AuthenticationProperties()
                {
                    IsPersistent = model.RememberMe
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), authenticationProperties);

                if (returnUrl == null)
                {
                    returnUrl = TempData["returnUrl"]?.ToString();
                }
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
            }
            else
            {
                const string badUserNameOrPasswordMessage = "用户名或密码错误！";
                return BadRequest(badUserNameOrPasswordMessage);
            }
        }

        [Route("/api/Account/Login")]
        [HttpPost]
        public async Task<IActionResult> AccountLogin(LoginViewModel model)
        {
            var res = new ResultModel();

            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                res.Code = 0;
                res.Message = "用户名或密码不能为空";
                return Json(res);
            }

            var password = Utils.MD5Encrypt(model.Password);
            var entity = await _context.Shops.SingleOrDefaultAsync(s => s.Phone == model.UserName && s.Password == password);

            if (entity != null)
            {
                res.Code = 100;
                res.Message = "登录成功";
                res.Data = new { id = entity.Id, username = entity.Phone, userType = entity.UserType, name = entity.Name };
            }
            else
            {
                res.Code = 0;
                res.Message = "用户名或密码错误";
            }

            return Json(res);
        }

        [Route("/api/Account/Register")]
        [HttpPost]
        public async Task<IActionResult> AccountRegister(LoginViewModel model)
        {
            var res = new ResultModel();

            if (!Validate(model.UserName))
            {
                res.Code = 102;
                res.Message = "请输入正确的手机号";
                return Json(res);
            }

            var checkPhone = await _context.Shops.AnyAsync(s => s.Phone == model.UserName);

            if (checkPhone)
            {
                res.Code = 103;
                res.Message = "手机号已存在";
                return Json(res);
            }

            var password = Utils.MD5Encrypt(model.Password);

            var shop = new Shop
            {
                Phone = model.UserName,
                Password = password,
                UserType = 0,
                IsDelete = false,
                AddDate = DateTime.Now
            };

            await _context.AddAsync(shop);
            await _context.SaveChangesAsync();

            res.Code = 100;
            res.Message = "注册成功";
            res.Data = new { id = shop.Id, username = shop.Phone, userType = shop.UserType, name = "" };

            return Json(res);
        }

        private bool Validate(string name)
        {
            return Regex.IsMatch(name, @"^[1][3,4,5,6,7,8,9][0-9]{9}$");
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [HttpGet("denied")]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
