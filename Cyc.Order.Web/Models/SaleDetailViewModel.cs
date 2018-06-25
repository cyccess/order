using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class SaleDetailViewModel
    {
        public int ShopId { get; set; }

        public string GoodsName { get; set; }

        public string BillDate { get; set; }

        public List<SaleDetailRow> SaleDetailRows { get; set; }
    }
}
