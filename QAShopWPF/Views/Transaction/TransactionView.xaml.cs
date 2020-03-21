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
        private TransactionListViewModel _transactionListViewModel;

        public TransactionView(TransactionService transactionService)
        {
            _transactionService = transactionService;
            _transactionListViewModel = new TransactionListViewModel(transactionService);

            InitializeComponent();

            DataContext = _transactionListViewModel;
        }
    }
}
