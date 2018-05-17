using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class GoodsController : Controller
    {
        private readonly OrderDbContext _context;

        private IHostingEnvironment hostingEnv;

        public GoodsController(OrderDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        // GET: Goods
        [Route("/Goods/List")]
        public async Task<IActionResult> Index(string goodsName, int brandId = 0, int page = 1)
        {
            var query = _context.Goods.Where(g => !g.IsDelete);

            if (!string.IsNullOrEmpty(goodsName))
            {
                query = query.Where(s => s.GoodsName.StartsWith(goodsName));
            }
            if (brandId != 0)
            {
                query = query.Where(s => s.BrandId == brandId);

            }
            var viewModel = new GoodsViewModel();
            viewModel.Goods = await query.OrderByDescending(g => g.AddTime).ToPagedListAsync(20, page);
            viewModel.Brands = await _context.Brands.ToListAsync();
            viewModel.GoodsName = goodsName;
            viewModel.BrandId = brandId;

            return View(viewModel);
        }

        // GET: Goods/Details/5
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

        // GET: Goods/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Brands"] = await _context.Brands.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandId,GoodsImg,GoodsCode,GoodsName,GoodsSepc,GoodsUnit,AddTime")] Goods goods, decimal price = 0)
        {
            if (ModelState.IsValid)
            {
                goods.Status = 1;
                goods.IsDelete = false;
                goods.AddTime = DateTime.Now;
                _context.Add(goods);
                await _context.SaveChangesAsync();

                if (price > 0)
                {
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.GoodsId = goods.Id;
                    goodsPrice.Price = price;
                    goodsPrice.ShopId = 0;
                    _context.Add(goodsPrice);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.Include("Brand").SingleOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }

            ViewData["Brands"] = await _context.Brands.ToListAsync();
            var goodsPrice = await _context.GoodsPrices.SingleOrDefaultAsync(p => p.GoodsId == id && p.ShopId == 0);
            ViewData["Price"] = goodsPrice.Price;
            ViewData["Gid"] = goodsPrice.GoodsId;

            return View(goods);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,GoodsImg,GoodsCode,GoodsName,GoodsSepc,GoodsUnit,AddTime")] Goods goods, int gid, decimal price = 0)
        {
            if (id != goods.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    goods.LastUpdateTime = DateTime.Now;
                    goods.IsDelete = false;
                    _context.Update(goods);

                    var goodsPrice = await _context.GoodsPrices.SingleOrDefaultAsync(g => g.GoodsId == gid && g.ShopId == 0);
                    if (goodsPrice != null)
                    {
                        goodsPrice.Price = price;
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsExists(goods.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            goods.IsDelete = true;
            //_context.Goods.Remove(goods);
            await _context.SaveChangesAsync();
            return Json(new { message = "你的商品已删除." });
        }

        [HttpPost]
        [Route("goods/uploadimage")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files["image"];
            var filename = ContentDispositionHeaderValue
                         .Parse(file.ContentDisposition)
                         .FileName
                         .Trim('"');

            var ext = Path.GetExtension(filename);
            var newName = Path.Combine("images", DateTime.Now.Ticks + ext);
            var filePath = hostingEnv.WebRootPath + $@"/{newName}";

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            var host = HttpContext.Request.Host.Value;
            return Json(new { imgPath = $"http://{host}/{newName.Replace(@"\", @"/")}" });
        }


        private bool GoodsExists(int id)
        {
            return _context.Goods.Any(e => e.Id == id);
        }


        private async Task<List<Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

    }
}
