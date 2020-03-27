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
    public class AddTransactionViewModel
    {
        private readonly TransactionListViewModel _transactionListViewModel;
        private TransactionService _transactionService;

        public AddTransactionViewModel(TransactionService transactionService, TransactionTypeService transactionTypeService, PersonService personService)
        {
            var blankTransaction = new QAShop_System.EfClasses.Transaction();
            TransactionViewModel = new TransactionViewModel(blankTransaction.TransactionId, blankTransaction.InvoiceNumber, blankTransaction.TransactionDate,
                "",blankTransaction.Subtotal, blankTransaction.Tax, blankTransaction.Total, "", "", blankTransaction.PersonId, blankTransaction.TransactionTypeId);
            
            _transactionService = transactionService;

            Persons = new ObservableCollection<QAShop_System.EfClasses.Person>(personService.GetPersons());
            
            TransactionTypes = new ObservableCollection<TransactionType>(transactionTypeService.GetTransactionTypes());

        }

        public TransactionViewModel TransactionViewModel { get; }

        public ObservableCollection<QAShop_System.EfClasses.Person> Persons { get; }
        public ObservableCollection<TransactionType> TransactionTypes { get; }

        public QAShop_System.EfClasses.Person SelectedPerson { get; set; }
        public TransactionType SelectedTransactionType { get; set; }

        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public int? Subtotal { get; set; }
        public int? Tax { get; set; }
        public int? Total { get; set; }

        public void Add()
        {
            var transactionToAdd = new QAShop_System.EfClasses.Transaction();
            transactionToAdd.InvoiceNumber = InvoiceNumber;
            transactionToAdd.TransactionDate = TransactionDate;
            transactionToAdd.Subtotal = Subtotal;
            transactionToAdd.Tax = Tax;
            transactionToAdd.Total = Total;
            transactionToAdd.PersonId = SelectedPerson.PersonId;
            transactionToAdd.TransactionTypeId = SelectedTransactionType.TransactionTypeId;

            _transactionService.AddTransaction(transactionToAdd);

            TransactionViewModel.TransactionId = transactionToAdd.TransactionId;
            TransactionViewModel.InvoiceNumber = transactionToAdd.InvoiceNumber;
            TransactionViewModel.TransactionDate = transactionToAdd.TransactionDate;
            TransactionViewModel.Subtotal = transactionToAdd.Subtotal;
            TransactionViewModel.Tax = transactionToAdd.Tax;
            TransactionViewModel.Total = transactionToAdd.Total;

            TransactionViewModel.PersonId = transactionToAdd.PersonId;
            TransactionViewModel.Person = transactionToAdd.PersonLink.GetFullName();

            TransactionViewModel.TransactionTypeId = transactionToAdd.TransactionTypeId;
            TransactionViewModel.TransactionType = transactionToAdd.TransactionTypeLink.Type;


        }

    }
}
