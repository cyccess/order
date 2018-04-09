using Cyc.Order.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class OrderRecordViewModel
    {
        public List<OrderRecord> OrderRecords;

        public string consignee { get; set; }

        public string mobilePhone { get; set; }

        public int status { get; set; }
    }
}
