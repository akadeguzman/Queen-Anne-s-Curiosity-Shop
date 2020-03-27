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
            int inventoryQuantity,
            int itemAvailabilityId,
            int itemTypeId)
        {
            var item = _context.Items.Find(itemId);
            item.ItemDescription = itemDescription;
            item.InventoryQuantity = inventoryQuantity;
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
            var transactionItems = _context.ItemVendors.Where(c => c.ItemId == itemId);
            
            foreach (var transactionItem in transactionItems)
            {
                var transactionList = _context.TransactionItems.Where(c => c.TransactionItemId == transactionItem.ItemId);
                _context.TransactionItems.RemoveRange(transactionList);

                var shipmentList = _context.ShipmentItemVendors.Where(c => c.ShipmentItemVendorId == transactionItem.ItemId);
                _context.ShipmentItemVendors.RemoveRange(shipmentList);
            }

            _context.ItemVendors.RemoveRange(transactionItems);

            _context.Items.Remove(_context.Items.Find(itemId));
            _context.SaveChanges();
        }

    }
}