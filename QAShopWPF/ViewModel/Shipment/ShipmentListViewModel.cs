using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipment
{
    public class ShipmentListViewModel
    {
        private ShipmentService _shipmentService;
        private ShipmentViewModel _selectedShipment;
        private string _searchText;
        private string _shipmentCount;

        public ShipmentListViewModel(ShipmentService shipmentService)
        {
            _shipmentService = shipmentService;

            var shipment = _shipmentService.GetShipments()
                .Select(c =>
                    new ShipmentViewModel(c)).ToList();

            ShipmentList = new ObservableCollection<ShipmentViewModel>(shipment);

        }


        public ObservableCollection<ShipmentViewModel> ShipmentList { get; }

        public ShipmentViewModel SelectedShipment { get; set; }

        public string ShipmentCount
        {
            get => _shipmentCount;
            set
            {
                _shipmentCount = value;
                GetShipmentCount();
            }
        }
        public string GetShipmentCount()
        {
            var count = $"{ShipmentList.Count}";
            return count;
        }

        public void SearchShipment(string searchString)
        {
            ShipmentList.Clear();

            var shipments = _shipmentService.GetShipments().Where(c => c.ShipperId.ToString().Contains(searchString) ||
                                                                      c.CountryOfOrigin.Contains(searchString) ||
                                                                      c.InsurerName.Contains(searchString) ||
                                                                      c.ShipperLink.ShipperName.Contains(searchString) ||
                                                                      c.ShipperInvoiceNumber.Contains(searchString) ||
                                                                      c.ShipmentId.ToString().Contains(searchString));

            foreach (var shipment in shipments)
            {
                var shipmentModel = new ShipmentViewModel(shipment.ShipmentId, shipment.CountryOfOrigin, shipment.Destination,
                    shipment.ShipperInvoiceNumber, shipment.DepartureDate, shipment.ArrivalDate, shipment.InsuredValue, shipment.InsurerName,
                    shipment.ShipperLink.ShipperName, shipment.ShipperId);
                ShipmentList.Add(shipmentModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchShipment(_searchText);
            }
        }
    }
}
