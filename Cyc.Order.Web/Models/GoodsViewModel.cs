using Cyc.Order.Data.DataModel;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class GoodsViewModel
    {
        public IPagedList<Goods> Goods { get; set; }

        public List<Brand> Brands { get; set; }

        public string GoodsName { get; set; }

        public int BrandId { get; set; }
    }
}
