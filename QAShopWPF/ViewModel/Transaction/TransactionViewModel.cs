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
        private int _total;
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

        public int Total
        {
            get => _total;
            internal set
            {
                _total = value;
                RaisePropertyChanged(nameof(Total));
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

        public TransactionViewModel(int transactionId, string invoiceNumber, DateTime transactionDate, int total, string person, string transactionType, int personId, int transactionTypeId)
        {
            TransactionId = transactionId;
            InvoiceNumber = invoiceNumber;
            TransactionDate = transactionDate;
            Total = total;
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
            Total = transaction.Total;
            Person = transaction.PersonLink.GetFullName();
            TransactionType = transaction.TransactionTypeLink.Type;
            PersonId = transaction.PersonId;
            TransactionTypeId = transaction.TransactionTypeId;
        }


        #endregion
    }
}