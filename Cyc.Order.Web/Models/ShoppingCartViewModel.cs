using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class ShoppingCartViewModel
    {
        public int AmountSum { get; set; }

        public decimal PriceSum { get; set; }

        public bool CheckedAll { get; set; }

        public List<ShoppingCartGoodsModel> ShoppingCartGoodsModels { get; set; }
    }
}
