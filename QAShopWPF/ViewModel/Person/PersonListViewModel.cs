using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Item;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class PersonListViewModel
    {
        private PersonService _personService;
        private PersonViewModel _selectedPerson;
        private string _searchText;

        public PersonListViewModel(PersonService personService)
        {
            _personService = personService;

            var person = _personService.GetPersons()
                .Select(c =>
                    new PersonViewModel(
                        c.PersonId,
                        c.LastName,
                        c.FirstName,
                        c.PhoneNumber,
                        c.PersonTypeLink.Type,
                        c.AddressLink.City,
                        c.AdditionalContactLink.GetFullName(),
                        c.PersonTypeId,
                        c.AddressId,c.AdditionalContactId)).ToList();

            PersonList = new ObservableCollection<PersonViewModel>(person);

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