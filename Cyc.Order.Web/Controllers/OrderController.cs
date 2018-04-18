using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cyc.Order.Data;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;

namespace Cyc.Order.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderDbContext _context;

        public OrderController(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string consignee, string mobilePhone, int status = 0, int page = 1)
        {
            int[] s = { 1, 10, 99 };
            var query = _context.OrderRecords.Where(o => o.ShopId == 1 && s.Contains(o.Status));

            if (!string.IsNullOrEmpty(consignee))
            {
                query = query.Where(o => o.Consignee == consignee);
            }

            if (!string.IsNullOrEmpty(mobilePhone))
            {
                query = query.Where(o => o.MobilePhone == mobilePhone);
            }

            if (status != 0)
            {
                query = query.Where(o => o.Status == status);
            }

            query = query.OrderByDescending(o => o.OrderDate);

            var model = new OrderRecordViewModel();
            model.consignee = consignee;
            model.mobilePhone = mobilePhone;
            model.status = status;
            model.OrderRecords = await query.ToPagedListAsync(20, page);

            return View(model);
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == id && m.ShopId == 1);
            if (orderRecord == null)
            {
                return NotFound();
            }

            var orderRecordDetails = await _context.OrderRecordDetails
                .Where(o => o.OrderId == orderRecord.Id)
                .ToListAsync();
            var model = new OrderDetailViewModel();
            model.OrderRecord = orderRecord;
            model.OrderRecordDetails = orderRecordDetails;

            return View(model);
        }

        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == id && m.ShopId == 1);
            orderRecord.Status = (int)OrderStatus.Cancel;
            await _context.SaveChangesAsync();
            return Json(new { message = "订单取消成功！" });
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