using System;
using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipment
{
    public class EditShipmentViewModel
    {
        private ShipmentService _shipmentService;
        private ShipperService _shipperService;

        public EditShipmentViewModel(ShipmentViewModel shipmentViewModel, ShipperService shipperService, ShipmentService shipmentService)
        {
            AssociatedShipmentViewModel = shipmentViewModel;
            _shipmentService = shipmentService;
            _shipperService = shipperService;

            Shippers = new ObservableCollection<QAShop_System.EfClasses.Shipper>(shipperService.GetShippers());
            SelectedShipper = Shippers.First(c => c.ShipperId == AssociatedShipmentViewModel.ShipperId);


            CopyEditTableFields(shipmentViewModel);
        }

        private void CopyEditTableFields(ShipmentViewModel shipmentViewModel)
        {
            CountryOfOrigin = shipmentViewModel.CountryOfOrigin;
            Destination = shipmentViewModel.Destination;
            ShipperInvoiceNumber = shipmentViewModel.ShipperInvoiceNumber;
            DepartureDate = shipmentViewModel.DepartureDate;
            ArrivalDate = shipmentViewModel.ArrivalDate;
            InsuredValue = shipmentViewModel.InsuredValue;
            InsurerName = shipmentViewModel.InsurerName;
        }

        public ObservableCollection<QAShop_System.EfClasses.Shipper> Shippers { get; set; }
        public QAShop_System.EfClasses.Shipper SelectedShipper { get; set; }
        
        public ShipmentViewModel AssociatedShipmentViewModel { get; set; }

        public string CountryOfOrigin { get; set; }
        public string Destination { get; set; }
        public string ShipperInvoiceNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public int InsuredValue { get; set; }
        public string InsurerName { get; set; }

        public void Edit()
        {
            _shipmentService.UpdateShipment(AssociatedShipmentViewModel.ShipmentId, CountryOfOrigin, Destination, ShipperInvoiceNumber, DepartureDate, ArrivalDate, InsuredValue, InsurerName, SelectedShipper.ShipperId);
        }
    }
}