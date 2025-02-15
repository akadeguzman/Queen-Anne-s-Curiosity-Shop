﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipment
{
    public class ShipmentViewModel : ObservableObject
    {
        #region Properties

        private int _shipmentId;
        private string _countryOfOrigin;
        private string _destination;
        private string _shipperInvoiceNumber;
        private DateTime _departureDate;
        private DateTime _arrivalDate;
        private int _insuredValue;
        private string _insurerName;
        private string _shipper;

        public int ShipmentId
        {
            get => _shipmentId;
            internal set
            {
                _shipmentId = value;
                RaisePropertyChanged(nameof(ShipmentId));
            }
        }

        public string CountryOfOrigin
        {
            get => _countryOfOrigin;
            internal set
            {
                _countryOfOrigin = value;
                RaisePropertyChanged(nameof(CountryOfOrigin));
            }
        }

        public string Destination
        {
            get => _destination;
            internal set
            {
                _destination = value;
                RaisePropertyChanged(nameof(Destination));
            }
        }

        public string ShipperInvoiceNumber
        {
            get => _shipperInvoiceNumber;
            internal set
            {
                _shipperInvoiceNumber = value;
                RaisePropertyChanged(nameof(ShipperInvoiceNumber));
            }
        }

        public DateTime DepartureDate
        {
            get => _departureDate;
            internal set
            {
                _departureDate = value;
                RaisePropertyChanged(nameof(DepartureDate));
            }
        }

        public DateTime ArrivalDate
        {
            get => _arrivalDate;
            internal set
            {
                _arrivalDate = value;
                RaisePropertyChanged(nameof(ArrivalDate));
            }
        }

        public int InsuredValue
        {
            get => _insuredValue;
            internal set
            {
                _insuredValue = value;
                RaisePropertyChanged(nameof(InsuredValue));
            }
        }

        public string InsurerName
        {
            get => _insurerName;
            internal set
            {
                _insurerName = value;
                RaisePropertyChanged(nameof(InsurerName));
            }
        }

        public string Shipper
        {
            get => _shipper;
            internal set
            {
                _shipper = value;
                RaisePropertyChanged(nameof(Shipper));
            }
        }

        public int ShipperId { get; set; }

        public ShipmentViewModel(int shipmentId, string countryOfOrigin, string destination, string shipperInvoiceNumber, DateTime departureDate, DateTime arrivalDate, int insuredValue, string insurerName, string shipper, int shipperId)
        {
            ShipmentId = shipmentId;
            CountryOfOrigin = countryOfOrigin;
            Destination = destination;
            ShipperInvoiceNumber = shipperInvoiceNumber;
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            InsuredValue = insuredValue;
            InsurerName = insurerName;
            Shipper = shipper;
            ShipperId = shipperId;
        }

        public ShipmentViewModel(QAShop_System.EfClasses.Shipment shipment)
        {
            ShipmentId = shipment.ShipmentId;
            CountryOfOrigin = shipment.CountryOfOrigin;
            Destination = shipment.Destination;
            ShipperInvoiceNumber = shipment.ShipperInvoiceNumber;
            DepartureDate = shipment.DepartureDate;
            ArrivalDate = shipment.ArrivalDate;
            InsuredValue = shipment.InsuredValue;
            InsurerName = shipment.InsurerName;
            Shipper = shipment.ShipperLink.ShipperName;
            ShipperId = shipment.ShipperId;
        }

        #endregion
        
    }
}