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

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("phone")]
        public string Phone { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("linkman")]
        public string Linkman { get; set; }

        [Required]
        [Column("address")]
        public string Address { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("user_type")]
        public byte UserType { get; set; }

        [Column("add_date")]
        public DateTime AddDate { get; set; }

        [Column("is_delete")]
        public bool IsDelete { get; set; }


        public virtual Region Region { get; set; }

    }
}
