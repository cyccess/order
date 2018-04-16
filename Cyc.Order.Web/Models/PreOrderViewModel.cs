using Cyc.Order.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class PreOrderViewModel
    {

        public OrderRecord OrderRecord { get; set; }

        public List<OrderRecordDetail> OrderRecordDetails { get; set; }

        public Shop Shop { get; set; }
    }
}
