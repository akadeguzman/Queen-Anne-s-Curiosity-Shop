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
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Shipper;
using QAShopWPF.Views.Shipper;
using ServiceLayer;

namespace QAShopWPF.Views.Shipment
{
    /// <summary>
    /// Interaction logic for AddShipmentView.xaml
    /// </summary>
    public partial class AddShipmentView : Window
    {
        private AddShipmentViewModel _shipmentToAdd;
        private ShipmentListViewModel _shipmentListViewModel;
        private ShipmentService _shipmentService;
        private ShipperService _shipperService;
        private ShipperListViewModel _shipperListViewModel;

        public AddShipmentView(ShipmentListViewModel shipmentListViewModel, ShipmentService shipmentService, ShipperService shipperService)
        {
            InitializeComponent();

            _shipmentService = shipmentService;
            _shipperService = shipperService;
            _shipmentListViewModel = shipmentListViewModel;
            _shipperListViewModel = new ShipperListViewModel(_shipperService);

            _shipmentToAdd = new AddShipmentViewModel(shipperService, shipmentService);
            DataContext = _shipmentToAdd;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _shipmentToAdd.Add();
            _shipmentListViewModel.ShipmentList.Insert(0, _shipmentToAdd.ShipmentViewModel);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddShipper_Click(object sender, RoutedEventArgs e)
        {
            var addShipperWindow = new AddShipperView(_shipperService, _shipmentToAdd, _shipperListViewModel);
            addShipperWindow.Show();
        }
    }
}
