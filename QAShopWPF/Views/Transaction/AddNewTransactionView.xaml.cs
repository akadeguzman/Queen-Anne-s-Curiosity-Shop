using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QAShopWPF.ViewModel.Transaction;
using ServiceLayer;

namespace QAShopWPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for AddNewTransactionView.xaml
    /// </summary>
    public partial class AddNewTransactionView : Window
    {
        private AddTransactionViewModel _transactionToAdd;
        private TransactionService _transactionService;
        private TransactionTypeService _transactionTypeService;
        private PersonService _personService;
        private ItemVendorService _itemVendorService;
        private TransactionItemService _transactionItemVendorService;

        public AddNewTransactionView(TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService, ItemVendorService itemVendorService, TransactionItemService transactionItemVendorService)
        {
            InitializeComponent();

            _itemVendorService = itemVendorService;
            _transactionService = transactionService;
            _transactionTypeService = transactionTypeService;
            _personService = personService;
            _transactionItemVendorService = transactionItemVendorService;

            _transactionToAdd = new AddTransactionViewModel(transactionService, transactionTypeService, personService);
            DataContext = _transactionToAdd;

        }

        private void BtnAddItemsToTransaction_Click(object sender, RoutedEventArgs e)
        {
            var addItemsToTransaction = new AddItemVendorToTransactionView( _transactionToAdd, _itemVendorService, _transactionItemVendorService);
            addItemsToTransaction.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TxtCustomer.Text = _transactionToAdd.SelectedPerson.GetFullName();
        }
    }
}
