using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfClasses;

namespace ServiceLayer
{
    public class ShipmentService
    {
        private QueenAnneCuriosityShopContext _context;

        public ShipmentService(QueenAnneCuriosityShopContext context)
        {
            _context = context;
        }

        public IQueryable<Shipment> GetShipments()
        {
            return _context.Shipments
                .Include(c => c.ShipperLink);
        }

        public void UpdateShipment(int shipmentId,
            string countryOfOrigin,
            string destination,
            string shipperInvoiceNumber,
            DateTime departureTime,
            DateTime arrivalTime,
            int insuredValue,
            string insurerName)
        {
            var shipment = _context.Shipments.Find(shipmentId);
            shipment.CountryOfOrigin = countryOfOrigin;
            shipment.Destination = destination;
            shipment.ShipperInvoiceNumber = shipperInvoiceNumber;
            shipment.DepartureDate = departureTime;
            shipment.ArrivalDate = arrivalTime;
            shipment.InsuredValue = insuredValue;
            shipment.InsurerName = insurerName;
            _context.SaveChanges();
        }

        public void AddShipment(Shipment shipment)
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                _context.Shipments.Add(shipment);
                _context.SaveChanges();
            }
        }

        public void DeleteShipment(int shipmentId)
        {
            var shipmentItemVendorList = _context.ShipmentItemVendors.Where(c => c.ShipmentId == shipmentId);

            foreach (var shipmentItemVendor in shipmentItemVendorList)
            {
                var procurementList = _context.Procurements.Where(c => c.ProcurementId == shipmentItemVendor.ShipmentId);
                _context.Procurements.RemoveRange(procurementList);
            }
            _context.ShipmentItemVendors.RemoveRange(shipmentItemVendorList);

            _context.Shipments.Remove(_context.Shipments.Find(shipmentId));
            _context.SaveChanges();
        }
    }
}