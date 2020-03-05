using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Address;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemListViewModel
    {
        private ItemService _itemService;
        private ItemViewModel _selectedItem;
        private string _searchText;

        public ItemListViewModel(ItemService itemService)
        {
            _itemService = itemService;

            var item = _itemService.GetItems()
                .Select(c =>
                    new ItemViewModel(
                        c.ItemId,
                        c.ItemDescription,
                        c.PurchaseDate,
                        c.ItemCost,
                        c.InventoryQuantity,
                        c.City,
                        c.LocalCurrency,
                        c.ExchangeRate,
                        c.ItemAvailabilityLink.Status,
                        c.ItemTypeLink.Type,
                        c.ItemAvailabilityId,
                        c.ItemTypeId)).ToList();

            ItemList = new ObservableCollection<ItemViewModel>(item);

        }


        public ObservableCollection<ItemViewModel> ItemList { get; }

        public ItemViewModel SelectedItem { get; set; }

        public void SearchMovie(string searchString)
        {
            ItemList.Clear();

            var items = _itemService.GetItems().Where(c => c.ItemId.ToString().Contains(searchString) ||
                                                                      c.ItemDescription.ToString().Contains(searchString) || c.ItemTypeLink.Type.ToString().Contains(searchString));

            foreach (var item in items)
            {
                var itemModel = new ItemViewModel(item.ItemId, item.ItemDescription, item.PurchaseDate,
                    item.ItemCost, item.InventoryQuantity, item.City, item.LocalCurrency, item.ExchangeRate,
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
                SearchMovie(_searchText);
            }
        }
    }
}