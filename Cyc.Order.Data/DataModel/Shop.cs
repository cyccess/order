using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cyc.Order.Data.DataModel
{
    [Table("order_shop")]
    public class Shop
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("add_date")]
        public DateTime AddDate { get; set; }

    }
}
