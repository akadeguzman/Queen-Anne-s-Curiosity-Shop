using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using QAShopWPF.Annotations;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using QAShopWPF.Views.Transaction;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionListViewModel : ObservableObject
    {
        private TransactionViewModel _selectedTransaction;
        private TransactionService _transactionService;
        private string _searchText;
        private string _transactionCount;

        public TransactionListViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;

            var person = _transactionService.GetTransactions()
                .Select(c =>
                    new TransactionViewModel(c)).ToList();

            TransactionList = new ObservableCollection<TransactionViewModel>(person);
        }

        public void Sync()
        {
            TransactionList.Clear();

            var transactions = _transactionService.GetTransactions()
                .Select(c =>
                    new TransactionViewModel(c)).ToList();

            foreach (var transaction in transactions)
            {
                TransactionList.Add(transaction);
            }

        }

        public ObservableCollection<TransactionViewModel> TransactionList { get; }
        
        public string TransactionCount
        {
            get => _transactionCount;
            set
            {
                _transactionCount = value;
                GetItemCount();
            }
        }
        public string GetItemCount()
        {
            var count = $"{TransactionList.Count}";
            return count;
        }

        public TransactionViewModel SelectedTransaction { get; set; }

        public void SearchTransaction(string searchString)
        {
            TransactionList.Clear();

            var transactions = _transactionService.GetTransactions().Where(c => c.TransactionId.ToString().Contains(searchString) ||
                                                                      c.InvoiceNumber.Contains(searchString) ||
                                                                      c.TransactionDate.Date.Day.ToString().Contains(searchString) ||
                                                                      c.TransactionDate.Date.Month.ToString().Contains(searchString) ||
                                                                      c.PersonLink.FirstName.Contains(searchString) ||
                                                                      c.PersonLink.LastName.Contains(searchString) ||
                                                                      c.TransactionTypeLink.Type.Contains(searchString));

            foreach (var transaction in transactions)
            {
                var transactionModel = new TransactionViewModel(transaction.TransactionId, transaction.InvoiceNumber,
                    transaction.TransactionDate, transaction.PersonLink.AdditionalContactLink.GetFullName(),transaction.Subtotal, transaction.Tax, transaction.Total, transaction.PersonLink.GetFullName(),
                    transaction.TransactionTypeLink.Type, transaction.PersonId, transaction.TransactionTypeId);

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
