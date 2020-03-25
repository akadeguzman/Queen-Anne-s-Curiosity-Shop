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
using QAShopWPF.ViewModel.Person;
using QAShopWPF.Views.Address;
using ServiceLayer;

namespace QAShopWPF.Views.Person
{
    /// <summary>
    /// Interaction logic for EditPersonView.xaml
    /// </summary>
    public partial class EditPersonView : Window
    {
        public EditPersonView()
        {
            InitializeComponent();
        }

        private EditPersonViewModel _toEditPerson;
        private PersonListViewModel _personListViewModel;
        private AddressService _addressService;

        public EditPersonView(PersonListViewModel personListViewModel, PersonViewModel personViewModel, PersonService personService, PersonTypeService personTypeService, AddressService addressService) : this()
        {
            
            _toEditPerson = new EditPersonViewModel(personViewModel, personService, personTypeService, addressService);
            _personListViewModel = personListViewModel;
            _addressService = addressService;
            DataContext = _toEditPerson;
        }

        private void BtnNewAddress_Click(object sender, RoutedEventArgs e)
        {
            var addNewAddress = new AddNewAddressView(_addressService, _toEditPerson);
            addNewAddress.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _toEditPerson.Edit();
            _personListViewModel.Sync();
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
