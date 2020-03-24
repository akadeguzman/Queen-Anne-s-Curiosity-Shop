using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShop_System.EfClasses;
using QAShopWPF.Views.Transaction;
using ServiceLayer;
using GalaSoft.MvvmLight;
using QAShopWPF.ViewModel.Item;

namespace QAShopWPF.ViewModel.Transaction
{
    public class AddTransactionItemVendorViewModel : ObservableObject
    {
        private TransactionItemVendorService _transactionItemVendorService;
        private ItemVendorService _itemVendorService;
        private AddTransactionViewModel _addTransactionViewModel;

        public AddTransactionItemVendorViewModel(AddTransactionViewModel addTransactionViewModel, ItemVendorService itemVendorService, TransactionItemVendorService transactionItemVendorService)
        {
            _itemVendorService = itemVendorService;
            _transactionItemVendorService = transactionItemVendorService;
            _addTransactionViewModel = addTransactionViewModel;

            var blankTransactionItemVendor = new QAShop_System.EfClasses.TransactionItemVendor();
            TransactionItemVendorViewModel = new TransactionItemVendorViewModel(blankTransactionItemVendor.TransactionItemVendorId,
                blankTransactionItemVendor.Quantity, blankTransactionItemVendor.Subtotal, blankTransactionItemVendor.Tax, blankTransactionItemVendor.Total,
                blankTransactionItemVendor.TransactionInvoiceNumber, blankTransactionItemVendor.ItemVendorId);
            
            _itemVendorService = itemVendorService;

            ItemVendors = new ObservableCollection<ItemVendorViewModel>(itemVendorService.GetItemVendors().Select(c =>
                new ItemVendorViewModel(c)));
        }

        public TransactionItemVendorViewModel TransactionItemVendorViewModel { get; }

        public ObservableCollection<ItemVendorViewModel> ItemVendors { get; }

        public ItemVendorViewModel SelectedItemVendor { get; set; }

        public int Quantity { get; set; }

        private int _subtotal;
        public int Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                RaisePropertyChanged(nameof(Subtotal));
            }

        }

        private int _tax;
        public int Tax
        {
            get => _tax;
            set
            {
                _tax = value;
                RaisePropertyChanged(nameof(Tax));
            }

        }

        private int _total;
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                RaisePropertyChanged(nameof(Total));
            }

        }


        public void Add()
        {
            var transactionItemVendorToAdd = new TransactionItemVendor();
            transactionItemVendorToAdd.Quantity = Quantity;
            transactionItemVendorToAdd.Subtotal = Subtotal;
            transactionItemVendorToAdd.Tax = Tax;
            transactionItemVendorToAdd.Total = Total;
            transactionItemVendorToAdd.ItemVendorId = SelectedItemVendor.ItemVendorId;
            transactionItemVendorToAdd.TransactionInvoiceNumber = _addTransactionViewModel.InvoiceNumber;
            
            _transactionItemVendorService.AddTransactionItemVendor(transactionItemVendorToAdd);

            TransactionItemVendorViewModel.TransactionItemVendorId = transactionItemVendorToAdd.TransactionItemVendorId;
            TransactionItemVendorViewModel.Quantity = transactionItemVendorToAdd.Quantity;
            TransactionItemVendorViewModel.Subtotal = transactionItemVendorToAdd.Subtotal;
            TransactionItemVendorViewModel.Tax = transactionItemVendorToAdd.Tax;
            TransactionItemVendorViewModel.Total = transactionItemVendorToAdd.Total;
            TransactionItemVendorViewModel.TransactionInvoiceNumber =
                transactionItemVendorToAdd.TransactionInvoiceNumber;
            TransactionItemVendorViewModel.ItemVendorId = transactionItemVendorToAdd.ItemVendorId;

            TransactionItemVendorViewModel.ItemName =
                transactionItemVendorToAdd.ItemVendorLink.ItemLink.ItemDescription;

            TransactionItemVendorViewModel.VendorName =
                transactionItemVendorToAdd.ItemVendorLink.VendorLink.CompanyName ??
                transactionItemVendorToAdd.ItemVendorLink.VendorLink.GetFullName();

            _addTransactionViewModel.TransactionItemVendors.Add(TransactionItemVendorViewModel);
        }
    }
}