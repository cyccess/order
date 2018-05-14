using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class PriceController : Controller
    {
        private readonly OrderDbContext _context;

        public PriceController(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string goodsName, int brandId = 0, int page = 1)
        {
            var query = from g in _context.Goods
                        join p in _context.GoodsPrices on g.Id equals p.GoodsId
                        where !g.IsDelete && p.ShopId == 0
                        select new GoodPricRow
                        {
                            Id = g.Id,
                            BrandId = g.BrandId,
                            BrandName = g.Brand.Name,
                            GoodsImg = g.GoodsImg,
                            GoodsName = g.GoodsName,
                            GoodsCode = g.GoodsCode,
                            GoodsSepc = g.GoodsSepc,
                            GoodsUnit = g.GoodsUnit,
                            GoodsPrice = p.Price
                        };

            if (!string.IsNullOrEmpty(goodsName))
            {
                query = query.Where(s => s.GoodsName.StartsWith(goodsName));
            }
            if (brandId != 0)
            {
                query = query.Where(s => s.BrandId == brandId);

            }
            var viewModel = new PriceViewModel();
            viewModel.Row = await query.ToPagedListAsync(20, page);
            viewModel.Brands = await _context.Brands.ToListAsync();
            viewModel.GoodsName = goodsName;
            viewModel.BrandId = brandId;

            return View(viewModel);
        }


        public async Task<IActionResult> Details(int id)
        {
            var goods = await _context.Goods.SingleOrDefaultAsync(g => g.Id == id);

            ViewBag.Goods = goods;

            var query = from p in _context.GoodsPrices
                        join s in _context.Shops on p.ShopId equals s.Id
                        into temp
                        from ss in temp.DefaultIfEmpty()
                        where p.GoodsId == id && !p.IsDelete
                        select new PriceDetailViewModel
                        {
                            Id = p.Id,
                            Price = p.Price,
                            ShopName = ss.Name,
                        };
            var list = await query.ToListAsync();
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> ModifyPrice(int id, decimal price)
        {
            var res = new ResultModel();
            var entity = await _context.GoodsPrices
                .SingleOrDefaultAsync(p => p.Id == id && !p.IsDelete);

            entity.Price = price;

            await _context.SaveChangesAsync();
            res.Code = 100;
            res.Message = "价格修改成功";
            return Json(res);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var res = new ResultModel();
            var entity = await _context.GoodsPrices
                .SingleOrDefaultAsync(p => p.Id == id && !p.IsDelete);

            entity.IsDelete = true;

            await _context.SaveChangesAsync();
            res.Code = 100;
            res.Message = "删除成功";
            return Json(res);
        }


        [HttpPost]
        public async Task<IActionResult> Add(int goodsId,int shopId,decimal price)
        {
            var res = new ResultModel();

            var isAdd = await _context.GoodsPrices.AnyAsync(p => p.ShopId == shopId && p.GoodsId == goodsId);

            if (isAdd)
            {
                res.Code = 0;
                res.Message = "店铺价格已存在，请勿重复添加";
                return Json(res);
            }

            var entity = new GoodsPrice
            {
                ShopId = shopId,
                Price = price,
                GoodsId = goodsId,
                IsDelete = false
            };

            _context.Add(entity);

            await _context.SaveChangesAsync();
            res.Code = 100;
            res.Message = "新增成功";
            return Json(res);
        }
    }
}