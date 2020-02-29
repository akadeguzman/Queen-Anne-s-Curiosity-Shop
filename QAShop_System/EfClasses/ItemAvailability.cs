using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class ItemAvailability
    {
        public int ItemAvailabilityId { get; set; }
        public string Status { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
