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

        public VendorView()
        {
            InitializeComponent();
            DataContext = QAShopService.VendorListViewModel;
        }

        private void BtnAddVendor_Click(object sender, RoutedEventArgs e)
        {
            var addVendorWindow = new AddVendorView();
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
                if (QAShopService.VendorListViewModel.SelectedVendor == null) return;
                else QAShopService.VendorService.DeleteVendor(QAShopService.VendorListViewModel.SelectedVendor.VendorId);

                QAShopService.VendorListViewModel.VendorList.Remove(QAShopService.VendorListViewModel.SelectedVendor);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
