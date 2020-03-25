using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Vendor
{
    public class VendorListViewModel
    {
        private readonly VendorService _vendorService;
        private string _searchText;

        public VendorListViewModel(VendorService vendorService)
        {
            _vendorService = vendorService;

            var vendor = _vendorService.GetVendors()
                .Select(c =>
                    new VendorViewModel(c)).ToList();

            VendorList = new ObservableCollection<VendorViewModel>(vendor);
            VendorCount = VendorList.Count.ToString();

        }

        public string VendorCount { get; }

        public void Sync()
        {
            VendorList.Clear();

            var vendor = _vendorService.GetVendors()
                .Select(c =>
                    new VendorViewModel(c)).ToList();

            foreach (var vendorViewModel in vendor)
            {
                VendorList.Add(vendorViewModel);
            }
            
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