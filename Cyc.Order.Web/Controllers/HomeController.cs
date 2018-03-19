using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cyc.Order.Web.Models;
using Cyc.Order.Data;

namespace Cyc.Order.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly DbContext context;
         



        public HomeController(DbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var a = context.Goods.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
