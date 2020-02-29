using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class TransactionTypeService
    {
        private QueenAnneCuriosityShopContext _context;

        public TransactionTypeService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<TransactionType> GeTransactionTypes()
        {
            return _context.TransactionTypes;
        }

        public void UpdateTransactionType(int transactionTypeId,
            string type)
        {
            var transactionType = _context.TransactionTypes.Find(transactionTypeId);
            transactionType.Type = type;

            _context.SaveChanges();
        }

        public void AddTransactionType(TransactionType transactionType)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.TransactionTypes.Add(transactionType);
                _context.SaveChanges();
            }
        }

        public void DeleteTransactionType(int transactionTypeid)
        {
            var transactionTypeList = _context.Transactions.Where(c => c.TransactionTypeId == transactionTypeid);

            _context.Transactions.RemoveRange(transactionTypeList);

            _context.TransactionTypes.Remove(_context.TransactionTypes.Find(transactionTypeid));
            _context.SaveChanges();
        }
    }
}