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

namespace QAShopWPF.Views.Shipper
{
    /// <summary>
    /// Interaction logic for AddShipperView.xaml
    /// </summary>
    public partial class AddShipperView : Window
    {
        public AddShipperView()
        {
            InitializeComponent();

            DataContext = QAShopService.AddShipperViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            QAShopService.AddShipperViewModel.Add();
            QAShopService.ShipperViewModel.ShipperList.Insert(0, QAShopService.AddShipperViewModel.ShipperViewModel);

            var shipperToAdd = QAShopService.ShipperService.GetShippers().ToList().Last();
            QAShopService.AddShipmentViewModel.Shippers.Add(shipperToAdd);
            Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
