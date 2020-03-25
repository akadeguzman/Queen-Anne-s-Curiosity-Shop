using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ItemVendorService
    {
        private QueenAnneCuriosityShopContext _context;

        public ItemVendorService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<ItemVendor> GetItemVendors()
        {
            return _context.ItemVendors
                .Include(c => c.VendorLink)
                .Include(c => c.ItemLink);
        }

        public void UpdateItem(int itemVendorId, int personId, int itemId, int price, DateTime purchaseDate,
            string city,
            int localCurrency,
            int exchangeRate)
        {
            var itemVendor = _context.ItemVendors.Find(itemVendorId);
            itemVendor.PurchaseDate = purchaseDate;
            itemVendor.City = city;
            itemVendor.LocalCurrency = localCurrency;
            itemVendor.ExchangeRate = exchangeRate;

            _context.SaveChanges();
        }

        public void AddItem(ItemVendor itemVendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.ItemVendors.Add(itemVendor);
                _context.SaveChanges();
            }
        }
    }
}