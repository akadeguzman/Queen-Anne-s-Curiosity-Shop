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
using QAShopWPF.ViewModel;
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.Views.Vendor
{
    /// <summary>
    /// Interaction logic for AddVendorView.xaml
    /// </summary>
    public partial class AddVendorView : Window
    {
        public AddVendorView()
        {
            InitializeComponent();
            
            DataContext = QAShopService.AddVendorViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QAShopService.AddVendorViewModel.Add();
            QAShopService.VendorListViewModel.VendorList.Insert(0, QAShopService.AddVendorViewModel.VendorViewModel);
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
