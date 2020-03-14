using System;
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
                .Include(c => c.ReceivingClerkLink)
                .Include(c => c.PurchasingAgentLink);
        }

        public void UpdateProcurement(int procurementId, 
            string condition,
            DateTime arrivalDate,
            DateTime departureDate,
            int receivingClerkId,
            int purchasingAgentId)
        {
            var procurement = _context.Procurements.Find(procurementId);
            procurement.Condition = condition;
            procurement.ReceivingClerkId = receivingClerkId;
            procurement.ShipmentItemLink.ShipmentLink.ArrivalDate = arrivalDate;
            procurement.ShipmentItemLink.ShipmentLink.DepartureDate = departureDate;
            procurement.PurchasingAgentId = purchasingAgentId;

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