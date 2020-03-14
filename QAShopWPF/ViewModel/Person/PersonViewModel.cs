using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class PersonViewModel : ObservableObject
    {
        #region Properties

        private int _personId;
        private string _lastName;
        private string _firstName;
        private string _phoneNumber;
        private string _personType;
        private string _address;
        [CanBeNull] private string _additionalContact;

        public int PersonId
        {
            get => _personId;
            internal set
            {
                _personId = value;
                RaisePropertyChanged(nameof(PersonId));
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

        public string FirstName
        {
            get => _firstName;
            internal set
            {
                _firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            internal set
            {
                _phoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }

        public string PersonType
        {
            get => _personType;
            internal set
            {
                _personType = value;
                RaisePropertyChanged(nameof(PersonType));
            }
        }

        public string Address
        {
            get => _address;
            internal set
            {
                _address = value;
                RaisePropertyChanged(nameof(Address));
            }
        }

        [CanBeNull]
        public string AdditionalContact
        {
            get => _additionalContact;
            internal set
            {
                _additionalContact = value;
                RaisePropertyChanged(nameof(AdditionalContact));
            }
        }

        public int PersonTypeId { get; set; }
        public int AddressId { get; set; }
        public int? AdditionalContactId { get; set; }

        public PersonViewModel(int personId, string lastName, string firstName, string phoneNumber, string personType, string address, [CanBeNull] string additionalContact, int personTypeId, int addressId, int? additionalContactId)
        {
            PersonId = personId;
            LastName = lastName;
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            PersonType = personType;
            Address = address;
            AdditionalContact = additionalContact;
            PersonTypeId = personTypeId;
            AddressId = addressId;
            AdditionalContactId = additionalContactId;
        }

        public PersonViewModel(QAShop_System.EfClasses.Person person)
        {
            PersonId = person.PersonId;
            LastName = person.LastName;
            FirstName = person.FirstName;
            PhoneNumber = person.PhoneNumber;
            PersonType = person.PersonTypeLink.Type;
            Address = person.AddressLink.City;
            AdditionalContact = person.AdditionalContactLink?.GetFullName();
            PersonTypeId = person.PersonTypeId;
            AddressId = person.AddressId;
            AdditionalContactId = person.AdditionalContactId;
        }

        public PersonViewModel()
        {
            
        }

        #endregion
    }
}