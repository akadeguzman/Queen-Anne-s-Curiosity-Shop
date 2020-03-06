using System.Collections.ObjectModel;
using System.Linq;
using QAShopWPF.ViewModel.Person;
using ServiceLayer;

namespace QAShopWPF.ViewModel.Transaction
{
    public class TransactionListViewModel
    {
        private TransactionService _transactionService;
        private TransactionViewModel _selectedTransaction;
        private string _searchText;

        public TransactionListViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;

            var person = _transactionService.GetTransactions()
                .Select(c =>
                    new TransactionViewModel(
                        c.TransactionId,
                        c.InvoiceNumber,
                        c.TransactionDate,
                        c.Subtotal,
                        c.Tax,
                        c.Total, 
                        c.PersonLink.GetFullName(),
                        c.TransactionTypeLink.Type,
                        c.PersonId,
                        c.TransactionTypeId)).ToList();

            TransactionList = new ObservableCollection<TransactionViewModel>(person);

        }


        public ObservableCollection<TransactionViewModel> TransactionList { get; }

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
