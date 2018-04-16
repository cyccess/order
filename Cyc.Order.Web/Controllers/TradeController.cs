using Cyc.Order.Data;
using Cyc.Order.Data.DataModel;
using Cyc.Order.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // GET: OrderRecords
        [Route("/Order/List")]
        public async Task<IActionResult> Index(string consignee, string mobilePhone, int status = 0)
        {
            int[] s = { 1, 10, 99 };
            var query = _context.OrderRecords.AsQueryable().Where(o=>s.Contains(o.Status));

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
            model.OrderRecords = await query.ToListAsync();

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
            return Json(new { message = "订单确认发货完成！" });
        }

        [HttpPost, ActionName("CancelOrder")]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var orderRecord = await _context.OrderRecords.SingleOrDefaultAsync(m => m.Id == id);
            orderRecord.Status = (int)OrderStatus.Cancel;
            await _context.SaveChangesAsync();
            return Json(new { message = "订单取消成功！" });
        }

        private bool OrderRecordExists(int id)
        {
            return _context.OrderRecords.Any(e => e.Id == id);
        }
    }
}
