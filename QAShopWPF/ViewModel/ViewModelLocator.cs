using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Address;
using QAShopWPF.ViewModel.Item;
using QAShopWPF.ViewModel.Person;
using QAShopWPF.ViewModel.Procurement;
using QAShopWPF.ViewModel.Shipment;
using QAShopWPF.ViewModel.Shipper;
using QAShopWPF.ViewModel.Transaction;
using QAShopWPF.ViewModel.Vendor;
using ServiceLayer;

namespace QAShopWPF.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            var addressService = new AddressService(new QueenAnneCuriosityShopContext());

            var transactionService = new TransactionService(new QueenAnneCuriosityShopContext());
            var transacItemVendorService = new TransactionItemVendorService(new QueenAnneCuriosityShopContext());
            var transactionTypeService = new TransactionTypeService(new QueenAnneCuriosityShopContext());

            var personService = new PersonService(new QueenAnneCuriosityShopContext());
            var personTypeService = new PersonTypeService(new QueenAnneCuriosityShopContext());

            var itemService = new ItemService(new QueenAnneCuriosityShopContext());
            var itemTypeService = new ItemTypeService(new QueenAnneCuriosityShopContext());
            var itemAvailabilityService = new ItemAvailabilityService(new QueenAnneCuriosityShopContext());

            var procurementService = new ProcurementService(new QueenAnneCuriosityShopContext());
            var shipmentService = new ShipmentService(new QueenAnneCuriosityShopContext());

            TransactionListViewModel = new TransactionListViewModel(transactionService);
            AddTransactionViewModel = new AddTransactionViewModel(transactionService, transactionTypeService, personService);

            PersonListViewModel = new PersonListViewModel(personService);
            AddPersonViewModel = new AddPersonViewModel(personService, personTypeService, addressService);

            AddressListViewModel = new AddressListViewModel(addressService);

            ItemListViewModel = new ItemListViewModel(itemService);
            AddItemViewModel = new AddItemViewModel(itemService, itemAvailabilityService, itemTypeService);

            ProcurementListViewModel = new ProcurementListViewModel(procurementService);
            ShipmentListViewModel = new ShipmentListViewModel(shipmentService);



        }

        public AddressListViewModel AddressListViewModel { get; set; }

        public TransactionListViewModel TransactionListViewModel { get; set; }
        public AddTransactionViewModel AddTransactionViewModel { get; set; }

        public PersonListViewModel PersonListViewModel { get; set; }
        public AddPersonViewModel AddPersonViewModel { get; set; }

        public ItemListViewModel ItemListViewModel { get; set; }
        public AddItemViewModel AddItemViewModel { get; set; }

        public ProcurementListViewModel ProcurementListViewModel { get; set; }
        public ShipmentListViewModel ShipmentListViewModel { get; set; }

    }
}
