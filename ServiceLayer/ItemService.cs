using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ItemService
    {
        private QueenAnneCuriosityShopContext _context;

        public ItemService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Item> GetItems()
        {
            return _context.Items
                .Include(c => c.ItemTypeLink)
                .Include(c => c.ItemAvailabilityLink);
        }

        public void UpdateItem(int itemId,
            string itemDescription,
            DateTime purchaseDate,
            int itemCost,
            int inventoryQuantity,
            string city,
            int localCurrency,
            int exchangeRate,
            int itemAvailabilityId,
            int itemTypeId)
        {
            var item = _context.Items.Find(itemId);
            item.ItemDescription = itemDescription;
            item.PurchaseDate = purchaseDate;
            item.ItemCost = itemCost;
            item.InventoryQuantity = inventoryQuantity;
            item.City = city;
            item.LocalCurrency = localCurrency;
            item.ExchangeRate = exchangeRate;
            item.ItemAvailabilityId = itemAvailabilityId;
            item.ItemTypeId = itemTypeId;

            _context.SaveChanges();
        }

        public void AddItem(Item item)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Items.Add(item);
                _context.SaveChanges();
            }
        }

        public void DeleteItem(int itemId)
        {
            var transactionItemVendor = _context.ItemVendors.Where(c => c.ItemId == itemId);
            
            foreach (var transactionItem in transactionItemVendor)
            {
                var transactionList = _context.TransactionItemVendors.Where(c => c.TransactionItemVendorId == transactionItem.ItemId);
                _context.TransactionItemVendors.RemoveRange(transactionList);

                var shipmentList = _context.ShipmentItemVendors.Where(c => c.ShipmentItemVendorId == transactionItem.ItemId);
                _context.ShipmentItemVendors.RemoveRange(shipmentList);
            }

            _context.ItemVendors.RemoveRange(transactionItemVendor);

            _context.Items.Remove(_context.Items.Find(itemId));
            _context.SaveChanges();
        }

    }
}