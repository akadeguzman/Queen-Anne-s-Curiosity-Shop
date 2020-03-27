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
    /// Interaction logic for AddTransactionInputView.xaml
    /// </summary>
    public partial class AddTransactionInputView : Window
    {
        private AddTransactionViewModel _inputTransactionToBeAdded;
        private TransactionListViewModel _transactionListViewModel;
        private TransactionService _transactionService;
        private PersonService _personService;
        private TransactionTypeService _transactionTypeService;

        public AddTransactionInputView(TransactionListViewModel transactionListViewModel,TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService)
        {
            InitializeComponent();
            _transactionService = transactionService;
            _transactionTypeService = transactionTypeService;
            _personService = personService;
            _transactionListViewModel = transactionListViewModel;
            
            _inputTransactionToBeAdded = new AddTransactionViewModel(transactionService, transactionTypeService, personService);
            DataContext = _inputTransactionToBeAdded;
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            _inputTransactionToBeAdded.Add();

            var toMainTransactionView = new AddNewTransactionView(_inputTransactionToBeAdded.TransactionViewModel, _transactionService, _personService, _transactionTypeService, _transactionListViewModel);
            toMainTransactionView.Show();
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
