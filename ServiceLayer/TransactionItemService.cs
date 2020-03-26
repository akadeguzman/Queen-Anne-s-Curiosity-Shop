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
            return _context.TransactionItemVendors
                .Include(c => c.ItemVendorLink);
        }

        public void AddTransactionItem(TransactionItem transactionItemVendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.TransactionItemVendors.Add(transactionItemVendor);
                _context.SaveChanges();
            }
        }
        
        public void DeleteTransactionItem(int transactionItemVendorId)
        {
            _context.TransactionItemVendors.Remove(_context.TransactionItemVendors.Find(transactionItemVendorId));
            _context.SaveChanges();
        }
    }
}