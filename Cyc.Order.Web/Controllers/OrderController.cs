using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cyc.Order.Web.Models;
using Cyc.Order.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "system")]
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
          
            return View();
        }
        
    }
}
