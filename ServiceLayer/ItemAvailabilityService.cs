using System.Linq;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ItemAvailabilityService
    {
        private QueenAnneCuriosityShopContext _context;

        public ItemAvailabilityService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<ItemAvailability> GetItemAvailabilities()
        {
            return _context.ItemAvailabilities;
        }

        public void UpdateItemAvailability(int itemAvailabilityId, 
            string status)
        {
            var itemAvailability = _context.ItemAvailabilities.Find(itemAvailabilityId);
            itemAvailability.Status = status;
            _context.SaveChanges();
        }

        public void AddItemAvailability(ItemAvailability itemAvailability)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.ItemAvailabilities.Add(itemAvailability);
                _context.SaveChanges();
            }
        }

        public void DeleteItemAvailability(int itemAvailabilityId)
        {
            var itemList = _context.Items.Where(c => c.ItemAvailabilityId == itemAvailabilityId);

            _context.Items.RemoveRange(itemList);

            _context.ItemAvailabilities.Remove(_context.ItemAvailabilities.Find(itemAvailabilityId));
            _context.SaveChanges();
        }
    }
}