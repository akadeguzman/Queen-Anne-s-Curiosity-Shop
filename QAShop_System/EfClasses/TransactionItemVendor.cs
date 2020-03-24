using System;
using System.Collections.Generic;
using System.Text;

namespace QAShop_System.EfClasses
{
    public class TransactionItemVendor
    {
        public int TransactionItemVendorId { get; set; }
        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        public int Tax { get; set; }
        public int Total { get; set; }
        public string TransactionInvoiceNumber { get; set; }

        public int ItemVendorId { get; set; }
        public ItemVendor ItemVendorLink { get; set; }
    }
}
