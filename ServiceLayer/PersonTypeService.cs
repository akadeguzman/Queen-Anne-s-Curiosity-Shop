using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class PersonTypeService
    {
        private QueenAnneCuriosityShopContext _context;

        public PersonTypeService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<PersonType> GetPersonTypes()
        {
            return _context.PersonTypes;
        }

        public void AddPersonType(PersonType personType)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.PersonTypes.Add(personType);
                _context.SaveChanges();
            }
        }

        public void UpdatePersonType(int personTypeId,
            string type)
        {
            var itemType = _context.ItemTypes.Find(personTypeId);
            itemType.Type = type;

            _context.SaveChanges();
        }

    }
}