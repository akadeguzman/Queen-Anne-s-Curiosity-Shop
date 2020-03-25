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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QAShopWPF.ViewModel.Shipment;
using ServiceLayer;

namespace QAShopWPF.Views.Shipment
{
    /// <summary>
    /// Interaction logic for ShipmentView.xaml
    /// </summary>
    public partial class ShipmentView : UserControl
    {
        private ShipmentService _shipmentService;
        private ShipmentListViewModel _shipmentListViewModel;
        private ShipperService _shipperService;

        public ShipmentView(ShipperService shipperService, ShipmentService shipmentService)
        {
            InitializeComponent();

            _shipmentService = shipmentService;
            _shipperService = shipperService;
            _shipmentListViewModel = new ShipmentListViewModel(shipmentService);

            DataContext = _shipmentListViewModel;
        }

        private void BtnAddShipment_Click(object sender, RoutedEventArgs e)
        {
            var addShipment = new AddShipmentView(_shipmentListViewModel, _shipmentService, _shipperService);
            addShipment.Show();
        }


        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGrid.SelectedItem == null)
            {
                BtnEditShipment.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnEditShipment.Visibility = Visibility.Visible;
            }
        }

        private void BtnEditShipment_OnClick(object sender, RoutedEventArgs e)
        {
            var editShipment = new EditShipmentView(_shipmentListViewModel, _shipmentListViewModel.SelectedShipment, _shipperService, _shipmentService);
            editShipment.Show();
        }
    }
}
