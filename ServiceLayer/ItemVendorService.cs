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

        public void UpdateItem(int itemVendorId, int personId, int itemId, int price)
        {
            var itemVendor = _context.ItemVendors.Find(itemVendorId);
            

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
    }
}