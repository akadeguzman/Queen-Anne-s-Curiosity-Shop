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
        private DateTime _purchaseDate;
        private int _itemCost;
        private int _inventoryQuantity;
        private string _city;
        private int _localCurrency;
        private int _exchangeRate;
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

        public DateTime PurchaseDate
        {
            get => _purchaseDate;
            internal set
            {
                _purchaseDate = value;
                RaisePropertyChanged(nameof(PurchaseDate));
            }
        }

        public int ItemCost
        {
            get => _itemCost;
            internal set
            {
                _itemCost = value;
                RaisePropertyChanged(nameof(ItemCost));
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

        public string City
        {
            get => _city;
            internal set
            {
                _city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public int LocalCurrency
        {
            get => _localCurrency;
            internal set
            {
                _localCurrency = value;
                RaisePropertyChanged(nameof(LocalCurrency));
            }
        }

        public int ExchangeRate
        {
            get => _exchangeRate;
            internal set
            {
                _exchangeRate = value;
                RaisePropertyChanged(nameof(ExchangeRate));
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
            DateTime purchaseDate,
            int itemCost,
            int inventoryQuantity,
            string city,
            int localCurrency,
            int exchangeRate,
            string itemAvailability,
            string itemType,
            int itemAvailabilityId,
            int itemTypeId)
        {
            ItemId = itemId;
            ItemDescription = itemDescription;
            PurchaseDate = purchaseDate;
            ItemCost = itemCost;
            InventoryQuantity = inventoryQuantity;
            City = city;
            LocalCurrency = localCurrency;
            ExchangeRate = exchangeRate;
            ItemAvailabilityId = itemAvailabilityId;
            ItemAvailability = itemAvailability;
            ItemTypeId = itemTypeId;
            ItemType = itemType;
        }

        public ItemViewModel(QAShop_System.EfClasses.Item item)
        {
            ItemId = item.ItemId;
            ItemDescription = item.ItemDescription;
            PurchaseDate = item.PurchaseDate;
            ItemCost = item.ItemCost;
            InventoryQuantity = item.InventoryQuantity;
            City = item.City;
            LocalCurrency = item.LocalCurrency;
            ExchangeRate = item.ExchangeRate;
            ItemAvailabilityId = item.ItemAvailabilityId;
            ItemAvailability = item.ItemAvailabilityLink.Status;
            ItemTypeId = item.ItemTypeId;
            ItemType = item.ItemTypeLink.Type;
        }
        
        #endregion

    }
}