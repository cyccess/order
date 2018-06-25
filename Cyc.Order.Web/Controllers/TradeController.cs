using Cyc.Order.Data;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{

    public class TradeController : Controller
    {
        private readonly OrderDbContext _context;

        public TradeController(OrderDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "admin,system")]
        // GET: OrderRecords
        [Route("/Order/List")]
        public async Task<IActionResult> Index(string consignee, string mobilePhone, int status = 0, int page = 1)
        {
            int[] s = { 1, 10, 99 };
            var query = _context.OrderRecords.AsQueryable().Where(o => s.Contains(o.Status));

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

        [Authorize(Roles = "admin,system")]
        // GET: OrderRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == id);
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


        [Route("/api/Order/MyList")]
        [HttpPost]
        public async Task<IActionResult> MyList(int status = 0, int page = 1)
        {
            int[] s = { 1, 10, 99 };
            var query = _context.OrderRecords
                .Where(o => s.Contains(o.Status));

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

        [Route("/api/Order/Detail")]
        [HttpPost]
        public async Task<IActionResult> OrderDetail(int? orderId)
        {
            if (orderId == null)
            {
                return NotFound();
            }

            var orderRecord = await _context.OrderRecords
                .SingleOrDefaultAsync(m => m.Id == orderId);
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

        [Route("/api/Trade/Delivery")]
        // 确定发货
        [HttpPost, ActionName("Delivery")]
        public async Task<IActionResult> DeliveryConfirmed(int id)
        {
            var orderRecord = await _context.OrderRecords.SingleOrDefaultAsync(m => m.Id == id);
            orderRecord.Status = (int)OrderStatus.Delivered;
            await _context.SaveChangesAsync();
            return Json(new { code = 100, message = "确认发货完成" });
        }

        [Route("/api/Trade/CancelOrder")]
        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderRecord = await _context.OrderRecords.SingleOrDefaultAsync(m => m.Id == id);
            orderRecord.Status = (int)OrderStatus.Cancel;
            await _context.SaveChangesAsync();
            return Json(new { code = 100, message = "订单取消成功" });
        }


        [Authorize(Roles = "admin,system")]
        public async Task<IActionResult> Sales(string shopName, string billDate, int id = 1)
        {
            var currentDate = DateTime.Now.AddMonths(-1);

            if (string.IsNullOrEmpty(billDate))
            {
                billDate = currentDate.ToString("yyyy-MM-dd");
            }

            var tempDate = DateTime.Parse(billDate);
            var fristDate = new DateTime(tempDate.Year, tempDate.Month, 1); //当月第一天
            var lastDate = fristDate.AddMonths(1).AddDays(-1); // 当月最后一天

            var beginDate = new DateTime(2018, 1, 1);

            List<SelectListItem> selectListItem = new List<SelectListItem>();

            for (DateTime dt = beginDate; dt < currentDate; dt = dt.AddMonths(1))
            {
                selectListItem.Add(new SelectListItem
                {
                    Value = dt.ToString("yyyy-MM-dd"),
                    Text = dt.ToString("yyyy年MM月")
                });
            }

            var list = from o in _context.OrderRecords
                       where o.Status == 10 && (o.OrderDate > fristDate && o.OrderDate < lastDate)
                       group o by o.ShopId into g
                       select new
                       {
                           ShopId = g.Key,
                           SaleCount = g.Sum(sc => sc.Num),
                           TotalAmount = g.Sum(ta => ta.TotalAmount)
                       };

            var queryable = from s in _context.Shops
                            join o in list on s.Id equals o.ShopId
                            where 1 == 1 && (string.IsNullOrEmpty(shopName) || s.Name.StartsWith(shopName))
                            select new ShopSaleViewModel
                            {
                                ShopId = s.Id,
                                ShopName = s.Name,
                                SaleCount = o.SaleCount,
                                TotalAmount = o.TotalAmount
                            };

            var res = await queryable.ToListAsync();

            var sales = new SalesViewModel()
            {
                ShopName = shopName,
                BillDate = fristDate.ToString("yyyy-MM-dd"),
                BillDateList = selectListItem,
                ShopSales = res
            };

            return View(sales);
        }

        [Authorize(Roles = "admin,system")]
        public async Task<IActionResult> SaleDetail(int shopId, string billDate, string goodsName)
        {
            var tempDate = DateTime.Parse(billDate);
            var fristDate = tempDate.AddDays(1 - DateTime.Now.Day).Date; //当月第一天
            var lastDate = tempDate.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1); // 当月最后一天

            var queryableOrder = from o in _context.OrderRecords
                                 where o.ShopId == shopId && o.Status == 10 && (o.OrderDate > fristDate && o.OrderDate < lastDate)
                                 select o.Id;

            var orderIds = await queryableOrder.ToArrayAsync();

            var queryableGoods = from o in _context.OrderRecordDetails
                                 where orderIds.Contains(o.OrderId)
                                 && (string.IsNullOrEmpty(goodsName) || o.Name.StartsWith(goodsName))
                                 group o by new { o.GoodsId, o.Name } into g
                                 select new SaleDetailRow
                                 {
                                     GoodsId = g.Key.GoodsId,
                                     GoodsName = g.Key.Name,
                                     SaleCount = g.Sum(sc => sc.Num),
                                     TotalAmount = g.Sum(ta => ta.Num * ta.Price)
                                 };

            var model = new SaleDetailViewModel
            {
                BillDate = billDate,
                ShopId = shopId,
                GoodsName = goodsName,
                SaleDetailRows = await queryableGoods.ToListAsync()
            };

            return View(model);
        }
    }
}
