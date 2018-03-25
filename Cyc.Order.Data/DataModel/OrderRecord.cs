using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{

    [Table("order_record")]
    public class OrderRecord
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("add_date")]
        public DateTime AddDate { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }
    }

}
