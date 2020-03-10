using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Vendor
{
    public class VendorViewModel : ObservableObject
    {
        #region Properties

        private int _vendorId;
        private string _firstName;
        private string _lastName;
        private string _contactNumber;
        [CanBeNull] public string _companyName;

        public int VendorId
        {
            get => _vendorId;
            internal set
            {
                _vendorId = value;
                RaisePropertyChanged(nameof(VendorId));
            }

        }

        public string FirstName
        {
            get => _firstName;
            internal set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }

        }

        public string LastName
        {
            get => _lastName;
            internal set
            {
                _lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }

        }

        public string ContactNumber
        {
            get => _contactNumber;
            internal set
            {
                _contactNumber = value;
                RaisePropertyChanged(nameof(ContactNumber));
            }

        }

        [CanBeNull]
        public string CompanyName
        {
            get => _companyName;
            internal set
            {
                _companyName = value;
                RaisePropertyChanged(nameof(CompanyName));
            }

        }

        public VendorViewModel(int vendorId, string firstName, string lastName, string contactNumber, [CanBeNull] string companyName)
        {
            VendorId = vendorId;
            FirstName = firstName;
            LastName = lastName;
            ContactNumber = contactNumber;
            CompanyName = companyName;
        }

        public VendorViewModel(QAShop_System.EfClasses.Vendor vendor)
        {
            VendorId = vendor.VendorId;
            FirstName = vendor.FirstName;
            LastName = vendor.LastName;
            ContactNumber = vendor.ContactNumber;
            CompanyName = vendor.CompanyName;
        }

        #endregion


        private VendorService _vendorService;
        private VendorViewModel _selectedVendor;
        private string _searchText;
        private int _vendorCount;

        public VendorViewModel()
        {
            GenerateVendors();
        }

        public void GenerateVendors()
        {
            var vendor = _vendorService.GetVendors()
                .Select(c =>
                    new VendorViewModel(
                        c.VendorId,
                        c.FirstName,
                        c.LastName,
                        c.ContactNumber,
                        c.CompanyName)).ToList();

            VendorList = new ObservableCollection<VendorViewModel>(vendor);
            VendorCount = VendorList.Count;
        }


        public ObservableCollection<VendorViewModel> VendorList { get; set; } = new ObservableCollection<VendorViewModel>();

        public int VendorCount
        {
            get => _vendorCount;
            set => Set(ref _vendorCount, value);
        }

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