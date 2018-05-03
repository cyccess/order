using Cyc.Order.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class OrderRows
    {
        public Data.DataModel.OrderRecord OrderRecord;


        public IList<OrderRecordDetail> OrderRecordDetailList;
    }
}
