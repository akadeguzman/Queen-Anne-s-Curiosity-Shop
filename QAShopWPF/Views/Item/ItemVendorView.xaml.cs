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
using QAShopWPF.ViewModel.Item;
using ServiceLayer;

namespace QAShopWPF.Views.Item
{
    /// <summary>
    /// Interaction logic for ItemVendorView.xaml
    /// </summary>
    public partial class ItemVendorView : UserControl
    {
        private ItemVendorListViewModel _itemVendorListViewModel;
        private ItemService _itemService;
        private VendorService _vendorService;
        private ItemVendorService _itemVendorService;

        public ItemVendorView(ItemVendorService itemVendorService, VendorService vendorService, ItemService itemService)
        {
            InitializeComponent();
            _itemService = itemService;
            _vendorService = vendorService;
            _itemVendorService = itemVendorService;
            _itemVendorListViewModel = new ItemVendorListViewModel(itemVendorService);
            DataContext = _itemVendorListViewModel;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var addNewItemVendor = new AddItemVendorView(_itemVendorListViewModel, _itemVendorService, _itemService, _vendorService);
            addNewItemVendor.Show();
        }
    }
}
