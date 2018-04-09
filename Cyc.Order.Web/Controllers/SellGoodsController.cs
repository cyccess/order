using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class SellGoodsController : Controller
    {
        private readonly OrderDbContext _context;

        public SellGoodsController(OrderDbContext context)
        {
            _context = context;
        }

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

        [HttpPost]
        public async Task<IActionResult> AddCart(int? goodsId)
        {
            ResultModel model = new ResultModel();

            if (goodsId == null)
            {
                model.Code = 102;
                model.Message = "非法参数";

                return Json(model);
            }

            var cart = new Cart();
            cart.ShopId = 1;
            cart.GoodsId = goodsId.Value;
            cart.Num = 1;
            cart.Status = 1;
            cart.CreateTime = DateTime.Now;
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            model.Code = 100;
            model.Message = "已加入购物车！";
            return Json(model);
        }
    }
}