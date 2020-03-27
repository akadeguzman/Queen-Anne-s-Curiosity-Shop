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
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Transaction;
using ServiceLayer;

namespace QAShopWPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for AddNewTransactionView.xaml
    /// </summary>
    public partial class AddNewTransactionView : Window
    {
        private EditTransactionViewModel _transactionToEdit;
        private TransactionService _transactionService;
        private TransactionListViewModel _transactionListViewModel;
        private TransactionViewModel _inputTransaction;

        public AddNewTransactionView(TransactionViewModel transactionViewModel, TransactionService transactionService, 
            PersonService personService, TransactionTypeService transactionTypeService, TransactionListViewModel transactionListViewModel)
        {
            InitializeComponent();
            _inputTransaction = transactionViewModel;
            _transactionListViewModel = transactionListViewModel;
            _transactionService = transactionService;
            _transactionToEdit = new EditTransactionViewModel(transactionViewModel, transactionService, personService, transactionTypeService);
            DataContext = _transactionToEdit;
        }

        private void BtnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            _transactionToEdit.Edit();
            _transactionListViewModel.Sync();
            Close();
        }
        
        private void BtnCancelTransaction_Click(object sender, RoutedEventArgs e)
        {
            _transactionService.DeleteTransaction(_inputTransaction.TransactionId);
            Close();
        }

        private void BtnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            _transactionToEdit.Items.Remove(_transactionToEdit.SelectedTransactionItem);

        }
        
        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var addItem = new AddTransactionItemView(_transactionToEdit, new ItemVendorService(new QueenAnneCuriosityShopContext()));
            addItem.Show();
        }
    }
}
