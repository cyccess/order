using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_goods_price")]
    public class GoodsPrice
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("goods_id")]
        public string GoodsId { get; set; }

        [Column("goods_price")]
        public decimal Price { get; set; }

        [Column("shop_id")]
        public decimal ShopId { get; set; }
    }
}
