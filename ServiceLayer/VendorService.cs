using System;
using System.Linq;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class VendorService
    {
        private QueenAnneCuriosityShopContext _context;

        public VendorService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Vendor> GetVendors()
        {
            return _context.Vendors;
        }
        
        //--------------------------------------

        public void UpdateVendor(int vendorId,
            string firstName,
            string lastName,
            string contactNumber)
        {
            var vendor = _context.Vendors.Find(vendorId);
            vendor.FirstName = firstName;
            vendor.LastName = lastName;
            vendor.ContactNumber = contactNumber;
            _context.SaveChanges();
        }

        public void UpdateVendor(int vendorId,
            string firstName,
            string lastName,
            string contactNumber,
            string companyName)
        {
            var vendor = _context.Vendors.Find(vendorId);
            vendor.FirstName = firstName;
            vendor.LastName = lastName;
            vendor.ContactNumber = contactNumber;
            vendor.CompanyName = companyName;
            _context.SaveChanges();
        }

        //----------------------------------------

        public void AddVendor(Vendor vendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Vendors.Add(vendor);
                _context.SaveChanges();
            }
        }

        public void DeleteVendor(int vendorId)
        {
            var itemVendors = _context.ItemVendors.Where(c => c.VendorId == vendorId);


            _context.ItemVendors.RemoveRange(itemVendors);

            _context.Vendors.Remove(_context.Vendors.Find(vendorId));
            _context.SaveChanges();
        }
    }
}