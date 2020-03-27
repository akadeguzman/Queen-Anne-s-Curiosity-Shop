using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.ViewModel.Address;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemListViewModel
    {
        private ItemService _itemService;
        private ItemViewModel _selectedItem;
        private string _searchText;
        private string _itemCount;

        public ItemListViewModel(ItemService itemService)
        {
            _itemService = itemService;

            var item = _itemService.GetItems()
                .Select(c =>
                    new ItemViewModel(c)).ToList();

            ItemList = new ObservableCollection<ItemViewModel>(item);
        }

        public void Sync()
        {
            ItemList.Clear();

            var items = _itemService.GetItems()
                .Select(c =>
                    new ItemViewModel(c)).ToList();

            foreach (var item in items)
            {
                ItemList.Add(item);
            }

        }

        public ObservableCollection<ItemViewModel> ItemList { get; }

        public string ItemCount
        {
            get => _itemCount;
            set
            {
                _itemCount = value;
                GetItemCount();
            }
        }
        public string GetItemCount()
        {
            var count = $"{ItemList.Count}";
            return count;
        }

        public ItemViewModel SelectedItem { get; set; }

        public void SearchItem(string searchString)
        {
            ItemList.Clear();

            var items = _itemService.GetItems().Where(c => c.ItemId.ToString().Contains(searchString) ||
                                                           c.ItemDescription.Contains(searchString) ||
                                                           c.ItemTypeLink.Type.Contains(searchString) ||
                                                           c.ItemAvailabilityLink.Status.Contains(searchString));

            foreach (var item in items)
            {
                var itemModel = new ItemViewModel(item.ItemId, item.ItemDescription, item.InventoryQuantity,
                    item.ItemAvailabilityLink.Status, item.ItemTypeLink.Type, item.ItemAvailabilityId, item.ItemTypeId);
                ItemList.Add(itemModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchItem(_searchText);
            }
        }
    }
}