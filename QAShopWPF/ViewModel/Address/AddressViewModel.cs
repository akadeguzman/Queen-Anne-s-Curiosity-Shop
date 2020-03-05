using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;


namespace QAShopWPF.ViewModel.Address
{
    public class AddressViewModel : INotifyPropertyChanged
    {
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
                OnPropertyChanged(nameof(AddressId));
            }
        }

        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public string ZipCode
        {
            get => _zipCode;
            set
            {
                _zipCode = value;
                OnPropertyChanged(nameof(ZipCode));
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}