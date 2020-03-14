using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using GalaSoft.MvvmLight.Command;
using QAShop_System.EfClasses;
using QAShopWPF.Views.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class AddPersonViewModel
    {
        private readonly PersonListViewModel _personListViewModel;
        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;
        private AddNewPersonView _addNewPersonView;


        public AddPersonViewModel(PersonService personService, PersonTypeService personTypeService, AddressService addressService)
        {
            var blankPerson = new QAShop_System.EfClasses.Person();
            PersonViewModel = new PersonViewModel(blankPerson.PersonId, blankPerson.LastName, blankPerson.FirstName, blankPerson.PhoneNumber, "", "", "", blankPerson.PersonTypeId, blankPerson.AddressId, blankPerson.AdditionalContactId);

            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;

            PersonTypes = new ObservableCollection<PersonType>(_personTypeService.GetPersonTypes());
            SelectedPersonType = PersonTypes.First();

            Address = new ObservableCollection<QAShop_System.EfClasses.Address>(_addressService.GetAddresses());
            SelectedAddress = Address.First();

            AdditionalContacts = new ObservableCollection<QAShop_System.EfClasses.Person>(_personService.GetPersons());
            SelectedAdditionalContacts = AdditionalContacts.First();
        }

        public PersonViewModel PersonViewModel { get; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }

        public ObservableCollection<PersonType> PersonTypes { get; }
        public ObservableCollection<QAShop_System.EfClasses.Address> Address { get; }
        public ObservableCollection<QAShop_System.EfClasses.Person> AdditionalContacts { get; }

        public PersonType SelectedPersonType { get; set; }
        public QAShop_System.EfClasses.Address SelectedAddress { get; set; }
        public QAShop_System.EfClasses.Person SelectedAdditionalContacts { get; set; }

        public ICommand AddPerson => new RelayCommand(Add);
        public ICommand CloseCommand => new RelayCommand(Close);

        public void Close()
        {
            _addNewPersonView.Close();
        }
        public void Add()
        {
            var personToAdd = new QAShop_System.EfClasses.Person();
            personToAdd.LastName = LastName;
            personToAdd.FirstName = FirstName;
            personToAdd.PhoneNumber = PhoneNumber;
            personToAdd.AddressId = SelectedAddress.AddressId;
            personToAdd.PersonTypeId = SelectedPersonType.PersonTypeId;
            personToAdd.AdditionalContactId = SelectedAdditionalContacts.PersonTypeId;

            _personService.AddPerson(personToAdd);

            PersonViewModel.PersonId = personToAdd.PersonId;
            PersonViewModel.LastName = LastName;
            PersonViewModel.FirstName = FirstName;
            PersonViewModel.PhoneNumber = PhoneNumber;
            PersonViewModel.AddressId = SelectedAddress.AddressId;
            PersonViewModel.PersonTypeId = SelectedPersonType.PersonTypeId;
            PersonViewModel.AdditionalContactId = SelectedAdditionalContacts.PersonTypeId;
        }
    }
}
