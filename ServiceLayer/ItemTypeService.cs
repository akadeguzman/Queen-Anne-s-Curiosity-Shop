using System.Linq;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ItemTypeService
    {
        private QueenAnneCuriosityShopContext _context;

        public ItemTypeService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<ItemType> GetItemTypes()
        {
            return _context.ItemTypes;
        }

        public void UpdateItemType(int itemTypeId,
            string type)
        {
            var itemType = _context.ItemTypes.Find(itemTypeId);
            itemType.Type = type;

            _context.SaveChanges();
        }

        public void AddItemType(ItemType itemType)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.ItemTypes.Add(itemType);
                _context.SaveChanges();
            }
        }

        public void DeleteItemType(int itemTypeId)
        {
            var itemTypeList = _context.ItemTypes.Where(c => c.ItemTypeId == itemTypeId);

            _context.ItemTypes.RemoveRange(itemTypeList);

            _context.ItemTypes.Remove(_context.ItemTypes.Find(itemTypeId));
            _context.SaveChanges();
        }
    }
}