using Cyc.Order.Data;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Controllers
{
    [Authorize(Roles = "admin,system")]
    public class TradeController : Controller
    {
        private readonly OrderDbContext _context;

        public TradeController(OrderDbContext context)
        {
            _context = context;
        }

        [Route("/Order/MyList")]
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

        [Route("/Order/Detail")]
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

        // 确定发货
        [HttpPost, ActionName("Delivery")]
        public async Task<IActionResult> DeliveryConfirmed(int id)
        {
            var orderRecord = await _context.OrderRecords.SingleOrDefaultAsync(m => m.Id == id);
            orderRecord.Status = (int)OrderStatus.Delivered;
            await _context.SaveChangesAsync();
            return Json(new { code = 100, message = "确认发货完成" });
        }

        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderRecord = await _context.OrderRecords.SingleOrDefaultAsync(m => m.Id == id);
            orderRecord.Status = (int)OrderStatus.Cancel;
            await _context.SaveChangesAsync();
            return Json(new { code = 100, message = "订单取消成功" });
        }
    }
}
