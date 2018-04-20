using Cyc.Order.Data.DataModel;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class ShopViewModel
    {
        public string ShopName { get; set; }

        public int RegionId { get; set; }

        public IList<Region> Regions { get; set; }

        public IPagedList<Shop> Shops { get; set; }
    }
}
