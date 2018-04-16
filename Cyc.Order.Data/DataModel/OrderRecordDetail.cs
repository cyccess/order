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
        public string Name { get; set; }

        [Column("goods_code")]
        public string Code { get; set; }

        [Column("goods_img")]
        public string Img { get; set; }

        [Column("goods_price")]
        public decimal Price { get; set; }

        [Column("goods_num")]
        public int Num { get; set; }

        [Column("add_date")]
        public DateTime AddDate { get; set; }

    }
}
