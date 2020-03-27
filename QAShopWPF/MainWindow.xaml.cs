using System;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using QAShop_System.EfClasses;
using QAShopWPF.Annotations;
using QAShopWPF.ViewModel;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Procurement;
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Shipper;
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
        private TransactionItemService _transactionItemVendorService;
        private TransactionTypeService _transactionTypeService;
        private PersonService _personService;
        private PersonTypeService _personTypeService;
        private PurchasingAgentService _purchasingAgentService;
        private ItemService _itemService;
        private ItemTypeService _itemTypeService;
        private ItemVendorService _itemVendorService;
        private ItemAvailabilityService _itemAvailabilityService;
        private ProcurementService _procurementService;
        private ShipmentService _shipmentService;
        private ShipmentItemVendorService _shipmentItemVendorService;
        private ShipperService _shipperService;
        private VendorService _vendorService;

        public MainWindow()
        {
            InitializeComponent();
            // context to be shared
            var context = new QueenAnneCuriosityShopContext();

            //Services
            _addressService = new AddressService(context);
            _transactionService = new TransactionService(context);
            _transactionItemVendorService = new TransactionItemService(context);
            _transactionTypeService = new TransactionTypeService(context);
            _personService = new PersonService(context);
            _personTypeService = new PersonTypeService(context);
            _purchasingAgentService = new PurchasingAgentService(context);
            _itemService = new ItemService(context);
            _itemVendorService = new ItemVendorService(context);
            _itemTypeService = new ItemTypeService(context);
            _itemAvailabilityService = new ItemAvailabilityService(context);
            _procurementService = new ProcurementService(context);
            _shipmentService = new ShipmentService(context);
            _shipmentItemVendorService = new ShipmentItemVendorService(context);
            _shipperService = new ShipperService(context);
            _vendorService = new VendorService(context);

            

            //ViewModels
            _addressListViewModel = new AddressListViewModel(_addressService);
            _addNewAddressViewModel = new AddNewAddressViewModel(_addressService);

            _transactionListViewModel = new TransactionListViewModel(_transactionService);
            _addTransactionViewModel = new AddTransactionViewModel(_transactionService, _transactionTypeService, _personService);

            _personListViewModel = new PersonListViewModel(_personService);
            _addPersonViewModel = new AddPersonViewModel(_personTypeService, _addressService, _personService);

            _itemListViewModel = new ItemListViewModel(_itemService);
            _addItemViewModel = new AddItemViewModel(_itemService, _itemAvailabilityService, _itemTypeService);

            _procurementListViewModel = new ProcurementListViewModel(_procurementService);

            _shipmentListViewModel = new ShipmentListViewModel(_shipmentService);
            _shipperListViewModel = new ShipperListViewModel(_shipperService);
            _addShipmentViewModel = new AddShipmentViewModel(_shipperService, _shipmentService);

            _addShipperViewModel = new AddShipperViewModel(_shipperService);

            _vendorListViewModel = new VendorListViewModel(_vendorService);
            _addVendorViewModel = new AddVendorViewModel(_vendorService);
        }

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
        private AddShipmentViewModel _addShipmentViewModel;

        private AddShipperViewModel _addShipperViewModel;
        private ShipperListViewModel _shipperListViewModel;

        private VendorListViewModel _vendorListViewModel;
        private VendorViewModel _vendorViewModel;
        private AddVendorViewModel _addVendorViewModel;
       

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
            UserControl transaction = new TransactionView(_transactionService, _transactionTypeService, _personService, _itemVendorService, _transactionItemVendorService);
            UserControl person = new PersonView(_personService, _personTypeService, _addressService);
            UserControl item = new ItemView(_itemListViewModel, _itemTypeService, _itemAvailabilityService, _itemService);
            UserControl procurement = new ProcurementView(_procurementListViewModel, _shipmentItemVendorService, _personService, _purchasingAgentService, _procurementService);
            UserControl itemVendor = new ItemVendorView(_itemVendorService, _vendorService, _itemService);
            UserControl shipment = new ShipmentView(_shipperService, _shipmentService);
            UserControl vendor = new VendorView(_vendorService);

            GridMain.Children.Clear();
            ImageBackground.Visibility = Visibility.Hidden;
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
                case "PurchasedItems":
                    GridMain.Children.Add(itemVendor);
                    break;

                default:
                    break;
            }
        }
    }



       
}
