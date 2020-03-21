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
        
        private AddNewAddressViewModel _toAddAddress;
        private AddressService _addressService;
        private AddressListViewModel _addressListViewModel;
        private AddPersonViewModel _addPersonViewModel;

        public AddNewAddressView(AddressService addressService, AddressListViewModel addressListViewModel, AddPersonViewModel addPersonViewModel)
        {
            _addressService = addressService;
            _addressListViewModel = addressListViewModel;
            _addPersonViewModel = addPersonViewModel;

            InitializeComponent();
            
            _toAddAddress = new AddNewAddressViewModel(addressService);
            DataContext = _toAddAddress;
        }

        private void BtnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            _toAddAddress.Add();
            _addressListViewModel.AddressList.Insert(0, _toAddAddress.AddressViewModel);

            //refreshing new the combo box items
            var addressToAdd = _addressService.GetAddresses().ToList().Last();
            _addPersonViewModel.Address.Add(addressToAdd);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
