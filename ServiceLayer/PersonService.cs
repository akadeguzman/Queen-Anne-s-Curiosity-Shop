using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class PersonService
    {
        private QueenAnneCuriosityShopContext _context;

        public PersonService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Person> GetPersons()
        {
            return _context.Persons
                .Include(c => c.PersonTypeLink)
                .Include(c => c.AddressLink);
        }

        //---------------------------------------

        public void UpdatePerson(int personId, 
            string lastName, 
            string firstName, 
            string phoneNumber,
            int personTypeId,
            int addressId,
            int additionalContactId)
        {
            var person = _context.Persons.Find(personId);
            person.LastName = lastName;
            person.FirstName = firstName;
            person.PhoneNumber = phoneNumber;
            person.PersonTypeId = personTypeId;
            person.AddressId = addressId;
            person.AdditionalContactId = additionalContactId;

            _context.SaveChanges();
        }

        public void UpdatePerson(int personId,
            string lastName,
            string firstName,
            string phoneNumber,
            int personTypeId,
            int addressId)
        {
            var person = _context.Persons.Find(personId);
            person.LastName = lastName;
            person.FirstName = firstName;
            person.PhoneNumber = phoneNumber;
            person.PersonTypeId = personTypeId;
            person.AddressId = addressId;

            _context.SaveChanges();
        }

        //----------------------------------

        public void AddPerson(Person person)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
        }

    }
}
