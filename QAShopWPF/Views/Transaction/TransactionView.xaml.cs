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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QAShopWPF.ViewModel;
using QAShopWPF.ViewModel.Transaction;
using ServiceLayer;

namespace QAShopWPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        private TransactionService _transactionService;
        private TransactionTypeService _transactionTypeService;
        private PersonService _personService;
        private ItemVendorService _itemVendorService;
        private TransactionListViewModel _transactionListViewModel;
        private TransactionItemVendorService _transactionItemVendorService;

        public TransactionView(TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService, ItemVendorService itemVendorService, TransactionItemVendorService transactionItemVendorService)
        {
            _transactionService = transactionService;
            _transactionTypeService = transactionTypeService;
            _personService = personService;
            _transactionItemVendorService = transactionItemVendorService;
            _itemVendorService = itemVendorService;
            _transactionListViewModel = new TransactionListViewModel(transactionService);

            InitializeComponent();

            DataContext = _transactionListViewModel;
        }

        private void BtnAddTransaction_Click(object sender, RoutedEventArgs e)
        {
            var addTransaction = new AddNewTransactionView(_transactionService, _transactionTypeService, _personService, _itemVendorService, _transactionItemVendorService);
            addTransaction.Show();
        }
    }
}
