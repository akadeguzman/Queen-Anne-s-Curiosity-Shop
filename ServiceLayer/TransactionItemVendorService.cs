using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class TransactionItemVendorService
    {
        private QueenAnneCuriosityShopContext _context;

        public TransactionItemVendorService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<TransactionItemVendor> GetTransactionItemVendors()
        {
            return _context.TransactionItemVendors
                .Include(c => c.TransactionLink)
                .Include(c => c.ItemVendorLink);
        }

        public void AddTransactionItemVendor(TransactionItemVendor transactionItemVendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.TransactionItemVendors.Add(transactionItemVendor);
                _context.SaveChanges();
            }
        }

        public void UpdateTransactionItemVendor(int transactionItemVendorId,
            int quantity,
            int transactionId,
            int itemVendorId)
        {
            var transactionItemVendor = _context.TransactionItemVendors.Find(transactionItemVendorId);
            transactionItemVendor.Quantity = quantity;
            transactionItemVendor.TransactionId = transactionId;
            transactionItemVendor.ItemVendorId = itemVendorId;

            _context.SaveChanges();
        }

        public void DeleteTransactionItemVendor(int transactionItemVendorId)
        {
            _context.TransactionItemVendors.Remove(_context.TransactionItemVendors.Find(transactionItemVendorId));
            _context.SaveChanges();
        }
    }
}