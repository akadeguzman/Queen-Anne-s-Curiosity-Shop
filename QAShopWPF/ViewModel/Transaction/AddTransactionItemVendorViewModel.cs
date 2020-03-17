using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using QAShop_System.EfClasses;
using QAShopWPF.Views.Transaction;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class AddTransactionItemVendorViewModel
    {
        private TransactionItemVendorService _transactionItemVendorService;
        private TransactionService _transactionService;
        private ItemVendorService _itemVendorService;
        //private  _addNewTransactionView;

        public AddTransactionItemVendorViewModel(TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService)
        {
            var blankTransaction = new QAShop_System.EfClasses.Transaction();
            TransactionViewModel = new TransactionViewModel(blankTransaction.TransactionId, blankTransaction.InvoiceNumber, blankTransaction.TransactionDate,
                blankTransaction.Total, "", "", blankTransaction.PersonId, blankTransaction.TransactionTypeId);

            _transactionService = transactionService;
            _transactionTypeService = transactionTypeService;
            _personService = personService;

            Persons = new ObservableCollection<QAShop_System.EfClasses.Person>(_personService.GetPersons());
            SelectedPerson = Persons.First();

            TransactionTypes = new ObservableCollection<TransactionType>(_transactionTypeService.GetTransactionTypes());
            SelectedTransactionType = TransactionTypes.First();



        }

        public TransactionViewModel TransactionViewModel { get; }

        public ObservableCollection<QAShop_System.EfClasses.Person> Persons { get; }
        public ObservableCollection<TransactionType> TransactionTypes { get; }

        public QAShop_System.EfClasses.Person SelectedPerson { get; set; }
        public TransactionType SelectedTransactionType { get; set; }

        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Total { get; set; }

        public ICommand AddItem => new RelayCommand(Add);
        public ICommand CloseCommand => new RelayCommand(Close);

        public void Close()
        {
            _addNewTransactionView.Close();
        }
        public void Add()
        {
            var transactionToAdd = new QAShop_System.EfClasses.Transaction();
            transactionToAdd.InvoiceNumber = InvoiceNumber;
            transactionToAdd.TransactionDate = TransactionDate;
            transactionToAdd.Total = Total;
            transactionToAdd.PersonId = SelectedPerson.PersonId;
            transactionToAdd.TransactionTypeId = SelectedTransactionType.TransactionTypeId;

            _transactionService.AddTransaction(transactionToAdd);

            TransactionViewModel.TransactionId = transactionToAdd.TransactionId;
            TransactionViewModel.InvoiceNumber = transactionToAdd.InvoiceNumber;
            TransactionViewModel.TransactionDate = transactionToAdd.TransactionDate;
            TransactionViewModel.Total = transactionToAdd.Total;
            TransactionViewModel.PersonId = transactionToAdd.PersonId;
            TransactionViewModel.TransactionTypeId = transactionToAdd.TransactionTypeId;


        }
    }
}