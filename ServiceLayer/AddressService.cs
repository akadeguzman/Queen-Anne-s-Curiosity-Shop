using System.Collections.Generic;
using System.Linq;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class AddressService
    {
        private QueenAnneCuriosityShopContext _context;

        public AddressService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Address> GetAddresses()
        {
            return _context.Addresses;
        }

        public void UpdateAddress(int addressId, 
            string city, 
            string state, 
            string zipCode)
        {
            var address = _context.Addresses.Find(addressId);
            address.City = city;
            address.State = state;
            address.ZipCode = zipCode;

            _context.SaveChanges();
        }

        public void AddAddress(Address address)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
        }

        public void DeleteAddress(int addressId)
        {
            var personList = _context.Persons.Where(c => c.AddressId == addressId);
            _context.Persons.RemoveRange(personList);

            _context.Addresses.Remove(_context.Addresses.Find(addressId));
            _context.SaveChanges();
        }
    }
}