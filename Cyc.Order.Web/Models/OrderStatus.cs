using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus : Int32
    {
        Default = 0,

        /// <summary>
        /// 待发货
        /// </summary>
        Undelivered = 1,


        /// <summary>
        /// 已发货
        /// </summary>
        Delivered = 10,


        /// <summary>
        /// 取消
        /// </summary>
        Cancel = 99
    }
}
