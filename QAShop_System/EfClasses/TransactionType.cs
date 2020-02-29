using System.Collections.Generic;

namespace QAShop_System.EfClasses
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}