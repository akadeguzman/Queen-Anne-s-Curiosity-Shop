using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class TransactionItem
    {
        public int TransactionItemId { get; set; }
        public int Quantity { get; set; }

        public int TransactionId { get; set; }
        public Transaction TransactionLink { get; set; }

        public int ItemVendorId { get; set; }
        public ItemVendor ItemVendorLink { get; set; }
    }
}
