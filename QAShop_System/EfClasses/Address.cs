using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}
