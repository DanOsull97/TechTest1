using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest1.Models
{
    public class Commodity
    {
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public double CommodityWeightRange { get; set; }
        public int CommodityIsActive { get; set; }
        public string CommodityExchange { get; set; }

    }
}
