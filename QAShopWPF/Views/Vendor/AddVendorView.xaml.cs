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
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.Views.Vendor
{
    /// <summary>
    /// Interaction logic for AddVendorView.xaml
    /// </summary>
    public partial class AddVendorView : Window
    {
        private VendorListViewModel _vendorListViewModel;
        private VendorService _vendorService;

        private AddVendorViewModel _vendorToAdd;

        public AddVendorView(VendorListViewModel vendorListViewModel, VendorService vendorService)
        {
            InitializeComponent();

            _vendorToAdd = new AddVendorViewModel(vendorService);
            _vendorListViewModel = vendorListViewModel;

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
