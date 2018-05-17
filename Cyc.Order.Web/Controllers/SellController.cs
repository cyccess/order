using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sakura.AspNetCore;

namespace Cyc.Order.Web.Controllers
{
    [Route("api")]
    public class SellController : BaseController
    {
        private readonly OrderDbContext _context;

        public SellController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("Sell/List")]
        public async Task<IActionResult> Index(int page = 1, int brandId = 0)
        {
            var query = _context.Goods
                .Where(g => !g.IsDelete);

            if (brandId != 0)
            {
                query = query.Where(g => g.BrandId == brandId);
            }

            var list = await query.Skip((page - 1) * 10).Take(10).ToListAsync();

            // 获取所有商品Id
            var goodsIds = list.Select(g => g.Id).ToArray();
            // 获取所有商品的价格
            var priceList = await _context.GoodsPrices.Where(p => goodsIds.Contains(p.GoodsId)).ToListAsync();

            List<SellGoodViewModel> sellGoodList = new List<SellGoodViewModel>();
            foreach (var item in list)
            {
                SellGoodViewModel sellGood = new SellGoodViewModel();
                sellGood.Goods = item;
                var entity = priceList.FirstOrDefault(p => p.GoodsId == item.Id && p.ShopId == Sid && !p.IsDelete);
                if (entity != null)
                {
                    sellGood.GoodsPrice = entity;
                }
                else
                {
                    // 取商品默认价格
                    entity = priceList.FirstOrDefault(p => p.GoodsId == item.Id && p.ShopId == 0);
                    if (entity != null)
                    {
                        sellGood.GoodsPrice = entity;
                    }
                }
                sellGoodList.Add(sellGood);
            }

            var res = new ResultModel();
            res.Code = 100;
            res.Data = sellGoodList;
            if (sellGoodList.Count == 0)
                res.Code = 0;

            return Json(res);
        }

        [Route("Sell/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.Include("Brand")
                .SingleOrDefaultAsync(m => m.Id == id && !m.IsDelete);
            var price = 0.0m;

            var entity = await _context.GoodsPrices.FirstOrDefaultAsync(p => p.GoodsId == goods.Id && p.ShopId == Sid && !p.IsDelete);
            if (entity != null)
            {
                price = entity.Price;
            }
            else
            {
                // 取商品默认价格
                entity = await _context.GoodsPrices.FirstOrDefaultAsync(p => p.GoodsId == goods.Id && p.ShopId == 0);
                if (entity != null)
                {
                    price = entity.Price;
                }
            }

            var model = new { goods = goods, price = price };

            var res = new ResultModel()
            {
                Code = 100,
                Data = model
            };
            return Json(res);
        }

        [HttpPost("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            var list = await _context.Brands.ToListAsync();
            var model = new ResultModel();
            model.Code = 100;
            model.Data = list;
            return Json(model);
        }
    }
}