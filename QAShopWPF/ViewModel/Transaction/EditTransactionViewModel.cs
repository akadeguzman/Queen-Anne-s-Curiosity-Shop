using System;
using System.Collections.ObjectModel;
using System.Linq;
using QAShop_System.EfClasses;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class EditTransactionViewModel
    {
        private TransactionService _transactionService;

        public EditTransactionViewModel(TransactionViewModel transactionViewModel, TransactionService transactionService, PersonService personService, TransactionTypeService transactionTypeService )
        {
            AssociatedTransactionViewModel = transactionViewModel;

            Persons = new ObservableCollection<QAShop_System.EfClasses.Person>(personService.GetPersons());
            SelectedPerson = Persons.First(c => c.PersonId == AssociatedTransactionViewModel.PersonId);

            TransactionTypes = new ObservableCollection<TransactionType>(transactionTypeService.GetTransactionTypes());
            SelectedTransactionType = TransactionTypes.First(c => c.TransactionTypeId == AssociatedTransactionViewModel.TransactionTypeId);
            
            CopyEditTableFields(transactionViewModel);
        }

        private void CopyEditTableFields(TransactionViewModel transactionViewModel)
        {
            InvoiceNumber = transactionViewModel.InvoiceNumber;
            TransactionDate = transactionViewModel.TransactionDate;
            Subtotal = transactionViewModel.Subtotal;
            Tax = transactionViewModel.Tax;
            Total = transactionViewModel.Total;
        }

        public ObservableCollection<QAShop_System.EfClasses.Person> Persons { get; set; }
        public QAShop_System.EfClasses.Person SelectedPerson { get; set; }

        public ObservableCollection<TransactionType> TransactionTypes { get; set; }
        public TransactionType SelectedTransactionType { get; set; }

        public ObservableCollection<QAShop_System.EfClasses.TransactionItem> Items { get; set; }
        public QAShop_System.EfClasses.TransactionItem SelectedTransactionItem { get; set; }

        public int? Subtotal { get; set; }
        public int? Tax { get; set; }
        public int? Total { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionViewModel AssociatedTransactionViewModel { get; set; }

        public void Edit()
        {
            _transactionService.UpdateTransaction(AssociatedTransactionViewModel.TransactionTypeId, InvoiceNumber, TransactionDate, Subtotal, Tax, Total, SelectedPerson.PersonId, SelectedTransactionType.TransactionTypeId);
        }
    }
}