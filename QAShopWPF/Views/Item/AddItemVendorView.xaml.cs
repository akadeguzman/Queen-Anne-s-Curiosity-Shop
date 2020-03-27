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
using QAShopWPF.ViewModel.Item;
using QAShopWPF.Views.Vendor;
using ServiceLayer;

namespace QAShopWPF.Views.Item
{
    /// <summary>
    /// Interaction logic for AddItemVendorView.xaml
    /// </summary>
    public partial class AddItemVendorView : Window
    {
        private AddItemVendorViewModel _itemToAdd;
        private ItemVendorListViewModel _itemVendorListViewModel;
        private ItemService _itemService;
        private VendorService _vendorService;

        public AddItemVendorView(ItemVendorListViewModel itemVendorListViewModel, ItemVendorService itemVendorService, ItemService itemService, VendorService vendorService)
        {
            InitializeComponent();
            _itemService = itemService;
            _vendorService = vendorService;
            _itemVendorListViewModel = itemVendorListViewModel;
            
            _itemToAdd = new AddItemVendorViewModel(itemVendorService, itemService, vendorService);
            DataContext = _itemToAdd;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _itemToAdd.Add();
            _itemVendorListViewModel.ItemVendorList.Insert(0, _itemToAdd.ItemVendorViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            var addItem = new AddNewItemView(_itemService, new ItemAvailabilityService(new QueenAnneCuriosityShopContext()), new ItemTypeService(new QueenAnneCuriosityShopContext()), _itemToAdd );
            addItem.Show();
        }

        private void AddVendor_Click(object sender, RoutedEventArgs e)
        {
            var addVendor = new AddVendorView(_vendorService, _itemToAdd);
            addVendor.Show();
        }
    }
}
