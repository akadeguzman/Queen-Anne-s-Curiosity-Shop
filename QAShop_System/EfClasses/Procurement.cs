namespace QAShop_System.EfClasses
{
    public class Procurement
    {
        public int ProcurementId { get; set; }
        
        public int ShipmentItemVendorId { get; set; }
        public ShipmentItemVendor ShipmentItemLink { get; set; }
        
        public int PersonId { get; set; }
        public Person PersonLink { get; set; }
    }
}