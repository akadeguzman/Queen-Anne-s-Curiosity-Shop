using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using QAShop_System.EfClasses;
using QAShopWPF.Annotations;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class EditTransactionViewModel : INotifyPropertyChanged
    {
        private TransactionService _transactionService;

        public EditTransactionViewModel(TransactionViewModel transactionViewModel, TransactionService transactionService, PersonService personService, TransactionTypeService transactionTypeService )
        {
            AssociatedTransactionViewModel = transactionViewModel;

            _transactionService = transactionService;
            Persons = new ObservableCollection<QAShop_System.EfClasses.Person>(personService.GetPersons());
            SelectedPerson = Persons.First(c => c.PersonId == AssociatedTransactionViewModel.PersonId);

            TransactionTypes = new ObservableCollection<TransactionType>(transactionTypeService.GetTransactionTypes());
            SelectedTransactionType = TransactionTypes.First(c => c.TransactionTypeId == AssociatedTransactionViewModel.TransactionTypeId);

            Tax = 12;
            Items = new ObservableCollection<TransactionItemViewModel>();
            Items.CollectionChanged += Item_CollectionChanged;

            CopyEditTableFields(transactionViewModel);
        }

        private void Item_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                Subtotal = GetSubtotal();
                GetTotal();
            }

            if (e.OldItems != null)
            {
                Subtotal = GetSubtotal();
                GetTotal();
            }
        }

        private void CopyEditTableFields(TransactionViewModel transactionViewModel)
        {
            Person = transactionViewModel.Person;
            AdditionalContact = transactionViewModel.AdditionalContact;
            Type = transactionViewModel.TransactionType;
            InvoiceNumber = transactionViewModel.InvoiceNumber;
            TransactionDate = transactionViewModel.TransactionDate;
            Tax = 12;
        }

        public ObservableCollection<QAShop_System.EfClasses.Person> Persons { get; set; }
        public QAShop_System.EfClasses.Person SelectedPerson { get; set; }

        public ObservableCollection<TransactionType> TransactionTypes { get; set; }
        public TransactionType SelectedTransactionType { get; set; }

        public ObservableCollection<TransactionItemViewModel> Items { get; set; }
        public TransactionItemViewModel SelectedTransactionItem { get; set; }

        public string Person { get; set; }
        [CanBeNull] public string AdditionalContact { get; set; }
        public string Type { get; set; }

        private int _subtotal;
        public int Subtotal
        {
            get => _subtotal;
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }

        }

        public int Tax { get; set; }

        private int _total;
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }


        }
        public string InvoiceNumber { get; set; }
        public DateTime TransactionDate { get; set; }

        public TransactionViewModel AssociatedTransactionViewModel { get; set; }
        public TransactionViewModel TransactionToBeAdded { get; set; }

        public int GetSubtotal()
        {
            var subtotal = 0;
            foreach (var item in Items)
            {
                subtotal += ((item.Price)*item.Quantity);
            }

            return subtotal;
        }

        public void GetTotal()
        {
            var tax = decimal.Divide(Convert.ToDecimal(Tax), 100);

            var total = Subtotal * tax;

            Total = Convert.ToInt32(total) + Subtotal;
        }

       public void Edit()
       {
            _transactionService.UpdateTransaction(AssociatedTransactionViewModel.TransactionId, InvoiceNumber, TransactionDate, Subtotal, Tax, Total, SelectedPerson.PersonId, SelectedTransactionType.TransactionTypeId);
       }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}