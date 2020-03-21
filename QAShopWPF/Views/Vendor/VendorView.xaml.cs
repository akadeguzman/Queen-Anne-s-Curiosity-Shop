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
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.Views.Vendor
{
    /// <summary>
    /// Interaction logic for VendorView.xaml
    /// </summary>
    public partial class VendorView : UserControl
    {
        private readonly VendorListViewModel _vendorListViewModel;
        private readonly VendorService _vendorService;

        public VendorView(VendorListViewModel vendorListViewModel, VendorService vendorService)
        {

            InitializeComponent();
            _vendorService = vendorService;
            _vendorListViewModel = new VendorListViewModel(vendorService);
            


            DataContext = _vendorListViewModel;
        }

        private void BtnAddVendor_Click(object sender, RoutedEventArgs e)
        {
            var addVendorWindow = new AddVendorView(_vendorService, _vendorListViewModel);
            addVendorWindow.Show();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem != null)
            {
                BtnDeleteVendor.Visibility = Visibility.Visible;
            }
            else
            {
                BtnDeleteVendor.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnDeleteVendor_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_vendorListViewModel.SelectedVendor == null) return;
                else _vendorService.DeleteVendor(_vendorListViewModel.SelectedVendor.VendorId);

                _vendorListViewModel.VendorList.Remove(_vendorListViewModel.SelectedVendor);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
