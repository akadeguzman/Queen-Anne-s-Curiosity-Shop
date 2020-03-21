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
        private ShipperListViewModel _shipperListViewModel;

        public AddShipperView(ShipperService shipperService, AddShipmentViewModel addShipmentViewModel, ShipperListViewModel shipperListViewModel)
        {
            _shipperService = shipperService;
            _addShipmentViewModel = addShipmentViewModel;
            _shipperListViewModel = shipperListViewModel;

            InitializeComponent();

            _shipperToAdd = new AddShipperViewModel(shipperService);
            DataContext = _shipperToAdd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _shipperToAdd.Add();
           _shipperListViewModel.ShipperList.Insert(0, _shipperToAdd.ShipperViewModel);

            var shipperToAdd = _shipperService.GetShippers().ToList().Last();
            _addShipmentViewModel.Shippers.Add(shipperToAdd);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
