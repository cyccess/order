using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cyc.Order.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : BaseController
    {
        private readonly OrderDbContext _context;

        public UserController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("info")]
        public async Task<IActionResult> Info()
        {
            var model = await _context.Shops.SingleOrDefaultAsync(s => s.Id == Sid);
            var regions = await _context.Regions.ToListAsync();
            var res = new ResultModel()
            {
                Code = 100,
                Data = new InfoViewModel
                {
                    Regions = regions,
                    RegionId = model.RegionId,
                    Name = model.Name,
                    Linkman = model.Linkman,
                    Address = model.Address
                }
            };

            return Json(res);
        }

        [Route("save")]
        public async Task<IActionResult> SaveInfo(InfoViewModel model)
        {
            var entity = await _context.Shops.SingleOrDefaultAsync(s => s.Id == Sid);

            entity.RegionId = model.RegionId;
            entity.Name = model.Name;
            entity.Linkman = model.Linkman;
            entity.Address = model.Address;

            await _context.SaveChangesAsync();

            var res = new ResultModel()
            {
                Code = 100,
                Message = "保存成功"
            };

            return Json(res);
        }
    }
}