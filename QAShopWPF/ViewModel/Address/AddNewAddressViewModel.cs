using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.Views.Address;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Address
{
    public class AddNewAddressViewModel
    {
        private readonly AddressListViewModel _addressListViewModel;
        private AddressService _addressService;
        private AddNewAddressView _addNewAddressView;


        public AddNewAddressViewModel(AddressService addressService)
        {
            var blankAddress = new QAShop_System.EfClasses.Address();
            AddressViewModel = new AddressViewModel(blankAddress.AddressId, blankAddress.City, blankAddress.State, blankAddress.ZipCode);

            _addressService = addressService;
            
        }

        public AddressViewModel AddressViewModel { get; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        
        public ICommand AddAddress => new RelayCommand(Add);
        public ICommand CloseCommand => new RelayCommand(Close);

        public void Close()
        {
            _addNewAddressView.Close();
        }
        public void Add()
        {
            var addressToAdd = new QAShop_System.EfClasses.Address {City = City, State = State, ZipCode = ZipCode};

            _addressService.AddAddress(addressToAdd);

            AddressViewModel.AddressId = addressToAdd.AddressId;
            AddressViewModel.City = City;
            AddressViewModel.State = State;
            AddressViewModel.ZipCode = ZipCode;
        }
    }
}
