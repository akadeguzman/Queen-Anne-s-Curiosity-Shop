using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionItemViewModel : ObservableObject
    {
        //TODO: Update this
        private int _transactionItemVendorId;
        private int _quantity;
        private int _subtotal;
        private int _tax;
        private int _total;
        private string _itemName;
        private string _vendorName;
        private string _transactionInvoiceNumber;

        public int TransactionItemVendorId
        {
            get => _transactionItemVendorId;
            internal set
            {
                _transactionItemVendorId = value;
                RaisePropertyChanged(nameof(TransactionItemVendorId));
            }
        }

        public int Quantity
        {
            get => _quantity;
            internal set
            {
                _transactionItemVendorId = value;
                RaisePropertyChanged(nameof(Quantity));
            }
        }

        public int Subtotal
        {
            get => _subtotal;
            internal set
            {
                _subtotal = value;
                RaisePropertyChanged(nameof(Subtotal));
            }
        }

        public int Tax
        {
            get => _tax;
            internal set
            {
                _tax = value;
                RaisePropertyChanged(nameof(Tax));
            }
        }

        public int Total
        {
            get => _total;
            internal set
            {
                _total = value;
                RaisePropertyChanged(nameof(Total));
            }
        }

        public string VendorName
        {
            get => _vendorName;
            internal set
            {
                _vendorName = value;
                RaisePropertyChanged(nameof(VendorName));
            }
        }

        public string ItemName
        {
            get => _itemName;
            internal set
            {
                _itemName = value;
                RaisePropertyChanged(nameof(ItemName));
            }
        }

        public string TransactionInvoiceNumber
        {
            get => _transactionInvoiceNumber;
            internal set
            {
                _transactionInvoiceNumber = value;
                RaisePropertyChanged(nameof(TransactionInvoiceNumber));
            }
        }

        public int ItemVendorId { get; set; }

        public TransactionItemViewModel(int transactionItemVendorId, 
            int quantity,int subtotal, 
            int tax, int total, string transactionInvoiceNumber, int itemVendorId)
        {
            TransactionItemVendorId = transactionItemVendorId;
            Quantity = quantity;
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            TransactionInvoiceNumber = transactionInvoiceNumber;
            ItemVendorId = itemVendorId;
        }

        public TransactionItemViewModel(TransactionItem transactionItemVendor)
        {
            TransactionItemVendorId = transactionItemVendor.TransactionItemVendorId;
            Quantity = transactionItemVendor.Quantity;
            Subtotal = transactionItemVendor.Subtotal;
            Tax = transactionItemVendor.Tax;
            Total = transactionItemVendor.Total;

            TransactionInvoiceNumber = transactionItemVendor.TransactionInvoiceNumber;
            ItemName = transactionItemVendor.ItemVendorLink.ItemLink.ItemDescription;
            VendorName = transactionItemVendor.ItemVendorLink.VendorLink.CompanyName ??
                         transactionItemVendor.ItemVendorLink.VendorLink.GetFullName();

            ItemVendorId = transactionItemVendor.ItemVendorId;
        }
    }
}