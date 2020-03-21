using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.Views.Address;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Address
{
    public class AddNewAddressViewModel
    {
        private AddressService _addressService;

        public AddNewAddressViewModel(AddressService addressService)
        {
            _addressService = addressService;

            var blankAddress = new QAShop_System.EfClasses.Address();
            AddressViewModel = new AddressViewModel(blankAddress.AddressId, blankAddress.City, blankAddress.State, blankAddress.ZipCode);

        }

        public AddressViewModel AddressViewModel { get; }

        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        
        public void Add()
        {
            var addressToAdd = new QAShop_System.EfClasses.Address();
            addressToAdd.City = City;
            addressToAdd.State = State;
            addressToAdd.ZipCode = ZipCode;

            _addressService.AddAddress(addressToAdd);

            AddressViewModel.AddressId = addressToAdd.AddressId;
            AddressViewModel.City = City;
            AddressViewModel.State = State;
            AddressViewModel.ZipCode = ZipCode;
        }
    }
}
