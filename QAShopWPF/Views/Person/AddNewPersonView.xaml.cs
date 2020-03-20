using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.Views.Address;
using ServiceLayer;

namespace QAShopWPF.Views.Person
{
    /// <summary>
    /// Interaction logic for AddNewPersonView.xaml
    /// </summary>
    public partial class AddNewPersonView : Window
    {
        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;
        private AddressListViewModel _addressListViewModel;
        private PersonListViewModel _personListViewModel;

        private AddPersonViewModel _toAddPerson;

        public AddNewPersonView(PersonListViewModel personListViewModel, AddressService addressService, PersonTypeService personTypeService, PersonService personService, AddressListViewModel addressListViewModel)
        {
            InitializeComponent();

            _toAddPerson = new AddPersonViewModel(personService, personTypeService, addressService);

            _personService = personService;
            _personListViewModel = personListViewModel;
            _personTypeService = personTypeService;
            _addressService = addressService;
            _addressListViewModel = new AddressListViewModel(addressService);
            

            DataContext = _toAddPerson;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _toAddPerson.Add();
            _personListViewModel.PersonList.Insert(0, _toAddPerson.PersonViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnNewAddress_Click(object sender, RoutedEventArgs e)
        {
            var addNewAddress = new AddNewAddressView(_addressListViewModel, _addressService);
            addNewAddress.Show();
        }
    }
}
