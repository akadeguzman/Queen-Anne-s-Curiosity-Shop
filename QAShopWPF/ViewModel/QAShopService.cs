using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Procurement;
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Transaction;
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.ViewModel
{
    public static class QAShopService 
    {
        //Services
        public static AddressService AddressService = new AddressService(new QueenAnneCuriosityShopContext());
        public static TransactionService TransactionService = new TransactionService(new QueenAnneCuriosityShopContext());

        public static TransactionItemVendorService TransacItemVendorService = new TransactionItemVendorService(new QueenAnneCuriosityShopContext());
        public static TransactionTypeService TransactionTypeService = new TransactionTypeService(new QueenAnneCuriosityShopContext());

        public static PersonService PersonService = new PersonService(new QueenAnneCuriosityShopContext());
        public static PersonTypeService PersonTypeService = new PersonTypeService(new QueenAnneCuriosityShopContext());
        public static PurchasingAgentService PurchasingAgentService = new PurchasingAgentService(new QueenAnneCuriosityShopContext());

        public static ItemService ItemService = new ItemService(new QueenAnneCuriosityShopContext());
        public static ItemTypeService ItemTypeService = new ItemTypeService(new QueenAnneCuriosityShopContext());
        public static ItemAvailabilityService ItemAvailabilityService = new ItemAvailabilityService(new QueenAnneCuriosityShopContext());

        public static ProcurementService ProcurementService = new ProcurementService(new QueenAnneCuriosityShopContext());

        public static ShipmentService ShipmentService = new ShipmentService(new QueenAnneCuriosityShopContext());
        public static ShipmentItemVendorService ShipmentItemVendorService = new ShipmentItemVendorService(new QueenAnneCuriosityShopContext());
        public static ShipperService ShipperService = new ShipperService(new QueenAnneCuriosityShopContext());

        public static VendorService VendorService = new VendorService(new QueenAnneCuriosityShopContext());


        //View Models
        public static AddressListViewModel AddressListViewModel = new AddressListViewModel(AddressService);
        public static AddNewAddressViewModel AddNewAddressViewModel = new AddNewAddressViewModel(AddressService);

        public static TransactionListViewModel TransactionListViewModel = new TransactionListViewModel(TransactionService);
        public static AddTransactionViewModel AddTransactionViewModel = new AddTransactionViewModel(TransactionService, TransactionTypeService, PersonService);

        public static PersonListViewModel PersonListViewModel = new PersonListViewModel(PersonService);
        public static AddPersonViewModel AddPersonViewModel = new AddPersonViewModel(PersonService, PersonTypeService, AddressService);

        public static ItemListViewModel ItemListViewModel = new ItemListViewModel(ItemService);
        public static AddItemViewModel AddItemViewModel = new AddItemViewModel(ItemService, ItemAvailabilityService, ItemTypeService);

        public static ProcurementListViewModel ProcurementListViewModel = new ProcurementListViewModel(ProcurementService);
        public static ShipmentListViewModel ShipmentListViewModel = new ShipmentListViewModel(ShipmentService);

        public static VendorListViewModel VendorListViewModel = new VendorListViewModel(VendorService);
        public static AddVendorViewModel AddVendorViewModel = new AddVendorViewModel(VendorService);
    }
}