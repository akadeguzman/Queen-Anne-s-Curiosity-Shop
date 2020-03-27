using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionItemViewModel : ObservableObject
    {
        private int _transactionItemId;
        private int _itemId;
        private int _quantity;
        private int _price;
        private string _itemName;
        private string _vendorName;

        public int TransactionItemId
        {
            get => _transactionItemId;
            internal set
            {
                _transactionItemId = value;
                RaisePropertyChanged(nameof(TransactionItemId));
            }
        }

        public int ItemId
        {
            get => _itemId;
            internal set
            {
                _itemId = value;
                RaisePropertyChanged(nameof(ItemId));
            }
        }

        public int Quantity
        {
            get => _quantity;
            internal set
            {
                _quantity = value;
                RaisePropertyChanged(nameof(Quantity));
            }
        }

        public int Price
        {
            get => _price;
            internal set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
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
        
        public int ItemVendorId { get; set; }
        public int TransactionId { get; set; }

        public TransactionItemViewModel(int transactionItemId, 
            int quantity,  int transactionId,  int itemVendorId)
        {
            TransactionItemId = transactionItemId;
            Quantity = quantity;
            TransactionId = transactionId;
            ItemVendorId = itemVendorId;
        }

        public TransactionItemViewModel(TransactionItem transactionItemVendor)
        {
            TransactionItemId = transactionItemVendor.TransactionItemId;
            Quantity = transactionItemVendor.Quantity;

            Price = transactionItemVendor.ItemVendorLink.Price;
            ItemId = transactionItemVendor.ItemVendorLink.ItemId;
            ItemName = transactionItemVendor.ItemVendorLink.ItemLink.ItemDescription;
            VendorName = transactionItemVendor.ItemVendorLink.VendorLink.CompanyName ??
                         transactionItemVendor.ItemVendorLink.VendorLink.GetFullName();
            TransactionId = TransactionId;
            ItemVendorId = transactionItemVendor.ItemVendorId;
        }
    }
}