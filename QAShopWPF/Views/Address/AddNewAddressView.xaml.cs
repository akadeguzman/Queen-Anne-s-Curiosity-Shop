using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using QAShopWPF.Views.Person;
using ServiceLayer;

namespace QAShopWPF.Views.Address
{
    /// <summary>
    /// Interaction logic for AddNewAddressView.xaml
    /// </summary>
    public partial class AddNewAddressView : Window
    {
        
        private AddNewAddressViewModel _addressToAdd;
        private AddressService _addressService;
        private AddPersonViewModel _addPersonViewModel;
        private EditPersonViewModel _editPersonViewModel;

        public AddNewAddressView(AddressService addressService, AddPersonViewModel addPersonViewModel)
        {
            _addressService = addressService;
            _addPersonViewModel = addPersonViewModel;

            InitializeComponent();
            
            _addressToAdd = new AddNewAddressViewModel(addressService);
            DataContext = _addressToAdd;
        }

        public AddNewAddressView(AddressService addressService, EditPersonViewModel editPersonViewModel)
        {
            _addressService = addressService;
            _editPersonViewModel = editPersonViewModel;

            InitializeComponent();

            _addressToAdd = new AddNewAddressViewModel(addressService);
            DataContext = _addressToAdd;
        }

        private void BtnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            _addressToAdd.Add();

            //refreshing new the combo box items
            if (_addPersonViewModel == null)
            {
                var addressToEdit = _addressService.GetAddresses().ToList().Last();
                _editPersonViewModel.Addresses.Add(addressToEdit);
            }
            else
            {
                var addressToAdd = _addressService.GetAddresses().ToList().Last();
                _addPersonViewModel.Address.Add(addressToAdd);
            }
            
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
