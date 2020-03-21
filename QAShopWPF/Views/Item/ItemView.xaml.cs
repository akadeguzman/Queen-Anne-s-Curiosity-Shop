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
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : UserControl
    {
        private ItemService _itemService;
        private ItemListViewModel _itemListViewModel;
        private ItemAvailabilityService _itemAvailabilityService;
        private ItemTypeService _itemTypeService;

        public ItemView(ItemListViewModel itemListViewModel, ItemTypeService itemTypeService, ItemAvailabilityService itemAvailabilityService, ItemService itemService)
        {
            InitializeComponent();

            _itemService = itemService;
            _itemAvailabilityService = itemAvailabilityService;
            _itemTypeService = itemTypeService;
            _itemListViewModel = new ItemListViewModel(itemService);

            DataContext = _itemListViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addItem = new AddNewItemView(_itemListViewModel, _itemService, _itemAvailabilityService, _itemTypeService);
            addItem.Show();
        }
    }
}
