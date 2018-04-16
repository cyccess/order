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
    public class OrderController : Controller
    {
        private readonly OrderDbContext _context;

        public OrderController(OrderDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //确认订单
        public async Task<IActionResult> OrderConfirm(int oid)
        {
            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(o => o.Id == oid);

            var orderRecordDetails = await _context.OrderRecordDetails.Where(o => o.OrderId == oid).ToListAsync();

            var shop = await _context.Shops.SingleOrDefaultAsync(s => s.Id == orderRecord.ShopId);

            PreOrderViewModel model = new PreOrderViewModel
            {
                OrderRecord = orderRecord,
                OrderRecordDetails = orderRecordDetails,
                Shop = shop
            };

            return View(model);
        }

        //提交订单
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(int oid)
        {
            var orderInfo = await _context.OrderRecords.SingleOrDefaultAsync(o => o.Id == oid);
            // 获取订单商品
            var orderGoods = await _context.OrderRecordDetails
                .Where(g => g.OrderId == oid)
                .Select(g => g.GoodsId).ToArrayAsync();

            var carts = await _context.Carts
                .Where(c => orderGoods.Contains(c.GoodsId) && c.ShopId == orderInfo.ShopId && c.Status == 0 && c.Checked)
                .ToListAsync();

            // 修改购物车商品状态
            foreach (var item in carts)
            {
                item.Status = 2;
            }

            // 更新订单收货信息
            var shop = await _context.Shops.SingleOrDefaultAsync(s => s.Id == orderInfo.ShopId);
            orderInfo.Consignee = shop.Name;
            orderInfo.Address = shop.Address;
            orderInfo.MobilePhone = shop.Phone;
            orderInfo.Status = (int)OrderStatus.Undelivered; // 更新订单状态
            orderInfo.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync();

            var result = new ResultModel
            {
                Message = "提交订单成功",
                Code = 100,
                Data = "/Order/SubmitOrderSuccess?orderId=" + oid
            };
            return Json(result);
        }

        [HttpGet]
        public IActionResult SubmitOrderSuccess(int orderId)
        {
            ViewData["OrderId"] = orderId;
            return View();
        }
    }
}