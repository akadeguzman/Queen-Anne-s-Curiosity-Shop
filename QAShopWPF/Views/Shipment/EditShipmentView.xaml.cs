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
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.Views.Shipper;
using ServiceLayer;

namespace QAShopWPF.Views.Shipment
{
    /// <summary>
    /// Interaction logic for EditShipmentView.xaml
    /// </summary>
    public partial class EditShipmentView : Window
    {
        public EditShipmentView()
        {
            InitializeComponent();
        }

        private EditShipmentViewModel _toEditShipment;
        private ShipmentListViewModel _shipmentListViewModel;
        private ShipperService _shipperService;

        public EditShipmentView(ShipmentListViewModel shipmentListViewModel, ShipmentViewModel shipmentViewModel, ShipperService shipperService, ShipmentService shipmentService)
        {
            _toEditShipment = new EditShipmentViewModel(shipmentViewModel, shipperService, shipmentService);
            _shipmentListViewModel = shipmentListViewModel;
            _shipperService = shipperService;

            DataContext = _toEditShipment;
        }

        private void BtnAddShipper_Click(object sender, RoutedEventArgs e)
        {
            var addShipper = new AddShipperView(_shipperService, _toEditShipment);
            addShipper.Show();
        }

        private void BtnSaveChanges_OnClick(object sender, RoutedEventArgs e)
        {
            _toEditShipment.Edit();
            _shipmentListViewModel.Sync();
            Close();
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
