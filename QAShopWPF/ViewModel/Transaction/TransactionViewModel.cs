using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionViewModel : ObservableObject
    {
        #region Properties

        private int _transactionId;
        private string _invoiceNumber;
        private DateTime _transactionDate;
        private int _subtotal;
        private int _total;
        private int _tax;
        private string _person;
        private string _transactionType;

        public int TransactionId
        {
            get => _transactionId;
            internal set
            {
                _transactionId = value;
                RaisePropertyChanged(nameof(TransactionId));
            }
        }

        public string InvoiceNumber
        {
            get => _invoiceNumber;
            internal set
            {
                _invoiceNumber = value;
                RaisePropertyChanged(nameof(InvoiceNumber));
            }
        }

        public DateTime TransactionDate
        {
            get => _transactionDate;
            internal set
            {
                _transactionDate = value;
                RaisePropertyChanged(nameof(TransactionDate));
            }
        }

        public int Subtotal
        {
            get => (_subtotal);
            internal set
            {
                _subtotal = value;
                RaisePropertyChanged(nameof(Subtotal));
            }
        }

        public int Total
        {
            get => (_total);
            internal set
            {
                _total = value;
                RaisePropertyChanged(nameof(Total));
            }
        }

        public int Tax
        {
            get => (_tax);
            internal set
            {
                _tax = value;
                RaisePropertyChanged(nameof(Tax));
            }
        }

        public string Person
        {
            get => (_person);
            internal set
            {
                _person = value;
                RaisePropertyChanged(nameof(Person));
            }
        }

        public string TransactionType
        {
            get => (_transactionType);
            internal set
            {
                _transactionType = value;
                RaisePropertyChanged(nameof(TransactionType));
            }
        }

        public int PersonId { get; set; }
        public int TransactionTypeId { get; set; }

        public TransactionViewModel(int transactionId, string invoiceNumber, DateTime transactionDate, int subtotal, int total, int tax, string person, string transactionType, int personId, int transactionTypeId)
        {
            TransactionId = transactionId;
            InvoiceNumber = invoiceNumber;
            TransactionDate = transactionDate;
            Subtotal = subtotal;
            Total = total;
            Tax = tax;
            Person = person;
            TransactionType = transactionType;
            PersonId = personId;
            TransactionTypeId = transactionTypeId;
        }

        public TransactionViewModel(QAShop_System.EfClasses.Transaction transaction)
        {
            TransactionId = transaction.TransactionId;
            InvoiceNumber = transaction.InvoiceNumber;
            TransactionDate = transaction.TransactionDate;
            Subtotal = transaction.Subtotal;
            Total = transaction.Total;
            Tax = transaction.Tax;
            Person = transaction.PersonLink.GetFullName();
            TransactionType = transaction.TransactionTypeLink.Type;
            PersonId = transaction.PersonId;
            TransactionTypeId = transaction.TransactionTypeId;
        }

        #endregion


        private TransactionService _transactionService;
        private TransactionViewModel _selectedTransaction;
        private string _searchText;
        private int _transactionCount;

        public TransactionViewModel()
        {
            GenerateTransactions();
        }

        public void GenerateTransactions()
        {
            var person = _transactionService.GetTransactions()
                .Select(c =>
                    new TransactionViewModel(c)).ToList();

            TransactionList = new ObservableCollection<TransactionViewModel>(person);
            TransactionCount = TransactionList.Count;
        }


        public ObservableCollection<TransactionViewModel> TransactionList { get; set; } = new ObservableCollection<TransactionViewModel>();

        public int TransactionCount
        {
            get => _transactionCount;
            set
            {
                _transactionCount = value;
                _ = TransactionList.Count;
            }
        }

        public TransactionViewModel SelectedTransaction { get; set; }

        public void SearchTransaction(string searchString)
        {
            TransactionList.Clear();

            var transactions = _transactionService.GetTransactions().Where(c => c.TransactionId.ToString().Contains(searchString) ||
                                                                      c.InvoiceNumber.Contains(searchString) ||
                                                                      c.TransactionDate.Date.Day.ToString().Contains(searchString) ||
                                                                      c.TransactionDate.Date.Month.ToString().Contains(searchString) ||
                                                                      c.PersonLink.GetFullName().Contains(searchString) ||
                                                                      c.TransactionTypeLink.Type.Contains(searchString));

            foreach (var transaction in transactions)
            {
                var transactionModel = new TransactionViewModel(transaction.TransactionId, transaction.InvoiceNumber, transaction.TransactionDate,
                    transaction.Subtotal, transaction.Total, transaction.Tax, transaction.PersonLink.GetFullName(), transaction.TransactionTypeLink.Type,
                    transaction.PersonId, transaction.TransactionTypeId);
                TransactionList.Add(transactionModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchTransaction(_searchText);
            }
        }
    }
}