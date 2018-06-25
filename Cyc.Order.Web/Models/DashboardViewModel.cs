using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class DashboardViewModel
    {
        /// <summary>
        /// 待发货订单
        /// </summary>
        public int AwaitOrderCount { get; set; }

        /// <summary>
        /// 已发货订单
        /// </summary>
        public int SentOrderCount { get; set; }

        /// <summary>
        /// 当月订单数
        /// </summary>
        public int CurrentMonthOrderCount { get; set; }

        /// <summary>
        /// 总订单数
        /// </summary>
        public int TotalOrderCount { get; set; }

        /// <summary>
        /// 商品总数
        /// </summary>
        public int GoodsCount { get; set; }

        /// <summary>
        /// 门店总数
        /// </summary>
        public int ShopCount { get; set; }


        public object OrderData { get; set; }
    }
}
