using System;
using System.Linq;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using QAShop_System.EfClasses;

namespace QAShop_System.Tests
{
    [TestFixture]
    public class EntityQueryTest
    {
        [Test]
        public void Person_ViewAllPersons()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var persons = context.Persons.ToList();

                Console.WriteLine($"{"FirstName", 4} {"LastName", 4} {"ContactNumber", 4}");

                foreach (var person in persons)
                {
                    Console.WriteLine($"{person.FirstName, 4} {person.LastName, 4} {person.PhoneNumber}");
                }
            }
        }

        [Test]
        public void Item_ViewAllItems()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var items = context.Items.ToList();

                Console.WriteLine($"{"ItemId",4} {"Description",4} {"Purchase Date" ,4}");

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.ItemId, 4} {item.ItemDescription, 4} {item.PurchaseDate, 4}");
                }
            }
        }

        [Test]
        public void Shippers_ViewAllShippers()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var shippers = context.Shippers.ToList();
                
                foreach (var shipper in shippers)
                {
                    Console.WriteLine($"{shipper.ShipperId,4} {shipper.ShipperName,4} {shipper.ShipperContact} ");
                }
            }
        }

        [Test]
        public void Shipment_ViewAllShipments()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var shipments = context.Shipments
                    .Include(c=>c.ShipperLink).ToList();

                foreach (var shipment in shipments)
                {
                    Console.WriteLine($"{shipment.ShipmentId, 4} {shipment.ShipperInvoiceNumber, 10} {shipment.ShipperLink.ShipperName}");
                    
                }
            }
        }

        [Test]
        public void Shipment_ViewAllShipmentsWithItemsAndVendors()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var shipments = context.Shipments
                    .Include(c => c.ShipperLink)
                    .Include(c => c.ShipmentItemVendors)
                    .ThenInclude(c => c.ItemVendorLink)
                    .ThenInclude(c => c.ItemLink)
                    .ThenInclude(c=>c.ItemTypeLink)
                    .Include(c => c.ShipmentItemVendors)
                    .ThenInclude(c => c.ItemVendorLink.VendorLink)
                    .ToList();

                foreach (var shipment in shipments)
                {
                    Console.WriteLine($"{shipment.ShipmentId} from: {shipment.CountryOfOrigin}   shipped by:{shipment.ShipperLink.ShipperName} | value:{shipment.InsuredValue}");
                    foreach (var item in shipment.ShipmentItemVendors)
                    {
                        Console.WriteLine($"{item.ItemVendorLink.ItemId, 10} {item.ItemVendorLink.ItemLink.ItemDescription}  TYPE:{item.ItemVendorLink.ItemLink.ItemTypeLink.Type} sold by: {item.ItemVendorLink.VendorLink.LastName}");
                    }

                }
            }
        }

        [Test]
        public void Shipment_ViewAllVendors()
        {
            using (var context = new QueenAnneCuriosityShopContext())
            {
                var vendors = context.Vendors
                    .ToList();

                foreach (var vendor in vendors)
                {
                    Console.WriteLine($"{vendor.VendorId, 4}  {vendor.FirstName} {vendor.LastName}  Company:{vendor.CompanyName, -50}");
                }
            }
        }
    }
}