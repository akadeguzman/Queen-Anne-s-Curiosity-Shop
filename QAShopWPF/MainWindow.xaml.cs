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
        private AddressService _addressService;
        
        private TransactionService _transactionService;
        private TransactionItemVendorService _transacItemVendorService;
        private TransactionTypeService _transactionTypeService;

        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private PurchasingAgentService _purchasingAgentService;

        private ItemService _itemService;
        private ItemTypeService _itemTypeService;
        private ItemAvailabilityService _itemAvailabilityService;

        private ProcurementService _procurementService;

        private ShipmentService _shipmentService;
        private ShipmentItemVendorService _shipmentItemVendorService;
        private ShipperService _shipperService;

        private VendorService _vendorService;

        //====================================================================

        private AddressListViewModel _addressListViewModel;
        private AddNewAddressViewModel _addNewAddressViewModel;

        private TransactionListViewModel _transactionListViewModel;
        private AddTransactionViewModel _addTransactionViewModel;

        private PersonListViewModel _personListViewModel;
        private AddPersonViewModel _addPersonViewModel;

        private ItemListViewModel _itemListViewModel;
        private AddItemViewModel _addItemViewModel;

        private ProcurementListViewModel _procurementListViewModel;
        private ShipmentListViewModel _shipmentListViewModel;

        private VendorListViewModel _vendorListViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _addressService = new AddressService(new QueenAnneCuriosityShopContext());

            _transactionService = new TransactionService(new QueenAnneCuriosityShopContext());
            _transacItemVendorService = new TransactionItemVendorService(new QueenAnneCuriosityShopContext());
            _transactionTypeService = new TransactionTypeService(new QueenAnneCuriosityShopContext());

            _personService = new PersonService(new QueenAnneCuriosityShopContext());
            _personTypeService = new PersonTypeService(new QueenAnneCuriosityShopContext());
            _purchasingAgentService = new PurchasingAgentService(new QueenAnneCuriosityShopContext());

            _itemService = new ItemService(new QueenAnneCuriosityShopContext());
            _itemTypeService = new ItemTypeService(new QueenAnneCuriosityShopContext());
            _itemAvailabilityService = new ItemAvailabilityService(new QueenAnneCuriosityShopContext());


            _procurementService = new ProcurementService(new QueenAnneCuriosityShopContext());

            _shipmentService = new ShipmentService(new QueenAnneCuriosityShopContext());
            _shipmentItemVendorService = new ShipmentItemVendorService(new QueenAnneCuriosityShopContext());
            _shipperService = new ShipperService(new QueenAnneCuriosityShopContext());

            _vendorService = new VendorService(new QueenAnneCuriosityShopContext());
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

            UserControl transaction = new TransactionView(_transactionListViewModel, _transactionService, _personService, _transactionTypeService);
            UserControl person = new PersonView(_personListViewModel, _personTypeService, _addressService, _personService, _addressListViewModel);
            UserControl item = new ItemView(_itemListViewModel, _itemTypeService, _itemAvailabilityService, _itemService);
            UserControl procurement = new ProcurementView(_procurementListViewModel, _shipmentItemVendorService, _personService, _purchasingAgentService, _procurementService);
            UserControl shipment = new ShipmentView(_shipmentListViewModel, _shipperService, _shipmentService);
            UserControl vendor = new VendorView(_vendorListViewModel, _vendorService);

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
