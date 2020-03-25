
using System.Collections.ObjectModel;
using System.Linq;
using QAShop_System.EfClasses;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class EditPersonViewModel
    {
        private PersonViewModel _vendorViewModel;
        private PersonService _personService;
        private AddressService _addressService;
        private PersonTypeService _personTypeService;

        public EditPersonViewModel(PersonViewModel personViewModel, PersonService personService, PersonTypeService personTypeService, AddressService addressService)
        {
            AssociatedPersonViewModel = personViewModel;
            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;

            AdditionalContacts = new ObservableCollection<QAShop_System.EfClasses.Person>(personService.GetPersons());
            SelectedAdditionalContact = AdditionalContacts.First(c => c.AdditionalContactId == AssociatedPersonViewModel.AdditionalContactId);

            PersonTypes = new ObservableCollection<PersonType>(personTypeService.GetPersonTypes());
            SelectedPersonType = PersonTypes.First(c => c.PersonTypeId == AssociatedPersonViewModel.PersonTypeId);

            Addresses = new ObservableCollection<QAShop_System.EfClasses.Address>(addressService.GetAddresses());
            SelectedAddress = Addresses.First(c => c.AddressId == AssociatedPersonViewModel.AddressId);

            CopyEditTableFields(personViewModel);
        }

        private void CopyEditTableFields(PersonViewModel personViewModel)
        {
            FirstName = personViewModel.FirstName;
            LastName = personViewModel.LastName;
            PhoneNumber = personViewModel.PhoneNumber;
        }

        public ObservableCollection<QAShop_System.EfClasses.Person> AdditionalContacts { get; set; }
        public QAShop_System.EfClasses.Person SelectedAdditionalContact { get; set; }

        public ObservableCollection<PersonType> PersonTypes { get; set; }
        public PersonType SelectedPersonType { get; set; }

        public ObservableCollection<QAShop_System.EfClasses.Address> Addresses { get; set; }
        public QAShop_System.EfClasses.Address SelectedAddress { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

        public PersonViewModel AssociatedPersonViewModel { get; set; }

        public void Edit()
        {
            _personService.UpdatePerson(AssociatedPersonViewModel.PersonId, LastName, FirstName, PhoneNumber, SelectedPersonType.PersonTypeId, SelectedAddress.AddressId, SelectedAdditionalContact.PersonId);
        }
    }
}