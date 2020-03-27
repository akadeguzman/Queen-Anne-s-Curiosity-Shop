using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class TransactionService
    {
        private QueenAnneCuriosityShopContext _context;

        public TransactionService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> GetTransactions()
        {
            return _context.Transactions
                .Include(c => c.PersonLink)
                .Include(c => c.TransactionTypeLink);
        }

        public void AddTransaction(Transaction transaction)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Transactions.Add(transaction);
                _context.SaveChanges();
            }
        }

        public void UpdateTransaction(int transactionId,
            string invoiceNumber,
            DateTime transactionDate, int? subtotal, int? tax,
            int? total, int personId, int transactionTypeId)
        {
            var transaction = _context.Transactions.Find(transactionId);
            transaction.InvoiceNumber = invoiceNumber;
            transaction.TransactionDate = transactionDate;
            transaction.Subtotal = subtotal;
            transaction.Tax = tax;
            transaction.Total = total;
            transaction.PersonId = personId;
            transaction.TransactionTypeId = transactionTypeId;

            _context.SaveChanges();
        }

        public void DeleteTransaction(int transactionId)
        {
            var transactions = _context.Transactions.Where(c => c.TransactionId == transactionId);


            _context.Transactions.RemoveRange(transactions);

            _context.Transactions.Remove(_context.Transactions.Find(transactions));
            _context.SaveChanges();
        }



    }
}