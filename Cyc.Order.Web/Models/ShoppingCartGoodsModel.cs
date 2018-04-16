using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class ShoppingCartGoodsModel
    {
        public int Id { get; set; }

        public int ShopId { get; set; }

        public int GoodsId { get; set; }

        public int Num { get; set; }

        public bool Checked { get; set; }

        public decimal Price { get; set; }

        public int Status { get; set; }

        public int BrandId { get; set; }

        public string GoodsImg { get; set; }

        public string GoodsCode { get; set; }

        public string GoodsName { get; set; }

        public string GoodsSepc { get; set; }

        public string GoodsUnit { get; set; }

        public string BrandName { get; set; }
    }
}
