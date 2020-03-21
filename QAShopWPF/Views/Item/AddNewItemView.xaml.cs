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
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
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

        public AddNewItemView(ItemListViewModel itemListViewModel, ItemService itemService, ItemAvailabilityService itemAvailabilityService, ItemTypeService itemTypeService)
        {
            InitializeComponent();
            _itemListViewModel = itemListViewModel;
            _ItemToAdd = new AddItemViewModel(itemService, itemAvailabilityService, itemTypeService);

            DataContext = _ItemToAdd;
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            _ItemToAdd.Add();
            _itemListViewModel.ItemList.Insert(0, _ItemToAdd.ItemViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
