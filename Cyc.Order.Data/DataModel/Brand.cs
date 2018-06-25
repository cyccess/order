using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_goods_brand")]
    public class Brand
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("logo")]
        public string Logo { get; set; }

        [Column("add_time")]
        public DateTime AddTime { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }
    }

}
