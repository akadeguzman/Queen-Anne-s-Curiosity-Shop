using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Shipper
{
    public class ShipperViewModel : ObservableObject
    {
        #region Properties

        private int _shipperId;
        private string _shipperName;
        private string _shipperContact;
        private string _shipperFax;

        public int ShipperId
        {
            get => _shipperId;
            internal set
            {
                _shipperId = value;
                RaisePropertyChanged(nameof(ShipperId));
            }
        }

        public string ShipperName
        {
            get => _shipperName;
            internal set
            {
                _shipperName = value;
                RaisePropertyChanged(nameof(ShipperName));
            }
        }

        public string ShipperContact
        {
            get => _shipperContact;
            internal set
            {
                _shipperContact = value;
                RaisePropertyChanged(nameof(ShipperContact));
            }
        }

        public string ShipperFax
        {
            get => _shipperFax;
            internal set
            {
                _shipperFax = value;
                RaisePropertyChanged(nameof(ShipperFax));
            }
        }

        public ShipperViewModel(int shipperId, string shipperName, string shipperContact, string shipperFax)
        {
            ShipperId = shipperId;
            ShipperName = shipperName;
            ShipperContact = shipperContact;
            ShipperFax = shipperFax;
        }

        public ShipperViewModel(QAShop_System.EfClasses.Shipper shipper)
        {
            ShipperId = shipper.ShipperId;
            ShipperName = shipper.ShipperName;
            ShipperContact = shipper.ShipperContact;
            ShipperFax = shipper.ShipperFax;
        }


        #endregion

        private ShipperService _shipperService;
        private ShipperViewModel _selectedShipper;
        private string _searchText;
        private int _shipperCount;

        public ShipperViewModel()
        {
            GenerateShipper();
        }

        public void GenerateShipper()
        {
            var shipper = _shipperService.GetShippers()
                .Select(c =>
                    new ShipperViewModel(c)).ToList();

            ShipperList = new ObservableCollection<ShipperViewModel>(shipper);
            ShipperCount = ShipperList.Count;
        }


        public ObservableCollection<ShipperViewModel> ShipperList { get; set; } = new ObservableCollection<ShipperViewModel>();

        public int ShipperCount
        {
            get => _shipperCount;
            set => Set(ref _shipperCount, value);
        }

        public ShipperViewModel SelectedShipper { get; set; }

        public void SearchShipper(string searchString)
        {
            ShipperList.Clear();

            var shippers = _shipperService.GetShippers().Where(c => c.ShipperId.ToString().Contains(searchString) ||
                                                                    c.ShipperName.Contains(searchString) ||
                                                                    c.ShipperContact.Contains(searchString) ||
                                                                    c.ShipperFax.Contains(searchString));

            foreach (var shipper in shippers)
            {
                var shipperModel = new ShipperViewModel(shipper.ShipperId, shipper.ShipperName, shipper.ShipperContact,
                    shipper.ShipperFax);
                ShipperList.Add(shipperModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchShipper(_searchText);
            }
        }
    }
}