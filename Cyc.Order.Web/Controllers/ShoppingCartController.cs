using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cyc.Order.Web.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly OrderDbContext _context;

        public ShoppingCartController(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var query = from c in _context.Carts
                        join g in _context.Goods.Include("Brand") on c.GoodsId equals g.Id
                        where c.ShopId == 1
                        select new ShoppingCartViewModel
                        {
                            Id = c.Id,
                            ShopId = c.ShopId,
                            GoodsId = c.GoodsId,
                            Num = c.Num,
                            Status = c.Status,
                            CreateTime = c.CreateTime,
                            BrandId = g.BrandId,
                            BrandName = g.Brand.Name,
                            GoodsImg = g.GoodsImg,
                            GoodsName = g.GoodsName,
                            GoodsSepc = g.GoodsSepc,
                            GoodsUnit = g.GoodsUnit,
                            GoodsCode = g.GoodsCode
                        };
            var list = await query.ToListAsync();
            return View(list);
        }
    }
}