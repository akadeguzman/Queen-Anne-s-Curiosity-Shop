using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ProcurementService
    {
        private QueenAnneCuriosityShopContext _context;

        public ProcurementService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Procurement> GetProcurements()
        {
            return _context.Procurements
                .Include(c => c.ShipmentItemLink)
                .Include(c => c.PersonLink);
        }

        public void UpdateProcurement(int procurementId,
            int ShipmentItemVendorId,
            int personId)
        {
            var procurement = _context.Procurements.Find(procurementId);
            procurement.ShipmentItemVendorId = ShipmentItemVendorId;
            procurement.PersonId = personId;

            _context.SaveChanges();
        }

        public void AddProcurement(Procurement procurement)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Procurements.Add(procurement);
                _context.SaveChanges();
            }
        }

        public void DeleteProcurement(int procurementId)
        {
            _context.Procurements.Remove(_context.Procurements.Find(procurementId));
            _context.SaveChanges();
        }

    }
}