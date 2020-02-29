using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Shipper
    {
        public int ShipperId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperContact { get; set; }
        public string ShipperFax { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}
