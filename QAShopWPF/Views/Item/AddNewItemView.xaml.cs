using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Transaction;
using ServiceLayer;

namespace QAShopWPF.Views.Item
{
    /// <summary>
    /// Interaction logic for AddNewItemView.xaml
    /// </summary>
    public partial class AddNewItemView : Window
    {
        private AddItemViewModel _ItemToAdd;
        private ItemListViewModel _itemListViewModel;
        private AddItemVendorViewModel _addItemVendorViewModel;
        private ItemService _itemService;

        public AddNewItemView(ItemListViewModel itemListViewModel, ItemService itemService, ItemAvailabilityService itemAvailabilityService, ItemTypeService itemTypeService)
        {
            InitializeComponent();
            _itemListViewModel = itemListViewModel;
            _ItemToAdd = new AddItemViewModel(itemService, itemAvailabilityService, itemTypeService);

            DataContext = _ItemToAdd;
        }

        public AddNewItemView(ItemService itemService, ItemAvailabilityService itemAvailabilityService, ItemTypeService itemTypeService, AddItemVendorViewModel addItemVendorViewModel)
        {
            InitializeComponent();
            _addItemVendorViewModel = addItemVendorViewModel;
            _ItemToAdd = new AddItemViewModel(itemService, itemAvailabilityService, itemTypeService);

            DataContext = _ItemToAdd;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            _ItemToAdd.Add();

            if (_itemListViewModel != null)
            {
                _itemListViewModel.ItemList.Insert(0, _ItemToAdd.ItemViewModel);
            }
            else
            {
                var itemVendor = _itemService.GetItems().Select(c => new ItemViewModel(c)).Last();
                _addItemVendorViewModel.Items.Add(itemVendor);
            }
            
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
