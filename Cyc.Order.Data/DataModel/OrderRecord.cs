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

        [Column("shop_id")]
        public int ShopId { get; set; }

        [Column("num")]
        public int Num { get; set; }

        [Column("pay_price")]
        public decimal? PayPrice { get; set; }

        [Column("is_pay")]
        public bool? IsPay { get; set; }

        [Column("pay_time")]
        public DateTime? PayTime { get; set; }

        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        [Column("order_date")]
        public DateTime OrderDate { get; set; }

        [Column("status")]
        public int Status { get; set; }

        [Column("end_date")]
        public DateTime? EndDate { get; set; }

        [Column("region_id")]
        public int? RegionId { get; set; }

        [Column("mobile_phone")]
        public string MobilePhone { get; set; }

        [Column("consignee")]
        public string Consignee { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("update_date")]
        public DateTime? UpdateDate { get; set; }
    }
}
