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
        public int Id { get; set; }
    }
}
