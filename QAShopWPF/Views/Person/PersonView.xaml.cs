using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QAShopWPF.ViewModel;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.Views.Person
{
    /// <summary>
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;
        private PersonListViewModel _personListViewModel;
        private AddressListViewModel _addressListViewModel;

        public PersonView(PersonListViewModel personListViewModel, AddPersonViewModel addPersonViewModel, PersonService personService, PersonTypeService personTypeService, AddressService addressService, AddressListViewModel addressListViewModel)
        {
            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;
            InitializeComponent();
            _personListViewModel = new PersonListViewModel(personService);
            _addressListViewModel = new AddressListViewModel(addressService);

            DataContext = _personListViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addPerson = new AddNewPersonView(_personService, _personTypeService, _addressService, _personListViewModel, _addressListViewModel);
            addPerson.Show();
        }
    }
}
