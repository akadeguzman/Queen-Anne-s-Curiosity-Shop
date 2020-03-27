using System;
using System.Runtime.Serialization.Formatters;
using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemVendorViewModel : ObservableObject
    {
        private int _itemVendorId;
        private int _price;
        private DateTime _purchaseDate;
        private string _city;
        private int _localCurrency;
        private int _exchangeRate;
        private string _item;
        private string _vendor;


        public int ItemVendorId
        {
            get => _itemVendorId;
            internal set
            {
                _itemVendorId = value;
                RaisePropertyChanged(nameof(ItemVendorId));
            }
        }
        
        public int Price
        {
            get => _price;
            internal set
            {
                _price = value;
                RaisePropertyChanged(nameof(Price));
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

        public string Item
        {
            get => _item;
            internal set
            {
                _item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }

        public string Vendor
        {
            get => _vendor;
            internal set
            {
                _vendor = value;
                RaisePropertyChanged(nameof(Vendor));
            }
        }

        public int VendorId { get; set; }
        public int ItemId { get; set; }

        public ItemVendorViewModel(int itemVendorId, int price, DateTime purchaseDate, string city, int localCurrency, int exchangeRate, int vendorId, int itemId, string vendor, string item)
        {
            ItemVendorId = itemVendorId;
            Price = price;
            PurchaseDate = purchaseDate;
            City = city;
            LocalCurrency = localCurrency;
            ExchangeRate = exchangeRate;
            Vendor = vendor;
            VendorId = vendorId;
            Item = item;
            ItemId = itemId;

        }

        public ItemVendorViewModel(ItemVendor itemVendor)
        {
            ItemVendorId = itemVendor.ItemVendorId;
            ItemId = itemVendor.ItemId;
            Price = itemVendor.Price;
            PurchaseDate = itemVendor.PurchaseDate;
            City = itemVendor.City;
            LocalCurrency = itemVendor.LocalCurrency;
            ExchangeRate = itemVendor.ExchangeRate;

            VendorId = itemVendor.ItemVendorId;

            Vendor = itemVendor.VendorLink.CompanyName ?? itemVendor.VendorLink.GetFullName();

            ItemId = itemVendor.ItemId;
            Item = itemVendor.ItemLink.ItemDescription;
        }
    }
}