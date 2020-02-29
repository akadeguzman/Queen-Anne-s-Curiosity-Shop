using System.Collections.Generic;

namespace QAShop_System.EfClasses
{
    public class ItemVendor
    {
        public int ItemVendorId { get; set; }
        public int Price { get; set; }

        public int VendorId { get; set; }
        public Vendor VendorLink { get; set; }

        public int ItemId { get; set; }
        public Item ItemLink { get; set; }

        public ICollection<ShipmentItemVendor> ShipmentItemVendors { get; set; }
        public ICollection<TransactionItemVendor> TransactionItemVendors { get; set; }
    }
}