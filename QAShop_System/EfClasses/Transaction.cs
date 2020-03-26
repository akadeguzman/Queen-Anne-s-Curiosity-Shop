using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }

        public int? Subtotal { get; set; }
        public int? Tax { get; set; }
        public int? Total { get; set; }
        
        public int PersonId { get; set; }
        public Person PersonLink { get; set; }

        public int TransactionTypeId { get; set; }
        public TransactionType TransactionTypeLink { get; set; }
        
        public ICollection<TransactionItem> TransactionItems { get; set; }
    }
}
