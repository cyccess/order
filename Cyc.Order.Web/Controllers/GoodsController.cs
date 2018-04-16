using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
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
        public async Task<IActionResult> Index()
        {
            var list = await _context.Goods.Include("Brand").Where(g => g.IsDelete).ToListAsync();
            return View(list);
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
        public async Task<IActionResult> Create([Bind("Id,BrandId,GoodsImg,GoodsCode,GoodsName,GoodsSepc,GoodsUnit,AddTime")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                goods.Status = 1;
                goods.IsDelete = true;
                goods.AddTime = DateTime.Now;
                _context.Add(goods);
                await _context.SaveChangesAsync();
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

            return View(goods);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BrandId,GoodsImg,GoodsCode,GoodsName,GoodsSepc,GoodsUnit,AddTime")] Goods goods)
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
                    goods.IsDelete = true;
                    _context.Update(goods);
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
            var newName = Path.Combine("images", DateTime.Now.Ticks + ".jpg");
            var filePath = hostingEnv.WebRootPath + $@"\{newName}";

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
