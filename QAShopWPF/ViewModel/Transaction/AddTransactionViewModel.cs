using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using QAShop_System.EfClasses;
using QAShopWPF.Views.Transaction;
using ServiceLayer;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;

namespace QAShopWPF.ViewModel.Transaction
{
    public class AddTransactionViewModel : INotifyPropertyChanged
    {
        private readonly TransactionListViewModel _transactionListViewModel;
        private TransactionService _transactionService;

        public AddTransactionViewModel(TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService)
        {
            var blankTransaction = new QAShop_System.EfClasses.Transaction();
            TransactionViewModel = new TransactionViewModel(blankTransaction.TransactionId, blankTransaction.InvoiceNumber, blankTransaction.TransactionDate,
                blankTransaction.Total, "","", blankTransaction.PersonId, blankTransaction.TransactionTypeId);
            
            _transactionService = transactionService;

            Persons = new ObservableCollection<QAShop_System.EfClasses.Person>(personService.GetPersons());
            SelectedPerson = Persons.First();

            TransactionTypes = new ObservableCollection<TransactionType>(transactionTypeService.GetTransactionTypes());

            TransactionItemVendors = new ObservableCollection<TransactionItemVendorViewModel>();
        }

        public TransactionViewModel TransactionViewModel { get; }

        public ObservableCollection<QAShop_System.EfClasses.Person> Persons { get; }
        public ObservableCollection<TransactionType> TransactionTypes { get; }
        public ObservableCollection<TransactionItemVendorViewModel> TransactionItemVendors { get; }

        public QAShop_System.EfClasses.Person SelectedPerson { get; set; }

        public TransactionType SelectedTransactionType { get; set; }

        private string _invoiceNumber;
        public string InvoiceNumber
        {
            get => _invoiceNumber;
            set
            {
                _invoiceNumber = value;
                OnPropertyChanged(nameof(InvoiceNumber));
            }

        }
        public DateTime TransactionDate { get; set; }

        private int _total;
        public int Total
        {
            get
            {
                foreach (var transactionItemVendor in TransactionItemVendors)
                {
                    _total += transactionItemVendor.Total;
                }

                return _total;
            }
            set
            {
                _total = value; 
                OnPropertyChanged(nameof(Total));
            }
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
            TransactionViewModel.Person = transactionToAdd.PersonLink.GetFullName();

            TransactionViewModel.TransactionTypeId = transactionToAdd.TransactionTypeId;
            TransactionViewModel.TransactionType = transactionToAdd.TransactionTypeLink.Type;


        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
