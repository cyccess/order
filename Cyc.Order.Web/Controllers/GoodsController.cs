using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Microsoft.AspNetCore.Authorization;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class GoodsController : Controller
    {
        private readonly OrderDbContext _context;

        public GoodsController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Goods.Include("Brand").ToListAsync());
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
            var brands = await _context.Brands.ToListAsync();
            ViewData["Brands"] = brands;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BrandId,GoodsImg,GoodsCode,GoodsName,GoodsSepc,GoodsUnit,AddTime")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                goods.Status = 1;
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

            var brands = await _context.Brands.ToListAsync();
            if (goods == null)
            {
                return NotFound();
            }
           
            ViewData["Brands"] = brands;
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

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .SingleOrDefaultAsync(m => m.Id == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _context.Goods.SingleOrDefaultAsync(m => m.Id == id);
            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
