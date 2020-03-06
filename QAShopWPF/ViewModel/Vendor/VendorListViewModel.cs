using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Vendor
{
    public class VendorListViewModel
    {
        private VendorService _vendorService;
        private VendorViewModel _selectedVendor;
        private string _searchText;

        public VendorListViewModel(VendorService vendorService)
        {
            _vendorService = vendorService;

            var vendor = _vendorService.GetVendors()
                .Select(c =>
                    new VendorViewModel(
                        c.VendorId,
                        c.FirstName,
                        c.LastName,
                        c.ContactNumber,
                        c.CompanyName)).ToList();

            VendorList = new ObservableCollection<VendorViewModel>(vendor);

        }


        public ObservableCollection<VendorViewModel> VendorList { get; }

        public VendorViewModel SelectedVendor { get; set; }

        public void SearchVendor(string searchString)
        {
            VendorList.Clear();

            var vendors = _vendorService.GetVendors().Where(c => c.VendorId.ToString().Contains(searchString) ||
                                                                      c.LastName.Contains(searchString) ||
                                                                      c.FirstName.Contains(searchString) ||
                                                                      c.GetFullName().Contains(searchString));

            foreach (var vendor in vendors)
            {
                var vendorModel = new VendorViewModel(vendor.VendorId, vendor.FirstName, vendor.LastName,
                    vendor.ContactNumber, vendor.CompanyName);
                VendorList.Add(vendorModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchVendor(_searchText);
            }
        }
    }
}