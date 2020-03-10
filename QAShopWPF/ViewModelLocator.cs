using System;
using System.Collections.Generic;
using System.Text;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Procurement;
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Shipper;
using QAShopWPF.ViewModel.Transaction;
using QAShopWPF.ViewModel.Vendor;

namespace QAShopWPF
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            AddressViewModel = new AddressViewModel();
            ItemViewModel = new ItemViewModel();
            PersonViewModel = new PersonViewModel();
            ProcurementViewModel = new ProcurementViewModel();
            ShipmentViewModel = new ShipmentViewModel();
            ShipperViewModel = new ShipperViewModel();
            TransactionViewModel = new TransactionViewModel();
            VendorViewModel = new VendorViewModel();
        }
        
        public AddressViewModel AddressViewModel { get; set; }
        public ItemViewModel ItemViewModel { get; set; }
        public PersonViewModel PersonViewModel { get; set; }
        public ProcurementViewModel ProcurementViewModel { get; set; }
        public ShipmentViewModel ShipmentViewModel { get; set; }
        public ShipperViewModel ShipperViewModel { get; set; }
        public TransactionViewModel TransactionViewModel { get; set; }
        public VendorViewModel VendorViewModel { get; set; }

    }
}
