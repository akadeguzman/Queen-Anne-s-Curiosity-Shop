using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.Views.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class PersonListViewModel
    {
        private PersonService _personService;
        private string _searchText;
        private string _personCount;

        public PersonListViewModel(PersonService personService)
        {
            _personService = personService;

            var person = _personService.GetPersons()
                .Select(c =>
                    new PersonViewModel(c)).ToList();

            PersonList = new ObservableCollection<PersonViewModel>(person);
        }

        public void Sync()
        {
            PersonList.Clear();

            var persons = _personService.GetPersons()
                .Select(c =>
                    new PersonViewModel(c)).ToList();

            foreach (var person in persons)
            {
                PersonList.Add(person);
            }

        }

        public ObservableCollection<PersonViewModel> PersonList { get; }
        
        public PersonViewModel SelectedPerson { get; set; }
        
        public void SearchPerson(string searchString)
        {
            PersonList.Clear();

            var persons = _personService.GetPersons().Where(c => c.PersonId.ToString().Contains(searchString) ||
                                                                      c.LastName.Contains(searchString) ||
                                                                      c.FirstName.Contains(searchString) ||
                                                                      c.AddressLink.City.Contains(searchString) ||
                                                                      c.PersonTypeLink.Type.Contains(searchString));

            foreach (var person in persons)
            {
                var personModel = new PersonViewModel(person.PersonId, person.LastName, person.FirstName,
                    person.PhoneNumber, person.PersonTypeLink.Type, person.AddressLink.City, person.AdditionalContactLink.GetFullName(), person.PersonTypeId,
                    person.AddressId, person.AdditionalContactId);
                PersonList.Add(personModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchPerson(_searchText);
            }
        }
    }
}