using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class SaleDetailRow
    {
        public int GoodsId { get; set; }

        public string GoodsName { get; set; }

        public int SaleCount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
