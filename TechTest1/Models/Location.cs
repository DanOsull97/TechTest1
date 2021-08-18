using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTest1.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationTown { get; set; }
        public string LocationCounty { get; set; }
        public string LocationPostcode { get; set; }
        public string LocationTelephone { get; set; }
        public string LocationEmail { get; set; }
        public int LocationActive { get; set; }
    }
}
