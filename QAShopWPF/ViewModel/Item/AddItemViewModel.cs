using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.Views.Item;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class AddItemViewModel
    {
        private ItemService _itemService;
        private ItemAvailabilityService _itemAvailabilityService;
        private ItemTypeService _itemTypeService;

        public AddItemViewModel(ItemService itemService, ItemAvailabilityService itemAvailabilityService, ItemTypeService itemTypeService)
        {
            var blankItem = new QAShop_System.EfClasses.Item();
            ItemViewModel = new ItemViewModel(blankItem.ItemId, blankItem.ItemDescription, blankItem.InventoryQuantity, "", "", blankItem.ItemAvailabilityId, blankItem.ItemTypeId);

            _itemService = itemService;
            _itemTypeService = itemTypeService;
            _itemAvailabilityService = itemAvailabilityService;

            ItemTypes = new ObservableCollection<ItemType>(_itemTypeService.GetItemTypes());

            ItemAvailabilities = new ObservableCollection<ItemAvailability>(_itemAvailabilityService.GetItemAvailabilities());
        }

        public ItemViewModel ItemViewModel { get; }

        public ObservableCollection<ItemType> ItemTypes { get; }
        public ObservableCollection<ItemAvailability> ItemAvailabilities { get; }

        public ItemType SelectedItemType { get; set; }
        public ItemAvailability SelectedItemAvailability { get; set; }

        public string Description { get; set; }
        public int InventoryQuantity { get; set; }
        
        public void Add()
        {
            var itemToAdd = new QAShop_System.EfClasses.Item();
            itemToAdd.ItemDescription = Description;
            itemToAdd.InventoryQuantity = InventoryQuantity;
            itemToAdd.ItemTypeId = SelectedItemType.ItemTypeId;
            itemToAdd.ItemAvailabilityId = SelectedItemAvailability.ItemAvailabilityId;

            _itemService.AddItem(itemToAdd);

            ItemViewModel.ItemId = itemToAdd.ItemId;
            ItemViewModel.ItemDescription = itemToAdd.ItemDescription;
            ItemViewModel.InventoryQuantity = itemToAdd.InventoryQuantity;

            ItemViewModel.ItemTypeId = itemToAdd.ItemTypeId;
            ItemViewModel.ItemType = itemToAdd.ItemTypeLink.Type;

            ItemViewModel.ItemAvailabilityId = itemToAdd.ItemAvailabilityId;
            ItemViewModel.ItemAvailability = itemToAdd.ItemAvailabilityLink.Status;

        }

    }
}
