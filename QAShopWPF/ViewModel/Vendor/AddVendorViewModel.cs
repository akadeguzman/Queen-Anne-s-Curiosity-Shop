using System;
using System.Collections.Generic;
using System.Text;
using QAShopWPF.Annotations;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Vendor
{
    public class AddVendorViewModel
    {
        private readonly VendorListViewModel _vendorListViewModel;
        private VendorService _vendorService;

        public AddVendorViewModel(VendorService vendorService)
        {
            var blankVendor = new QAShop_System.EfClasses.Vendor();
            VendorViewModel = new VendorViewModel(blankVendor.VendorId, blankVendor.FirstName, blankVendor.LastName, blankVendor.ContactNumber, blankVendor.CompanyName);

            _vendorService = vendorService;
        }

        public VendorViewModel VendorViewModel { get; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        [CanBeNull] public string CompanyName { get; set; }

        public void Add()
        {
            var vendorToAdd = new QAShop_System.EfClasses.Vendor();
            vendorToAdd.FirstName = FirstName;
            vendorToAdd.LastName = LastName;
            vendorToAdd.ContactNumber = ContactNumber;
            vendorToAdd.CompanyName = CompanyName;

            _vendorService.AddVendor(vendorToAdd);

            VendorViewModel.VendorId = vendorToAdd.VendorId;
            VendorViewModel.FirstName = vendorToAdd.FirstName;
            VendorViewModel.LastName = vendorToAdd.LastName;
            VendorViewModel.ContactNumber = vendorToAdd.ContactNumber;
            VendorViewModel.CompanyName = vendorToAdd.CompanyName;
        }
    }
}
