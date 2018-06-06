using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class SalesViewModel
    {
        public string ShopName { get; set; }
        public string BillDate { get; set; }

        public List<ShopSaleViewModel> ShopSales { get; set; }

        public IEnumerable<SelectListItem> BillDateList { get; set; }
    }
}
