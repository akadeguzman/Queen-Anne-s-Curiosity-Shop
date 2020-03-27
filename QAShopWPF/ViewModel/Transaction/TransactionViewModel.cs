using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using QAShopWPF.Annotations;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionViewModel : ObservableObject
    {
        #region Properties

        private int _transactionId;
        private string _invoiceNumber;
        private DateTime _transactionDate;
        private int? _subtotal;
        private int? _tax;
        private int? _total;
        private string _person;
        [CanBeNull] private string _additionalContact;
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

        public int? Subtotal
        {
            get => _subtotal;
            internal set
            {
                _subtotal = value;
                RaisePropertyChanged(nameof(Subtotal));
            }
        }

        public int? Tax
        {
            get => _tax;
            internal set
            {
                _tax = value;
                RaisePropertyChanged(nameof(Tax));
            }
        }

        public int? Total
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

        [CanBeNull]
        public string AdditionalContact
        {
            get => (_additionalContact);
            internal set
            {
                _additionalContact = value;
                RaisePropertyChanged(nameof(AdditionalContact));
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

        public TransactionViewModel(int transactionId, string invoiceNumber, DateTime transactionDate,[CanBeNull] string additionalContact, int? subtotal, int? tax, int? total, string person, string transactionType, int personId, int transactionTypeId)
        {
            TransactionId = transactionId;
            InvoiceNumber = invoiceNumber;
            TransactionDate = transactionDate;
            Subtotal = subtotal;
            Tax = tax;
            Total = total;
            Person = person;
            AdditionalContact = additionalContact;
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
            Tax = transaction.Tax;
            Total = transaction.Total;
            Person = transaction.PersonLink.GetFullName();
            AdditionalContact = transaction.PersonLink.AdditionalContactLink?.GetFullName();
            TransactionType = transaction.TransactionTypeLink.Type;
            PersonId = transaction.PersonId;
            TransactionTypeId = transaction.TransactionTypeId;
        }


        #endregion
    }
}