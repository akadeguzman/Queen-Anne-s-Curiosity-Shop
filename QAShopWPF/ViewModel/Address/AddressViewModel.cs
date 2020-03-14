using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;
using ServiceLayer;


namespace QAShopWPF.ViewModel.Address
{
    public class AddressViewModel : ObservableObject
    {
        #region Properties

        private int _addressId;
        private string _city;
        private string _state;
        private string _zipCode;

        public int AddressId
        {
            get => _addressId;
            internal set
            {
                _addressId = value;
                RaisePropertyChanged(nameof(AddressId));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                RaisePropertyChanged(nameof(City));
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                RaisePropertyChanged(nameof(State));
            }
        }

        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                RaisePropertyChanged(nameof(ZipCode));
            }
        }

        public AddressViewModel(
            int addressId,
            string city,
            string state,
            string zipCode)
        {
            _addressId = addressId;
            _city = city;
            _state = state;
            _zipCode = zipCode;
        }

        public AddressViewModel(QAShop_System.EfClasses.Address address)
        {
            AddressId = address.AddressId;
            City = address.City;
            State = address.State;
            ZipCode = address.ZipCode;
        }

        public AddressViewModel()
        {
            
        }

        #endregion

    }
}