using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class ShopsController : Controller
    {
        private readonly OrderDbContext _context;

        public ShopsController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index(string shopName, int regionId = 0, int page = 1)
        {
            var model = new ShopViewModel();

            var query = _context.Shops.Where(s => !s.IsDelete);

            if (!string.IsNullOrEmpty(shopName))
            {
                query = query.Where(s => s.Name == shopName);
            }
            if (regionId != 0)
            {
                query = query.Where(s => s.RegionId == regionId);
            }
            model.Shops = await query.ToPagedListAsync(20, page);
            model.Regions = await _context.Regions.ToListAsync();
            model.RegionId = regionId;
            model.ShopName = shopName;

            return View(model);
        }

        // 获取所有店铺
        [HttpPost]
        public async Task<IActionResult> List()
        {
            var list = await _context.Shops.Where(s => !s.IsDelete)
                .Select(s => new { id = s.Id, name = s.Name })
                .ToListAsync();
            var res = new ResultModel()
            {
                Code = 100,
                Data = list
            };
            return Json(res);
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.Include("Region")
                .SingleOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Regions"] = await _context.Regions.ToListAsync();
            return View();
        }

        // POST: Shops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Linkman,Address,RegionId")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                shop.AddDate = DateTime.Now;
                shop.Password = Utils.MD5Encrypt("888888");
                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shops.SingleOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }
            ViewData["Regions"] = await _context.Regions.ToListAsync();
            return View(shop);
        }

        // POST: Shops/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Password,Linkman,Address,RegionId,AddDate,")] Shop shop)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shop.AddDate = DateTime.Now;
                    _context.Update(shop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
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
            return View(shop);
        }


        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shop = await _context.Shops.SingleOrDefaultAsync(m => m.Id == id);
            shop.IsDelete = true;
            await _context.SaveChangesAsync();
            return Json(new { message = "店铺已删除." });
        }

        private bool ShopExists(int id)
        {
            return _context.Shops.Any(e => e.Id == id);
        }
    }
}
