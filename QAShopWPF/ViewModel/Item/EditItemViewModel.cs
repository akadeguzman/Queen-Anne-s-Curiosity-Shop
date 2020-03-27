using System.Collections.ObjectModel;
using System.Linq;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class EditItemViewModel
    {
        private ItemService _itemService;
        private ItemTypeService _itemTypeService;
        private ItemAvailabilityService _itemAvailabilityService;
        private ItemViewModel _itemViewModel;

        public EditItemViewModel(ItemViewModel itemViewModel, ItemService itemService, ItemTypeService itemTypeService, ItemAvailabilityService itemAvailabilityService)
        {
            AssociativeItemViewModel = itemViewModel;
            _itemService = itemService;
            _itemTypeService = itemTypeService;
            _itemAvailabilityService = itemAvailabilityService;

            ItemTypes = new ObservableCollection<ItemType>(itemTypeService.GetItemTypes());
            SelectedItemType = ItemTypes.First(c => c.ItemTypeId == AssociativeItemViewModel.ItemTypeId);

            ItemAvailabilities = new ObservableCollection<ItemAvailability>(itemAvailabilityService.GetItemAvailabilities());
            SelectedItemAvailability = ItemAvailabilities.First(c => c.ItemAvailabilityId == AssociativeItemViewModel.ItemAvailabilityId);

            CopyEditTableFields(itemViewModel);
        }

        private void CopyEditTableFields(ItemViewModel itemViewModel)
        {
            Description = itemViewModel.ItemDescription;
            Quantity = itemViewModel.InventoryQuantity;
        }

        public ObservableCollection<ItemType> ItemTypes { get; set; }
        public ItemType SelectedItemType { get; set; }

        public ObservableCollection<ItemAvailability> ItemAvailabilities { get; set; }
        public ItemAvailability SelectedItemAvailability { get; set; }
        
        public string Description { get; set; }
        public int Quantity { get; set; }

        public ItemViewModel AssociativeItemViewModel { get; set; }

        public void Edit()
        {
            _itemService.UpdateItem(AssociativeItemViewModel.ItemId, Description, Quantity, SelectedItemAvailability.ItemAvailabilityId, SelectedItemType.ItemTypeId);
        }
    }
}