using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Procurement;
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Transaction;
using QAShopWPF.ViewModel.Vendor;
using QAShopWPF.Views.Item;
using QAShopWPF.Views.Person;
using QAShopWPF.Views.Procurement;
using QAShopWPF.Views.Shipment;
using QAShopWPF.Views.Transaction;
using QAShopWPF.Views.Vendor;
using ServiceLayer;

namespace QAShopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ImgLogo.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ImgLogo.Visibility = Visibility.Collapsed;
           
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UserControl transaction = new TransactionView(QAShopService.TransactionListViewModel, QAShopService.TransactionService, QAShopService.PersonService, QAShopService.TransactionTypeService);
            UserControl person = new PersonView();
            UserControl item = new ItemView(QAShopService.ItemListViewModel, QAShopService.ItemTypeService, QAShopService.ItemAvailabilityService, QAShopService.ItemService);
            UserControl procurement = new ProcurementView(QAShopService.ProcurementListViewModel, QAShopService.ShipmentItemVendorService, QAShopService.PersonService, QAShopService.PurchasingAgentService, QAShopService.ProcurementService);
            UserControl shipment = new ShipmentView(QAShopService.ShipmentListViewModel, QAShopService.ShipperService, QAShopService.ShipmentService);
            UserControl vendor = new VendorView();

            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Transaction":
                    GridMain.Children.Add(transaction);
                    break;
                case "Person":
                    GridMain.Children.Add(person);
                    break;
                case "Item":
                    GridMain.Children.Add(item);
                    break;
                case "Procurement":
                    GridMain.Children.Add(procurement);
                    break;
                case "Shipment":
                    GridMain.Children.Add(shipment);
                    break;
                case "Vendor":
                    GridMain.Children.Add(vendor);
                    break;

                default:
                    break;
            }
        }
    }
}
