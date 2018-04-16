using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_cart")]
    public class Cart
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("shop_id")]
        public int ShopId { get; set; }

        [Column("goods_id")]
        public int GoodsId { get; set; }

        [Column("num")]
        public int Num { get; set; }

        /// <summary>
        /// 购车商品状态 0 默认 1 已删除  2 无效
        /// </summary>
        [Column("status")]
        public int Status { get; set; }

        [Column("checked")]
        public bool Checked { get; set; }

        [Column("create_time")]
        public DateTime CreateTime { get; set; }

        [Column("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
