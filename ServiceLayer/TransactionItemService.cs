using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class TransactionItemService
    {
        private QueenAnneCuriosityShopContext _context;

        public TransactionItemService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<TransactionItem> GetTransactionItems()
        {
            return _context.TransactionItems
                .Include(c => c.ItemVendorLink);
        }

        public void AddTransactionItem(TransactionItem transactionItemVendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.TransactionItems.Add(transactionItemVendor);
                _context.SaveChanges();
            }
        }
        
        public void DeleteTransactionItem(int transactionItemVendorId)
        {
            _context.TransactionItems.Remove(_context.TransactionItems.Find(transactionItemVendorId));
            _context.SaveChanges();
        }
    }
}