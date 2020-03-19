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

        public ShipmentView(ShipmentListViewModel shipmentListViewModel, ShipperService shipperService, ShipmentService shipmentService)
        {
            InitializeComponent();

            _shipmentService = shipmentService;
            _shipperService = shipperService;
            _shipmentListViewModel = new ShipmentListViewModel(shipmentService);

            DataContext = _shipmentListViewModel;
        }
    }
}
