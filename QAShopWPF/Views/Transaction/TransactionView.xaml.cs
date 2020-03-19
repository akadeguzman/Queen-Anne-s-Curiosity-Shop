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
using QAShopWPF.ViewModel.Transaction;
using ServiceLayer;

namespace QAShopWPF.Views.Transaction
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        private TransactionListViewModel _transactionListViewModel;
        private TransactionService _transactionService;
        private PersonService _personService;
        private TransactionTypeService _transactionTypeService;

        public TransactionView(TransactionListViewModel transactionListViewModel,
            TransactionService transactionService, PersonService personService,
            TransactionTypeService transactionTypeService)
        {
            InitializeComponent();

            _transactionService = transactionService;
            _personService = personService;
            _transactionTypeService = transactionTypeService;
            _transactionListViewModel = new TransactionListViewModel(transactionService);

            DataContext = _transactionListViewModel;
        }
    }
}
