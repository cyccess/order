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
                var ox_sid = Request.Cookies["ox_sid"];
                if (!string.IsNullOrEmpty(ox_sid))
                {
                    int id = 0;
                    int.TryParse(ox_sid, out id);
                    sid = id;
                }

                return sid;
            }
            set { sid = value; }
        }
    }
}