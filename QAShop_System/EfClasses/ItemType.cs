using System.Collections.Generic;

namespace QAShop_System.EfClasses
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}