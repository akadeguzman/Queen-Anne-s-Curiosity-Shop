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

namespace QAShopWPF.Views.Shipment
{
    /// <summary>
    /// Interaction logic for AddShipmentView.xaml
    /// </summary>
    public partial class AddShipmentView : Window
    {
        private AddShipmentViewModel _shipmentToAdd;

        public AddShipmentView()
        {
            InitializeComponent();

            _shipmentToAdd = new AddShipmentViewModel();

            DataContext = _shipmentToAdd;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _shipmentToAdd.Add();
            QAShopService.ShipmentListViewModel.ShipmentList.Insert(0, _shipmentToAdd.ShipmentViewModel);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
