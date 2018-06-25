using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class ResultModel
    {
        public ResultModel(int code = 100)
        {
            Code = code;
        }

        public int Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
