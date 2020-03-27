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
using ServiceLayer;

namespace QAShopWPF.Views.Item
{
    /// <summary>
    /// Interaction logic for EditItemView.xaml
    /// </summary>
    public partial class EditItemView : Window
    {
        private EditItemViewModel _itemToEdit;
        private ItemListViewModel _itemListViewModel;

        public EditItemView(ItemListViewModel itemListViewModel, ItemViewModel itemViewModel, ItemService itemService, ItemTypeService itemTypeService, ItemAvailabilityService itemAvailabilityService)
        {
            InitializeComponent();
            _itemListViewModel = itemListViewModel;
            _itemToEdit = new EditItemViewModel(itemViewModel, itemService, itemTypeService, itemAvailabilityService);
            DataContext = _itemToEdit;

        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            _itemToEdit.Edit();
            _itemListViewModel.Sync();
            Close();

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
