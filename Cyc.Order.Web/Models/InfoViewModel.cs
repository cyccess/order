using Cyc.Order.Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cyc.Order.Web.Models
{
    public class InfoViewModel
    {
        public List<Region> Regions { get; set; }

        public int RegionId { get; set; }
        public string Name { get; set; }
        public string Linkman{ get; set; }
        public string Address { get; set; }
    }
}
