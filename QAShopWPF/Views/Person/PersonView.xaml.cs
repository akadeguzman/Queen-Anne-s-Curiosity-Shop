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
        private PersonListViewModel _personListViewModel;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;
        private AddressListViewModel _addressListViewModel;
        
        public PersonView(PersonListViewModel personListViewModel, PersonTypeService personTypeService, AddressService addressService, PersonService personService, AddressListViewModel addressListViewModel)
        {
            InitializeComponent();

            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;
            _addressListViewModel = addressListViewModel;
            _personListViewModel = new PersonListViewModel(personService);
            DataContext = _personListViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var addPerson = new AddNewPersonView(_personListViewModel, _addressService, _personTypeService, _personService, _addressListViewModel);
            addPerson.Show();
        }
    }
}
