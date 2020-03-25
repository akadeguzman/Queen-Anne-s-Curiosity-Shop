using System;
using System.Collections.ObjectModel;
using QAShop_System.EfClasses;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class AddItemVendorViewModel
    {
        private ItemVendorService _itemVendorService;
        private ItemService _itemService;
        private VendorService _vendorService;

        public AddItemVendorViewModel(ItemVendorService itemVendorService, ItemService itemService, VendorService vendorService)
        {
            var blankItemVendor = new QAShop_System.EfClasses.ItemVendor();
            ItemVendorViewModel = new ItemVendorViewModel(blankItemVendor.ItemVendorId, blankItemVendor.Price, blankItemVendor.PurchaseDate,
                blankItemVendor.City, blankItemVendor.LocalCurrency, blankItemVendor.ExchangeRate, blankItemVendor.ItemVendorId, blankItemVendor.ItemId, "", "" );

            _itemService = itemService;
            _vendorService = vendorService;

            Items = new ObservableCollection<QAShop_System.EfClasses.Item>(_itemService.GetItems());

            Vendors = new ObservableCollection<QAShop_System.EfClasses.Vendor>(_vendorService.GetVendors());
        }

        public ItemVendorViewModel ItemVendorViewModel { get; }

        public ObservableCollection<QAShop_System.EfClasses.Item> Items { get; }
        public ObservableCollection<QAShop_System.EfClasses.Vendor> Vendors { get; }

        public QAShop_System.EfClasses.Item SelectedItem { get; set; }
        public QAShop_System.EfClasses.Vendor SelectedVendor { get; set; }

        public int Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string City { get; set; }
        public int LocalCurrency { get; set; }
        public int ExchangeRate { get; set; }
        
        public void Add()
        {
            var itemVendorToAdd = new QAShop_System.EfClasses.ItemVendor();
            itemVendorToAdd.Price = Price;
            itemVendorToAdd.PurchaseDate = PurchaseDate;
            itemVendorToAdd.City = City;
            itemVendorToAdd.LocalCurrency = LocalCurrency;
            itemVendorToAdd.ExchangeRate = ExchangeRate;
            itemVendorToAdd.VendorId = SelectedVendor.VendorId;
            itemVendorToAdd.ItemId = SelectedItem.ItemId;
            
            _itemVendorService.AddItem(itemVendorToAdd);

            ItemVendorViewModel.ItemVendorId = itemVendorToAdd.ItemVendorId;
            ItemVendorViewModel.Price = itemVendorToAdd.Price;
            ItemVendorViewModel.PurchaseDate = itemVendorToAdd.PurchaseDate;
            ItemVendorViewModel.City = itemVendorToAdd.City;
            ItemVendorViewModel.LocalCurrency = itemVendorToAdd.LocalCurrency;
            ItemVendorViewModel.ExchangeRate = itemVendorToAdd.ExchangeRate;
            ItemVendorViewModel.Vendor =
                itemVendorToAdd.VendorLink.CompanyName ?? itemVendorToAdd.VendorLink.GetFullName();
            ItemVendorViewModel.VendorId = itemVendorToAdd.VendorId;
            ItemVendorViewModel.Item = itemVendorToAdd.ItemLink.ItemDescription;
            ItemVendorViewModel.ItemId = itemVendorToAdd.ItemId;

        }
    }
}