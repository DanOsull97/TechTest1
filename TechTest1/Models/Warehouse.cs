using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest1.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public int CommodityID { get; set; }
        public string WarehouseAddress1 { get; set; }
        public string WarehouseAddress2 { get; set; }
        public string WarehouseAddress3 { get; set; }
        public string WarehouseTown { get; set; }
        public string WarehouseCounty { get; set; }
        public string WarehousePostcode { get; set; }
        public string WarehouseTelephone { get; set; }
        public string WarehouseEmail { get; set; }
        public int LocationID { get; set; }
    }
}
