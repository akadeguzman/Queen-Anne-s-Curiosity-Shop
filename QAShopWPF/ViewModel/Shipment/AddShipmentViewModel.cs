using System;
using System.Collections.ObjectModel;
using System.Linq;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipment
{
    public class AddShipmentViewModel
    {
        private ShipperService _shipperService;
        private ShipmentService _shipmentService;

        public AddShipmentViewModel(ShipperService shipperService, ShipmentService shipmentService)
        {
            _shipperService = shipperService;
            _shipmentService = shipmentService;

            var blankShipment = new QAShop_System.EfClasses.Shipment();
            ShipmentViewModel = new ShipmentViewModel(blankShipment.ShipmentId, blankShipment.CountryOfOrigin,
                blankShipment.Destination, blankShipment.ShipperInvoiceNumber,
                blankShipment.DepartureDate, blankShipment.ArrivalDate,
                blankShipment.InsuredValue, blankShipment.InsurerName,
                "", blankShipment.ShipperId);

            Shippers = new ObservableCollection<QAShop_System.EfClasses.Shipper>(_shipperService.GetShippers());
            
        }

        public ShipmentViewModel ShipmentViewModel { get; }

        public ObservableCollection<QAShop_System.EfClasses.Shipper> Shippers { get; }

        public QAShop_System.EfClasses.Shipper SelectedShipper { get; set; }

        public string CountryOfOrigin { get; set; }
        public string Destination { get; set; }
        public string ShipperInvoiceNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int InsuredValue { get; set; }
        public string InsurerName { get; set; }


        public void Add()
        {
            var shipmentToAdd = new QAShop_System.EfClasses.Shipment();
            shipmentToAdd.CountryOfOrigin = CountryOfOrigin;
            shipmentToAdd.Destination = Destination;
            shipmentToAdd.ShipperInvoiceNumber = ShipperInvoiceNumber;
            shipmentToAdd.ShipperId = SelectedShipper.ShipperId;
            shipmentToAdd.DepartureDate = DepartureDate;
            shipmentToAdd.ArrivalDate = ArrivalDate;
            shipmentToAdd.InsuredValue = InsuredValue;
            shipmentToAdd.InsurerName = InsurerName;


           _shipmentService.AddShipment(shipmentToAdd);

            ShipmentViewModel.ShipmentId = shipmentToAdd.ShipmentId;
            ShipmentViewModel.CountryOfOrigin = shipmentToAdd.CountryOfOrigin;
            ShipmentViewModel.Destination = shipmentToAdd.Destination;
            ShipmentViewModel.ShipperInvoiceNumber = shipmentToAdd.ShipperInvoiceNumber;
            ShipmentViewModel.DepartureDate = shipmentToAdd.DepartureDate;
            ShipmentViewModel.ArrivalDate = shipmentToAdd.ArrivalDate;
            ShipmentViewModel.Shipper = shipmentToAdd.ShipperLink.ShipperName;
            ShipmentViewModel.InsuredValue = shipmentToAdd.InsuredValue;
            ShipmentViewModel.InsurerName = shipmentToAdd.InsurerName;
        }
    }
}