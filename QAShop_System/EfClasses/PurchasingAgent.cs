using System.Collections.Generic;

namespace QAShop_System.EfClasses
{
    public class PurchasingAgent
    {
        public int PurchasingAgentId { get; set; }
        
        public int PersonId { get; set; }
        public Person PersonLink { get; set; }

        public ICollection<Procurement> Procurements { get; set; }
    }
}