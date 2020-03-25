using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemDescription { get; set; }
        public int InventoryQuantity { get; set; }
       
        public int ItemAvailabilityId { get; set; }
        public ItemAvailability ItemAvailabilityLink { get; set; }

        public int ItemTypeId { get; set; }
        public ItemType ItemTypeLink { get; set; }
        
        public ICollection<ItemVendor> ItemVendors { get; set; }
    }
}
