using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTest1.Models;

namespace TechTest1.DAL
{
    public class PilesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PilesContext>
    {
        protected override void Seed(PilesContext context)
        {
            var piles = new List<Pile>
            {
                new Pile{PileID = 1, PileNumber = "10", CommodityID = 1,SingleWeight= 12.00, GrossWeight = 120.00, WarehouseID = 1},
                new Pile{PileID = 2, PileNumber = "30", CommodityID = 2,SingleWeight= 12.00, GrossWeight = 140.00, WarehouseID = 2},
                new Pile{PileID = 3, PileNumber = "520", CommodityID = 1,SingleWeight= 12.00, GrossWeight = 600.00, WarehouseID = 3}
            };
            piles.ForEach(p => context.Piles.Add(p));
            context.SaveChanges();
            var commodities = new List<Commodity>
            {
                new Commodity{CommodityID = 1, CommodityCode = "13", CommodityName = "Steel", CommodityWeightRange= 12.00, CommodityIsActive = 1, CommodityExchange = "Manchester"},
                new Commodity{CommodityID = 2, CommodityCode = "15", CommodityName = "Oak", CommodityWeightRange= 8.00, CommodityIsActive = 1, CommodityExchange = "Manchester"}
            };
            commodities.ForEach(c => context.Commodities.Add(c));
            context.SaveChanges();
            var locations = new List<Location> 
            {
               new Location{LocationID = 1,LocationCode = "1", LocationName = "Manchester", LocationAddress1 = "32 Grove Street", LocationAddress2 = "", LocationAddress3 = "", LocationTown = "Manchester", LocationCounty = "Greater Manchester", LocationPostcode = "MN6 7CH", LocationTelephone = "004411111111", LocationEmail = "ManWarehouse@ManchesterWarehouse.com", LocationActive = 1},
               new Location{LocationID = 2,LocationCode = "2", LocationName = "Liverpool", LocationAddress1 = "64 Ash Street", LocationAddress2 = "", LocationAddress3 = "", LocationTown = "Liverpool", LocationCounty = "Merseyside", LocationPostcode = "LI6 7CH", LocationTelephone = "004411111111", LocationEmail = "ManWarehouse@DockyardsLiv.com", LocationActive = 1}
            };
            locations.ForEach(l => context.Locations.Add(l));
            context.SaveChanges();
            var warehouses = new List<Warehouse>
            {
                new Warehouse{WarehouseID = 1, WarehouseCode = "1", WarehouseName = "Manchester Steel Warehouse", CommodityID = 1, WarehouseAddress1 = "32 Grove Street", WarehouseAddress2 = "", WarehouseAddress3 = "", WarehouseTown = "Manchester", WarehouseCounty = "Greater Manchester", WarehousePostcode = "MN6 7CH", WarehouseTelephone = "004411111111", WarehouseEmail = "ManWarehouse@ManchesterWarehouse.com", LocationID = 1},
                new Warehouse{WarehouseID = 2, WarehouseCode = "2", WarehouseName = "Manchester Oak Warehouse", CommodityID = 2, WarehouseAddress1 = "30 Grove Street", WarehouseAddress2 = "", WarehouseAddress3 = "", WarehouseTown = "Manchester", WarehouseCounty = "Greater Manchester", WarehousePostcode = "MN6 7CH", WarehouseTelephone = "004411111111", WarehouseEmail = "ManWarehouse@ManchesterWarehouse.com", LocationID = 1},
                new Warehouse{WarehouseID = 2, WarehouseCode = "3", WarehouseName = "Liverpool Dockyard 1", CommodityID = 1, WarehouseAddress1 = "64 Ash Street", WarehouseAddress2 = "", WarehouseAddress3 = "", WarehouseTown = "Liverpool", WarehouseCounty = "Merseyside", WarehousePostcode = "LI6 7CH", WarehouseTelephone = "004411111111", WarehouseEmail = "ManWarehouse@DockyardsLiv.com", LocationID = 2}
            };
            warehouses.ForEach(w => context.Warehouses.Add(w));
            context.SaveChanges();
        }
    }
}
