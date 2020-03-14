using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.Views.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Person
{
    public class PersonListViewModel
    {
        private PersonService _personService;
        private PersonViewModel _selectedPerson;
        private string _searchText;
        private string _personCount;
        private AddNewPersonView _addNewPersonView;

        public PersonListViewModel(PersonService personService)
        {
            _personService = personService;

            var person = _personService.GetPersons()
                .Select(c =>
                    new PersonViewModel(c)).ToList();

            PersonList = new ObservableCollection<PersonViewModel>(person);
        }


        public ObservableCollection<PersonViewModel> PersonList { get; }

        public string PersonCount
        {
            get => _personCount;
            set
            {
                _personCount = value;
                GetPersonCount();
            }
        }
        public string GetPersonCount()
        {
            var count = $"{PersonList.Count}";
            return count;
        }

        public PersonViewModel SelectedPerson { get; set; }

        public ICommand AddPerson => new RelayCommand(AddNewPerson);

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
                    person.PhoneNumber, person.PersonTypeLink.Type, person.AddressLink.City, person.AdditionalContactLink?.GetFullName(), person.PersonTypeId,
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

        public void AddNewPerson()
        {
            _addNewPersonView = new AddNewPersonView();
            _addNewPersonView.Owner = Application.Current.MainWindow;
            _addNewPersonView.DataContext = this;
            _addNewPersonView.ShowDialog();
        }
    }
}