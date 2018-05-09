using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class GoodPricRow
    {
        public int Id { get; set; }


        public int BrandId { get; set; }


        public string BrandName { get; set; }


        public string GoodsImg { get; set; }

  
        public string GoodsCode { get; set; }


        public string GoodsName { get; set; }


        public string GoodsSepc { get; set; }


        public string GoodsUnit { get; set; }


        public decimal GoodsPrice { get; set; }

    }
}
