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
    /// Interaction logic for AddTransactionItemView.xaml
    /// </summary>
    public partial class AddTransactionItemView : Window
    {
        private AddTransactionItemViewModel _itemToAdd;


        public AddTransactionItemView(EditTransactionViewModel editTransactionViewModel, ItemVendorService itemVendorService)
        {
            InitializeComponent();
            _itemToAdd = new AddTransactionItemViewModel(editTransactionViewModel, itemVendorService, new TransactionItemService(new QueenAnneCuriosityShopContext()));
            DataContext = _itemToAdd;
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            _itemToAdd.Add();
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
