using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string CompanyName { get; set; }

        public ICollection<ItemVendor> ItemVendors { get; set; }

        public string GetFullName()
        {
            string fullName = $"{LastName}, {FirstName}";
            return fullName;
        }
    }
}
