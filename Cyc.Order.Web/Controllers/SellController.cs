﻿using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    //[Authorize(Roles = "admin,system")]
    public class SellController : Controller
    {
        private readonly OrderDbContext _context;

        public SellController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("/Sell/List")]
        public async Task<IActionResult> Index()
        {
            var list = await _context.Goods.Include("Brand").Where(g => g.IsDelete).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.Include("Brand")
                .SingleOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }
    }
}