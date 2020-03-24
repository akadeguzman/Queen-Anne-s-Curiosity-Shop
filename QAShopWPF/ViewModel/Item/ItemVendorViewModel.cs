using System.Runtime.Serialization.Formatters;
using GalaSoft.MvvmLight;
using QAShop_System.EfClasses;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemVendorViewModel : ObservableObject
    {
        private int _itemVendorId;
        private int _price;
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

        public ItemVendorViewModel(int itemVendorId, int price,  int vendorId, int itemId)
        {
            ItemVendorId = itemVendorId;
            Price = price;
            VendorId = vendorId;
            ItemId = itemId;

        }

        public ItemVendorViewModel(ItemVendor itemVendor)
        {
            ItemId = itemVendor.ItemId;
            Price = itemVendor.Price;

            VendorId = itemVendor.ItemVendorId;

            Vendor = itemVendor.VendorLink.CompanyName ?? itemVendor.VendorLink.GetFullName();

            ItemId = itemVendor.ItemId;
            Item = itemVendor.ItemLink.ItemDescription;
        }
    }
}