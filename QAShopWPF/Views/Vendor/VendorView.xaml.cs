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
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.Views.Vendor
{
    /// <summary>
    /// Interaction logic for VendorView.xaml
    /// </summary>
    public partial class VendorView : UserControl
    {
        private VendorListViewModel _vendorListViewModel;
        private VendorService _vendorService;

        public VendorView( VendorListViewModel vendorListViewModel, VendorService vendorService)
        {
            InitializeComponent();

            _vendorService = vendorService;
            _vendorListViewModel = new VendorListViewModel(vendorService);

            DataContext = _vendorListViewModel;
        }
    }
}
