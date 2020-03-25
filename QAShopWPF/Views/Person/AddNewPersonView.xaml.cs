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
 using QAShopWPF.ViewModel;
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
        private AddPersonViewModel _personToAdd;
        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private AddressService _addressService;
        private PersonListViewModel _personListViewModel;
        private AddressListViewModel _addressListViewModel;


        public AddNewPersonView(PersonService personService, PersonTypeService personTypeService, AddressService addressService, PersonListViewModel personListViewModel, AddressListViewModel addressListViewModel)
        {
            InitializeComponent();

            _personService = personService;
            _personTypeService = personTypeService;
            _addressService = addressService;
            _personListViewModel = personListViewModel;
            _addressListViewModel = addressListViewModel;

            _personToAdd = new AddPersonViewModel(personTypeService, addressService, personService);

            DataContext = _personToAdd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _personToAdd.Add();
            _personListViewModel.PersonList.Insert(0, _personToAdd.PersonViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnNewAddress_Click(object sender, RoutedEventArgs e)
        {
            var addNewAddress = new AddNewAddressView(_addressService, _personToAdd);
            addNewAddress.Show();
        }
    }
}
