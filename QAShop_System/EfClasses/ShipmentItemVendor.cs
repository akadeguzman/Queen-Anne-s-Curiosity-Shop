using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class ShipmentItemVendor
    {
        public int ShipmentItemVendorId { get; set; }
        public int Value { get; set; }

        public int ShipmentId { get; set; }
        public Shipment ShipmentLink { get; set; }

        public int ItemVendorId { get; set; }
        public ItemVendor ItemVendorLink { get; set; }
        
        public ICollection<Procurement> Procurements { get; set; }
    }
}
