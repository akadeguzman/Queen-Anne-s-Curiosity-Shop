using System.Collections.Generic;

namespace QAShop_System.EfClasses
{
    public class PersonType
    {
        public int PersonTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Person> Persons { get; set; }
    }
}