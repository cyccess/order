using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_record_detail")]
    public class OrderRecordDetail
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        [Column("goods_id")]
        public int GoodsId { get; set; }

        [Column("goods_name")]
        public string GoodsName { get; set; }

        [Column("goods_img")]
        public string GoodsImg { get; set; }

        [Column("goods_price")]
        public decimal GoodsPrice { get; set; }

    }
}
