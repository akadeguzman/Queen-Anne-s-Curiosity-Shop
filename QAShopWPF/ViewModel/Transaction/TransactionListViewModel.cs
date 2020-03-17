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
        private TransactionService _transactionService;
        private TransactionViewModel _selectedTransaction;
        private string _searchText;
        private string _transactionCount;
        private AddNewTransactionView _addNewTransactionView;

        public TransactionListViewModel(TransactionService transactionService)
        {
            _transactionService = transactionService;

            var person = _transactionService.GetTransactions()
                .Select(c =>
                    new TransactionViewModel(c)).ToList();

            TransactionList = new ObservableCollection<TransactionViewModel>(person);
        }


        public ObservableCollection<TransactionViewModel> TransactionList { get; }

        public ICommand AddTransaction => new RelayCommand(AddNewTransaction);

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
                    transaction.TransactionDate, transaction.Total, transaction.PersonLink.GetFullName(), transaction.TransactionTypeLink.Type,
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

        public void AddNewTransaction()
        {
            _addNewTransactionView = new AddNewTransactionView();
            _addNewTransactionView.Owner = Application.Current.MainWindow;
            _addNewTransactionView.DataContext = this;
            _addNewTransactionView.ShowDialog();
        }
    }
}
