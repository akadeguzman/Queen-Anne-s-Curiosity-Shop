using System;
using System.Collections.Generic;
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
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Shipper;
using ServiceLayer;

namespace QAShopWPF.Views.Shipper
{
    /// <summary>
    /// Interaction logic for AddShipperView.xaml
    /// </summary>
    public partial class AddShipperView : Window
    {
        private AddShipperViewModel _shipperToAdd;
        private ShipperService _shipperService;
        private AddShipmentViewModel _addShipmentViewModel;
        private EditShipmentViewModel _editShipmentViewModel;

        public AddShipperView(ShipperService shipperService, AddShipmentViewModel addShipmentViewModel)
        {
            InitializeComponent();

            _shipperService = shipperService;
            _addShipmentViewModel = addShipmentViewModel;

            _shipperToAdd = new AddShipperViewModel(shipperService);
            DataContext = _shipperToAdd;
        }

        public AddShipperView(ShipperService shipperService, EditShipmentViewModel editShipmentViewModel)
        {
            InitializeComponent();

            _shipperService = shipperService;
            _editShipmentViewModel = editShipmentViewModel;

            _shipperToAdd = new AddShipperViewModel(shipperService);
            DataContext = _shipperToAdd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _shipperToAdd.Add();
            if (_addShipmentViewModel == null)
            {
                var shipperToEdit = _shipperService.GetShippers().ToList().Last();
                _editShipmentViewModel.Shippers.Add(shipperToEdit);
            }
            else
            {
                var shipperToAdd = _shipperService.GetShippers().ToList().Last();
                _addShipmentViewModel.Shippers.Add(shipperToAdd);
            }
            
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
