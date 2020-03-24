using System.Collections.ObjectModel;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Vendor
{
    public class EditVendorViewModel
    {
        private VendorViewModel _vendorViewModel;
        private VendorService _vendorService;

        public EditVendorViewModel(VendorViewModel vendorViewModel, VendorService vendorService)
        {
            AssociatedVendorViewModel = vendorViewModel;
            _vendorService = vendorService;
            

            CopyEditTableFields(vendorViewModel);
        }

        private void CopyEditTableFields(VendorViewModel vendorViewModel)
        {
            CompanyName = vendorViewModel.CompanyName;
            if (CompanyName == null)
            {
                CompanyName = "";
            }

            LastName = vendorViewModel.LastName;
            FirstName = vendorViewModel.FirstName;
            ContactNumber = vendorViewModel.ContactNumber;
        }

        public string CompanyName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string ContactNumber { get; set; }
        
        public VendorViewModel AssociatedVendorViewModel { get; set; }

        public void Edit()
        {
            _vendorService.UpdateVendor(AssociatedVendorViewModel.VendorId, FirstName, LastName, ContactNumber,CompanyName);
        }
    }
}