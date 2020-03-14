using System;

namespace QAShop_System.EfClasses
{
    public class Procurement
    {
        public int ProcurementId { get; set; }
        public string Condition { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        
        public int ShipmentItemVendorId { get; set; }
        public ShipmentItemVendor ShipmentItemLink { get; set; }
        
        public int ReceivingClerkId { get; set; }
        public Person ReceivingClerkLink { get; set; }

        public int PurchasingAgentId { get; set; }
        public PurchasingAgent PurchasingAgentLink { get; set; }
    }
}