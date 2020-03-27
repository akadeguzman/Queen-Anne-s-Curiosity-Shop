using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using QAShopWPF.Annotations;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Item
{
    public class ItemVendorListViewModel : INotifyPropertyChanged
    {
        private ItemVendorService _itemVendorService;
        private ItemVendorViewModel _itemVendorViewModel;
        private string _searchText;
        private string _itemCount;

        public ItemVendorListViewModel(ItemVendorService itemVendorService)
        {
            _itemVendorService = itemVendorService;

            var items = itemVendorService.GetItemVendors()
                .Select(c =>
                    new ItemVendorViewModel(c)).ToList();

            ItemVendorList = new ObservableCollection<ItemVendorViewModel>(items);
            ItemCount = items.Count.ToString();
        }

        public void Sync()
        {
            ItemVendorList.Clear();

            var items = _itemVendorService.GetItemVendors()
                .Select(c =>
                    new ItemVendorViewModel(c)).ToList();

            foreach (var item in items)
            {
                ItemVendorList.Add(item);
            }

        }

        public ObservableCollection<ItemVendorViewModel> ItemVendorList { get; }

        public string ItemCount
        {
            get => _itemCount;
            set
            {
                _itemCount = value;
                OnPropertyChanged(nameof(ItemCount));
            }
        }

        public ItemVendorViewModel SelectedItemVendor { get; set; }

        public void SearchItem(string searchString)
        {
            ItemVendorList.Clear();

            var items = _itemVendorService.GetItemVendors().Where(c => c.ItemId.ToString().Contains(searchString) ||
                                                           c.City.Contains(searchString) ||
                                                           c.PurchaseDate.GetDateTimeFormats().Contains(searchString) ||
                                                           c.ItemLink.ItemDescription.Contains(searchString));

            foreach (var item in items)
            {
                var itemVendorModel = new ItemVendorViewModel(item.ItemVendorId, item.Price, item.PurchaseDate, item.City, item.LocalCurrency,
                    item.ExchangeRate, item.VendorId, item.ItemId, item.VendorLink.CompanyName??item.VendorLink.GetFullName(),
                    item.ItemLink.ItemDescription);
                ItemVendorList.Add(itemVendorModel);
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}