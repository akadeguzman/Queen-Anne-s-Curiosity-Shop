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
    /// Interaction logic for AddItemVendorToTransactionView.xaml
    /// </summary>
    public partial class AddItemVendorToTransactionView : Window
    {
        private AddTransactionViewModel _addTransactionViewModel;
        private AddTransactionItemVendorViewModel _addTransactionItemVendorViewModel;
        private ItemVendorService _itemVendorService;

        public AddItemVendorToTransactionView(AddTransactionViewModel addTransactionViewModel, ItemVendorService itemVendorService, TransactionItemVendorService transactionItemVendorService)
        {
            InitializeComponent();
            _itemVendorService = itemVendorService;
            _addTransactionViewModel = addTransactionViewModel;
            _addTransactionItemVendorViewModel = new AddTransactionItemVendorViewModel(addTransactionViewModel, itemVendorService, transactionItemVendorService);
            
            DataContext = _addTransactionItemVendorViewModel;
        }

        private void BtnAddItemsToTransaction_Click(object sender, RoutedEventArgs e)
        {
            _addTransactionItemVendorViewModel.Add();
            _addTransactionViewModel.TransactionItemVendors.Insert(0, _addTransactionItemVendorViewModel.TransactionItemVendorViewModel);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _addTransactionItemVendorViewModel.Subtotal = _addTransactionItemVendorViewModel.SelectedItemVendor.Price;
        }

        private void TxtTax_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = TxtTax.Text;
            if (text == " ")
            {
                _addTransactionItemVendorViewModel.Tax = 1;
            }
            _addTransactionItemVendorViewModel.Tax = int.Parse(text);

            var a = Convert.ToDecimal(text);
            var b = 100M;

            var toDouble = (a/b);
            var computed = (_addTransactionItemVendorViewModel.Subtotal * toDouble);

            _addTransactionItemVendorViewModel.Total = Convert.ToInt32(computed);

        }
    }
}
