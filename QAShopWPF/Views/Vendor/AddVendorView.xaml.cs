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
        private AddVendorViewModel _vendorToAdd;
        private VendorService _vendorService;
        private VendorListViewModel _vendorListViewModel;

        public AddVendorView(VendorService vendorService, VendorListViewModel vendorListViewModel)
        {
            _vendorListViewModel = vendorListViewModel;
            InitializeComponent();

            _vendorService = vendorService;
            _vendorToAdd = new AddVendorViewModel(vendorService);
            
            DataContext = _vendorToAdd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vendorToAdd.Add();
            _vendorListViewModel.VendorList.Insert(0, _vendorToAdd.VendorViewModel);
            Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
