using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Destination { get; set; }
        public string ShipperInvoiceNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int InsuredValue { get; set; }
        public string InsurerName { get; set; }

        public int ShipperId { get; set; }
        public Shipper ShipperLink { get; set; }

        public ICollection<ShipmentItemVendor> ShipmentItemVendors { get; set; }
    }
}
