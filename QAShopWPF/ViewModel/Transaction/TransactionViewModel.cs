using System;
using GalaSoft.MvvmLight;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionViewModel : ObservableObject
    {
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
    }
}