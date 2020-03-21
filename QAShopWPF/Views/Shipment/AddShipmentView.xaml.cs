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
using QAShopWPF.Views.Shipper;

namespace QAShopWPF.Views.Shipment
{
    /// <summary>
    /// Interaction logic for AddShipmentView.xaml
    /// </summary>
    public partial class AddShipmentView : Window
    {

        public AddShipmentView()
        {
            InitializeComponent();

            DataContext = QAShopService.AddShipmentViewModel;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            QAShopService.AddShipmentViewModel.Add();
            QAShopService.ShipmentListViewModel.ShipmentList.Insert(0, QAShopService.AddShipmentViewModel.ShipmentViewModel);
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnAddShipper_Click(object sender, RoutedEventArgs e)
        {
            var addShipperWindow = new AddShipperView();
            addShipperWindow.Show();
        }
    }
}
