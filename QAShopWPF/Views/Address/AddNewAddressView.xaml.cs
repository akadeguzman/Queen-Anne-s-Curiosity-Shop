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
using ServiceLayer;

namespace QAShopWPF.Views.Address
{
    /// <summary>
    /// Interaction logic for AddNewAddressView.xaml
    /// </summary>
    public partial class AddNewAddressView : Window
    {
        private AddressListViewModel _addressListViewModel;
        private AddressService _addressService;

        private AddNewAddressViewModel _toAddAddress;

        public AddNewAddressView(AddressListViewModel addressListViewModel, AddressService addressService)
        {
            InitializeComponent();

            _toAddAddress = new AddNewAddressViewModel(addressService);
            _addressListViewModel = addressListViewModel;
            _addressService = addressService;

            DataContext = _toAddAddress;
        }

        private void BtnAddAddress_Click(object sender, RoutedEventArgs e)
        {
            _toAddAddress.Add();
            _addressListViewModel.AddressList.Insert(0, _toAddAddress.AddressViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
