using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTest1.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TechTest1.DAL
{
    public class PilesContext : DbContext
    {
        public PilesContext() : base("PilesContext")
        {

        }
        public DbSet<Pile> Piles { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
}
}
