using System;
using System.Collections.ObjectModel;
using System.Linq;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Item;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class AddTransactionItemViewModel
    {
        private EditTransactionViewModel _transactionToAdd;
        private TransactionItemService _transactionItemService;

        public AddTransactionItemViewModel(EditTransactionViewModel transaction, ItemVendorService itemVendorService, TransactionItemService transactionItemService)
        {
            _transactionItemService = transactionItemService;
            _transactionToAdd = transaction;
            var blankTransactionItem = new TransactionItem();
            TransactionItemViewModel = new TransactionItemViewModel(blankTransactionItem.ItemVendorId, blankTransactionItem.Quantity,
                blankTransactionItem.TransactionId, blankTransactionItem.ItemVendorId);
            
            ItemVendors = new ObservableCollection<ItemVendorViewModel>(itemVendorService.GetItemVendors()
                .Select(c=>new ItemVendorViewModel(c)));
            
        }

        public TransactionItemViewModel TransactionItemViewModel { get; }

        public ObservableCollection<ItemVendorViewModel> ItemVendors { get; }
        public ItemVendorViewModel SelectedItemVendor { get; set; }
        
        public int Quantity { get; set; }

        public void Add()
        {
            var transactionItemToAdd = new QAShop_System.EfClasses.TransactionItem();
            transactionItemToAdd.TransactionId = _transactionToAdd.AssociatedTransactionViewModel.TransactionId;
            transactionItemToAdd.ItemVendorId = SelectedItemVendor.ItemVendorId;
            transactionItemToAdd.Quantity = Quantity;

            _transactionItemService.AddTransactionItem(transactionItemToAdd);

            TransactionItemViewModel.ItemVendorId = SelectedItemVendor.ItemVendorId;
            TransactionItemViewModel.TransactionId = _transactionToAdd.AssociatedTransactionViewModel.TransactionId;
            TransactionItemViewModel.ItemId = SelectedItemVendor.ItemId;
            TransactionItemViewModel.ItemName = SelectedItemVendor.Item;
            TransactionItemViewModel.Quantity = Quantity;
            TransactionItemViewModel.Price = SelectedItemVendor.Price;
            TransactionItemViewModel.VendorName = SelectedItemVendor.Vendor;

            _transactionToAdd.Items.Add(TransactionItemViewModel);


        }
    }
}