using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class BrandController : Controller
    {
        private readonly OrderDbContext _context;

        private IHostingEnvironment hostingEnv;

        public BrandController(OrderDbContext context, IHostingEnvironment env)
        {
            _context = context;
            hostingEnv = env;
        }

        public IActionResult Index()
        {
            var list = _context.Brands.ToList();
            return View(list);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                brand.IsDelete = false;
                brand.AddTime = DateTime.Now;
                _context.Add(brand);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Brands.SingleOrDefaultAsync(m => m.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            if (id != brand.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    brand.IsDelete = false;
                    _context.Update(brand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = new ResultModel();
            var isExistsGoods = _context.Goods.Any(g => g.BrandId == id && g.IsDelete == true);

            if (isExistsGoods)
            {
                model.Code = 0;
                model.Message = "该品牌下包含有商品，无法删除.";
                return Json(model);
            }

            var brand = await _context.Brands.SingleOrDefaultAsync(m => m.Id == id);
            brand.IsDelete = true;
            await _context.SaveChangesAsync();
            model.Message = "品牌已删除.";
            return Json(model);
        }


        [HttpPost]
        [Route("brand/uploadlogo")]
        public IActionResult UploadLogo()
        {
            var file = Request.Form.Files["image"];
            var filename = ContentDispositionHeaderValue
                         .Parse(file.ContentDisposition)
                         .FileName
                         .Trim('"');

            var ext = Path.GetExtension(filename);
            var newName = Path.Combine("images/brand", "cate_" + DateTime.Now.Second + ext);
            var filePath = hostingEnv.WebRootPath + $@"/{newName}";

            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }

            var host = HttpContext.Request.Host.Value;
            return Json(new { url = $"http://{host}/{newName.Replace(@"\", @"/")}", imgPath = $"/{newName.Replace(@"\", @"/")}" });
        }
    }
}