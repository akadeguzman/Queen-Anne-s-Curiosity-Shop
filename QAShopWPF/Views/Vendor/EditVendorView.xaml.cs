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
    /// Interaction logic for EditVendorView.xaml
    /// </summary>
    public partial class EditVendorView : Window
    {
        public EditVendorView()
        {
            InitializeComponent();
        }

        private EditVendorViewModel _toEditVendor;
        private VendorListViewModel _vendorListViewModel;

        public EditVendorView(VendorListViewModel vendorListViewModel, VendorViewModel vendorViewModel, VendorService vendorService) : this()
        {
            _toEditVendor = new EditVendorViewModel(vendorViewModel, vendorService);
            _vendorListViewModel = vendorListViewModel;
            DataContext = _toEditVendor;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            _toEditVendor.Edit();
            _vendorListViewModel.Sync();
            this.Close();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
