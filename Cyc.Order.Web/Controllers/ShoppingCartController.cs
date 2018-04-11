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
            List<ShoppingCartViewModel> list = await Cart();

            TempData["amountSum"] = list.AsEnumerable().Sum(c => c.Num);
            TempData["priceSum"] = list.AsEnumerable().Sum(c => c.Num * c.Price);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> Quantity(int id, string type, int num = 0)
        {
            var entity = await _context.Carts.FindAsync(id);
            entity.UpdateTime = DateTime.Now;

            if (type == "plus")
            {
                entity.Num += 1;
            }
            else if (type == "minus")
            {
                entity.Num -= 1;
            }
            else
            {
                entity.Num = num;
            }
            await _context.SaveChangesAsync();
            List<ShoppingCartViewModel> list = await Cart();

            TempData["amountSum"] = list.AsEnumerable().Sum(c => c.Num);
            TempData["priceSum"] = list.AsEnumerable().Sum(c => c.Num * c.Price);
            return PartialView("_Cart", list);
        }


        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            var entity = await _context.Carts.FindAsync(id);

            _context.Remove(entity);
            await _context.SaveChangesAsync();

            var result = new ResultModel
            {
                Code = 100,
                Message = "删除成功"
            };

            return Json(result);
        }

        private async Task<List<ShoppingCartViewModel>> Cart()
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
                            Price = 10,
                            Status = c.Status,
                            BrandId = g.BrandId,
                            BrandName = g.Brand.Name,
                            GoodsImg = g.GoodsImg,
                            GoodsName = g.GoodsName,
                            GoodsSepc = g.GoodsSepc,
                            GoodsUnit = g.GoodsUnit,
                            GoodsCode = g.GoodsCode
                        };
            var list = await query.ToListAsync();
            return list;
        }
    }
}