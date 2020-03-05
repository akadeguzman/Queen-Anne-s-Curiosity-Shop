using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Address
{
    public class AddressListViewModel
    {
        private AddressService _addressService;
        private AddressViewModel _selectedMovie;
        private string _searchText;

        public AddressListViewModel(AddressService addressService)
        {
            _addressService = addressService;

            var address = _addressService.GetAddresses()
                .Select(c =>
                    new AddressViewModel(
                        c.AddressId,
                        c.City,
                        c.State,
                        c.ZipCode)).ToList();


            AddressList = new ObservableCollection<AddressViewModel>(address);

        }


        public ObservableCollection<AddressViewModel> AddressList { get; }

        public AddressViewModel SelectedMovie { get; set; }

        public void SearchMovie(string searchString)
        {
            AddressList.Clear();

            var addresses = _addressService.GetAddresses().Where(c => c.City.Contains(searchString) ||
                                                              c.AddressId.ToString().Contains(searchString) || 
                                                              c.State.Contains(searchString) || 
                                                              c.ZipCode.ToString().Contains(searchString));

            foreach (var address in addresses)
            {
                var movieModel = new AddressViewModel(address.AddressId, address.City, address.State,
                    address.ZipCode);
                AddressList.Add(movieModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchMovie(_searchText);
            }
        }
    }
}