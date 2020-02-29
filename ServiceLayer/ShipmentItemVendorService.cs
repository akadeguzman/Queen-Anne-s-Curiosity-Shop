using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ShipmentItemVendorService
    {
        private QueenAnneCuriosityShopContext _context;

        public ShipmentItemVendorService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<ShipmentItemVendor> GetShipmentItemVendors()
        {
            return _context.ShipmentItemVendors
                .Include(c => c.ShipmentLink)
                .Include(c => c.ItemVendorLink)
                .ThenInclude(c => c.ItemLink)
                .Include(c => c.ItemVendorLink)
                .ThenInclude(c => c.VendorLink);
        }

        public void AddShipmentItemVendor(ShipmentItemVendor shipmentItemVendor)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.ShipmentItemVendors.Add(shipmentItemVendor);
                _context.SaveChanges();
            }
        }

        public void UpdateShipmentItemVendor(int shipmentItemVendorId,
            int value,
            int shipmentId,
            int itemVendorId)
        {
            var ShipmentItemVendor = _context.ShipmentItemVendors.Find(shipmentItemVendorId);
            ShipmentItemVendor.Value = value;
            ShipmentItemVendor.ShipmentId = shipmentId;
            ShipmentItemVendor.ItemVendorId = itemVendorId;

            _context.SaveChanges();
        }

        public void DeleteShipmentItemVendor(int shipmentItemVendorId)
        {
            _context.ShipmentItemVendors.Remove(_context.ShipmentItemVendors.Find(shipmentItemVendorId));
            _context.SaveChanges();
        }

    }
}