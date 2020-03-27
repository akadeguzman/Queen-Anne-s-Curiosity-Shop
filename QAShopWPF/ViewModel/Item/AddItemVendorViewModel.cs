using System;
using System.Collections.ObjectModel;
using System.Linq;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class AddItemVendorViewModel
    {
        private ItemVendorService _itemVendorService;

        public AddItemVendorViewModel(ItemVendorService itemVendorService, ItemService itemService, VendorService vendorService)
        {
            var blankItemVendor = new QAShop_System.EfClasses.ItemVendor();
            ItemVendorViewModel = new ItemVendorViewModel(blankItemVendor.ItemVendorId, blankItemVendor.Price, blankItemVendor.PurchaseDate,
                blankItemVendor.City, blankItemVendor.LocalCurrency, blankItemVendor.ExchangeRate, blankItemVendor.ItemVendorId, blankItemVendor.ItemId, "", "" );

            _itemVendorService = itemVendorService;

            Items = new ObservableCollection<ItemViewModel>(itemService.GetItems().Select(c=>new ItemViewModel(c)));

            Vendors = new ObservableCollection<VendorViewModel>(vendorService.GetVendors().Select(c=>new VendorViewModel(c)));
        }

        public ItemVendorViewModel ItemVendorViewModel { get; }

        public ObservableCollection<ItemViewModel> Items { get; }
        public ObservableCollection<VendorViewModel> Vendors { get; }

        public ItemViewModel SelectedItem { get; set; }
        public VendorViewModel SelectedVendor { get; set; }

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