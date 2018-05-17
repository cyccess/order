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

        [Column("name")]
        public string Name { get; set; }

        [Column("logo")]
        public string Logo { get; set; }
    }

}
