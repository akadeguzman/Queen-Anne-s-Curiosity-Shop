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

    }
}