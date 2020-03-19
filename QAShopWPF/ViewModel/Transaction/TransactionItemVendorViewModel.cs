using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionItemVendorViewModel : ObservableObject
    {
        private int _transactionItemVendorId;
        private int _quantity;
        private int _subtotal;
        private int _tax;
        private int _total;

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

        public int TransactionId { get; set; }
        public int ItemVendorId { get; set; }

        public TransactionItemVendorViewModel(int transactionItemVendorId, 
            int quantity,int subtotal, 
            int tax, int total, int transactionId, int itemVendorId)
        {
            TransactionItemVendorId = transactionItemVendorId;
            Quantity = quantity;
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            TransactionId = transactionId;
            ItemVendorId = itemVendorId;
        }

        public TransactionItemVendorViewModel(TransactionItemVendor transactionItemVendor)
        {
            TransactionItemVendorId = transactionItemVendor.TransactionItemVendorId;
            Quantity = transactionItemVendor.Quantity;
            Subtotal = transactionItemVendor.Subtotal;
            Tax = transactionItemVendor.Tax;
            Total = transactionItemVendor.Total;
            TransactionId = transactionItemVendor.TransactionId;
            ItemVendorId = transactionItemVendor.ItemVendorId;
        }

        public TransactionItemVendorViewModel()
        {

        }
    }
}