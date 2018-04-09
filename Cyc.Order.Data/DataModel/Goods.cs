using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_goods")]
    public class Goods
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("brand_id")]
        public int BrandId { get; set; }

        [Column("goods_img")]
        public string GoodsImg { get; set; }
        
        [Column("goods_code")]
        public string GoodsCode { get; set; }

        [Required]
        [Column("goods_name")]
        public string GoodsName { get; set; }

        [Column("goods_spec")]
        public string GoodsSepc { get; set; }

        [Column("goods_unit")]
        public string GoodsUnit { get; set; }

        [Column("add_time")]
        public DateTime AddTime { get; set; }

        [Column("last_update_time")]
        public DateTime? LastUpdateTime { get; set; }
        
        [Column("status")]
        public int Status { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
