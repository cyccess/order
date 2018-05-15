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
    public class OrderController : BaseController
    {
        private readonly OrderDbContext _context;

        public OrderController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("/api/Order")]
        public async Task<IActionResult> Index(int status = 0, int page = 1)
        {
            int[] s = { 1, 10, 99 };
            var query = _context.OrderRecords
                .Where(o => o.ShopId == Sid && s.Contains(o.Status));

            if (status != 0)
            {
                query = query.Where(o => o.Status == status);
            }

            query = query.OrderByDescending(o => o.OrderDate);

            var orderList = await query.Skip((page - 1) * 10).Take(10).ToListAsync();

            var orderIds = orderList.Select(o => o.Id).ToArray();

            var orderDetailList = await _context.OrderRecordDetails
                .Where(o => orderIds.Contains(o.OrderId))
                .ToListAsync();

            List<OrderRows> list = new List<OrderRows>();

            foreach (var item in orderList)
            {
                var row = new OrderRows();
                row.OrderRecord = item;
                row.OrderRecordDetailList = orderDetailList.Where(o => o.OrderId == item.Id).ToList();
                list.Add(row);
            }

            var res = new ResultModel()
            {
                Code = 100,
                Data = list
            };

            return Json(res);
        }

        [Route("/api/Order/Details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == id && m.ShopId == Sid);
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
            var res = new ResultModel()
            {
                Code = 100,
                Data = model
            };
            return Json(res);
        }

        [Route("/api/Order/CancelOrder")]
        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == id && m.ShopId == Sid);
            orderRecord.Status = (int)OrderStatus.Cancel;
            await _context.SaveChangesAsync();
            return Json(new { code = 100, message = "订单取消成功！" });
        }


        //确认订单
        [Route("/api/Order/OrderConfirm")]
        [HttpPost]
        public async Task<IActionResult> OrderConfirm(int oid)
        {
            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(o => o.Id == oid && o.ShopId == Sid);

            var orderRecordDetails = await _context.OrderRecordDetails.Where(o => o.OrderId == oid).ToListAsync();

            var shop = await _context.Shops.SingleOrDefaultAsync(s => s.Id == orderRecord.ShopId);

            PreOrderViewModel model = new PreOrderViewModel
            {
                OrderRecord = orderRecord,
                OrderRecordDetails = orderRecordDetails,
                Shop = shop
            };

            return Json(model);
        }

        //提交订单
        [Route("/api/Order/SubmitOrder")]
        [HttpPost]
        public async Task<IActionResult> SubmitOrder(int oid)
        {
            var orderInfo = await _context.OrderRecords.SingleOrDefaultAsync(o => o.Id == oid && o.ShopId == Sid);
            // 获取订单商品
            var orderGoods = await _context.OrderRecordDetails
                .Where(g => g.OrderId == oid)
                .Select(g => g.GoodsId).ToArrayAsync();

            var carts = await _context.Carts
                .Where(c => orderGoods.Contains(c.GoodsId) && c.ShopId == orderInfo.ShopId && c.Status == 0 && c.Checked)
                .ToListAsync();

            var now = DateTime.Now;

            // 修改购物车商品状态
            foreach (var item in carts)
            {
                item.Status = 2;
                item.UpdateTime = now;
            }

            // 更新订单收货信息
            var shop = await _context.Shops.SingleOrDefaultAsync(s => s.Id == orderInfo.ShopId);
            orderInfo.Consignee = shop.Name;
            orderInfo.Address = shop.Address;
            orderInfo.MobilePhone = shop.Phone;
            orderInfo.Status = (int)OrderStatus.Undelivered; // 更新订单状态
            orderInfo.UpdateDate = now;

            await _context.SaveChangesAsync();

            var result = new ResultModel
            {
                Message = "提交订单成功",
                Code = 100,
                Data = oid
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