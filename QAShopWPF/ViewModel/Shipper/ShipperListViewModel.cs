using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipper
{
    public class ShipperListViewModel
    {
        private ShipperService _shipperService;
        private ShipperViewModel _selectedShipper;
        private string _searchText;

        public ShipperListViewModel(ShipperService shipperService)
        {
            _shipperService = shipperService;

            var shipper = _shipperService.GetShippers()
                .Select(c =>
                    new ShipperViewModel(c)).ToList();

            ShipperList = new ObservableCollection<ShipperViewModel>(shipper);

        }


        public ObservableCollection<ShipperViewModel> ShipperList { get; }

        public ShipperViewModel SelectedShipper { get; set; }

        public void SearchShipper(string searchString)
        {
            ShipperList.Clear();

            var shippers = _shipperService.GetShippers().Where(c => c.ShipperId.ToString().Contains(searchString) ||
                                                                   c.ShipperName.Contains(searchString) ||
                                                                   c.ShipperContact.Contains(searchString) ||
                                                                   c.ShipperFax.Contains(searchString));

            foreach (var shipper in shippers)
            {
                var shipperModel = new ShipperViewModel(shipper.ShipperId, shipper.ShipperName, shipper.ShipperContact,
                    shipper.ShipperFax);
                ShipperList.Add(shipperModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchShipper(_searchText);
            }
        }
    }
}
