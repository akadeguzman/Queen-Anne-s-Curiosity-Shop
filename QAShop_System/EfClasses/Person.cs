using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Person
    {
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        
        public int PersonTypeId { get; set; }
        public PersonType PersonTypeLink { get; set; }

        public int AddressId { get; set; }
        public Address AddressLink { get; set; }

        //public int AdditionalContactId { get; set; }
        //public Person PersonLink { get; set; }

        public int? AdditionalContactId { get; set; }
        public virtual Person AdditionalContactLink { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Procurement> Procurements { get; set; }
        public ICollection<Person> Persons { get; set; }

        public string GetFullName()
        {
            var fullName = $"{LastName}, {FirstName}";
            return fullName;
        }
    }
}
