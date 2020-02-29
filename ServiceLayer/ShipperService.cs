using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ShipperService
    {
        private QueenAnneCuriosityShopContext _context;

        public ShipperService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Shipper> GetShippers()
        {
            return _context.Shippers;
        }

        public void UpdateShipper(int shipperId,
            string shipperName,
            string contact,
            string fax)
        {
            var shipper = _context.Shippers.Find(shipperId);
            shipper.ShipperName = shipperName;
            shipper.ShipperContact = contact;
            shipper.ShipperFax = fax;
            _context.SaveChanges();
        }

        public void AddShipper(Shipper shipper)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Shippers.Add(shipper);
                _context.SaveChanges();
            }
        }

        public void DeleteShipper(int shipperId)
        {
            var shipmentList = _context.Shipments.Where(c => c.ShipperId == shipperId);

            _context.Shipments.RemoveRange(shipmentList);

            _context.Shippers.Remove(_context.Shippers.Find(shipperId));
            _context.SaveChanges();
        }

    }
}