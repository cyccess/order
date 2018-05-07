using Cyc.Order.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class SellGoodViewModel
    {
        public Goods Goods { get; set; }

        public GoodsPrice GoodsPrice { get; set; }
    }
}
