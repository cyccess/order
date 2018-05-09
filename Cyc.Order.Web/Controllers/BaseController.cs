using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Cyc.Order.Web.Controllers
{
    public class BaseController : Controller
    {
        private int sid;

        /// <summary>
        /// 店铺ID
        /// </summary>
        public int Sid
        {
            get
            {
                var cx_sid = Request.Cookies["cx_sid"];
                if (!string.IsNullOrEmpty(cx_sid))
                {
                    int.TryParse(cx_sid, out int id);
                    sid = id;
                }

                return sid;
            }
            set { sid = value; }
        }
    }
}