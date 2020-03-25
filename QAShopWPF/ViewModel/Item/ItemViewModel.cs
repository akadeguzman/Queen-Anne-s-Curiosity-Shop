using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using QAShopWPF.Annotations;
using GalaSoft.MvvmLight;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemViewModel : ObservableObject
    {
        #region Properties

        private int _itemId;
        private string _itemDescription;
        private int _inventoryQuantity;
        private string _itemAvailability;
        private string _itemType;

        public int ItemId
        {
            get => _itemId;
            internal set
            {
                _itemId = value;
                RaisePropertyChanged(nameof(ItemId));
            }
        }

        public string ItemDescription
        {
            get => _itemDescription;
            internal set
            {
                _itemDescription = value;
                RaisePropertyChanged(nameof(ItemDescription));
            }
        }

        
        public int InventoryQuantity
        {
            get => _inventoryQuantity;
            internal set
            {
                _inventoryQuantity = value;
                RaisePropertyChanged(nameof(InventoryQuantity));
            }
        }

        
        public string ItemAvailability
        {
            get => _itemAvailability;
            internal set
            {
                _itemAvailability = value;
                RaisePropertyChanged(nameof(ItemAvailability));
            }
        }

        public string ItemType
        {
            get => _itemType;
            internal set
            {
                _itemType = value;
                RaisePropertyChanged(nameof(ItemType));
            }
        }

        public int ItemAvailabilityId { get; set; }
        public int ItemTypeId { get; set; }

        public ItemViewModel(
            int itemId,
            string itemDescription,
            int inventoryQuantity,
            string itemAvailability,
            string itemType,
            int itemAvailabilityId,
            int itemTypeId)
        {
            ItemId = itemId;
            ItemDescription = itemDescription;
            InventoryQuantity = inventoryQuantity;
            
            ItemAvailabilityId = itemAvailabilityId;
            ItemAvailability = itemAvailability;
            ItemTypeId = itemTypeId;
            ItemType = itemType;
        }

        public ItemViewModel(QAShop_System.EfClasses.Item item)
        {
            ItemId = item.ItemId;
            ItemDescription = item.ItemDescription;
            InventoryQuantity = item.InventoryQuantity;
           
            ItemAvailabilityId = item.ItemAvailabilityId;
            ItemAvailability = item.ItemAvailabilityLink.Status;
            ItemTypeId = item.ItemTypeId;
            ItemType = item.ItemTypeLink.Type;
        }
        
        #endregion

    }
}