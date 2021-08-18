using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest1.Models
{
    public class Pile
    {
        public int PileID { get; set; }
        public string PileNumber{ get; set;}
        public int CommodityID { get; set; }
        public double GrossWeight { get; set; }
        public double SingleWeight { get; set; }
        public int WarehouseID { get; set; }


    }
}
