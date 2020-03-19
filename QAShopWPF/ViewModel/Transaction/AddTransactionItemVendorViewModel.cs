using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShop_System.EfClasses;
using QAShopWPF.Views.Transaction;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class AddTransactionItemVendorViewModel
    {
        private TransactionItemVendorService _transactionItemVendorService;
        private TransactionService _transactionService;
        private ItemVendorService _itemVendorService;

        public AddTransactionItemVendorViewModel(TransactionService transactionService, ItemVendorService itemVendorService)
        {
            var blankTransactionItemVendor = new QAShop_System.EfClasses.TransactionItemVendor();
            TransactionItemVendorViewModel = new TransactionItemVendorViewModel(blankTransactionItemVendor.TransactionItemVendorId,
                blankTransactionItemVendor.Quantity, blankTransactionItemVendor.Subtotal, blankTransactionItemVendor.Tax, blankTransactionItemVendor.Total,
                blankTransactionItemVendor.TransactionId, blankTransactionItemVendor.ItemVendorId);

            _transactionService = transactionService;
            _itemVendorService = itemVendorService;

            ItemVendors = new ObservableCollection<ItemVendor>(_itemVendorService.GetItemVendors());
            SelectedItemVendor = ItemVendors.First();

            Transactions = new ObservableCollection<QAShop_System.EfClasses.Transaction>(_transactionService.GetTransactions());
            SelectedTransaction = Transactions.First();



        }

        public TransactionItemVendorViewModel TransactionItemVendorViewModel { get; }

        public ObservableCollection<ItemVendor> ItemVendors { get; }
        public ObservableCollection<QAShop_System.EfClasses.Transaction> Transactions { get; }

        public ItemVendor SelectedItemVendor { get; set; }
        public QAShop_System.EfClasses.Transaction SelectedTransaction { get; set; }

        public int Quantity { get; set; }
        public int Subtotal { get; set; }
        public int Tax { get; set; }
        public int Total { get; set; }

        public ICommand AddItem => new RelayCommand(Add);
        
        public void Add()
        {
            var transactionItemVendorToAdd = new TransactionItemVendor();
            transactionItemVendorToAdd.Quantity = Quantity;
            transactionItemVendorToAdd.Subtotal = Subtotal;
            transactionItemVendorToAdd.Tax = Tax;
            transactionItemVendorToAdd.Total = Total;
            transactionItemVendorToAdd.ItemVendorId = SelectedItemVendor.ItemVendorId;
            transactionItemVendorToAdd.TransactionId = SelectedTransaction.TransactionId;
            

            _transactionItemVendorService.AddTransactionItemVendor(transactionItemVendorToAdd);

            TransactionItemVendorViewModel.TransactionItemVendorId = transactionItemVendorToAdd.TransactionItemVendorId;
            TransactionItemVendorViewModel.Quantity = transactionItemVendorToAdd.Quantity;
            TransactionItemVendorViewModel.Subtotal = transactionItemVendorToAdd.Subtotal;
            TransactionItemVendorViewModel.Tax = transactionItemVendorToAdd.Tax;
            TransactionItemVendorViewModel.Total = transactionItemVendorToAdd.Total;
            TransactionItemVendorViewModel.ItemVendorId = transactionItemVendorToAdd.ItemVendorId;
            TransactionItemVendorViewModel.TransactionId = transactionItemVendorToAdd.TransactionId;
        }
    }
}