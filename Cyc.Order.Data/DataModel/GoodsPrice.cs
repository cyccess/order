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
        public int GoodsId { get; set; }

        [Column("goods_price")]
        public decimal Price { get; set; }

        [Column("shop_id")]
        public int ShopId { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }
    }
}
