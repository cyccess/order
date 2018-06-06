using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class ShopSaleViewModel
    {
        public string ShopName { get; set; }

        public int SaleCount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
