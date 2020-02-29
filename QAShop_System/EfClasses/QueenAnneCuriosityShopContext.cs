using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using QAShop_System.EfCodes.Configurations;

namespace QAShop_System.EfClasses
{
    public class QueenAnneCuriosityShopContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<Procurement> Procurements { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentItemVendor> ShipmentItemVendors { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<TransactionItemVendor> TransactionItemVendors { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<ItemVendor> ItemVendors { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<ItemAvailability> ItemAvailabilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QAShopSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new ItemConfig());
            modelBuilder.ApplyConfiguration(new ItemTypeConfig());
            modelBuilder.ApplyConfiguration(new ItemVendorConfig());
            modelBuilder.ApplyConfiguration(new ItemAvailabilityConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            modelBuilder.ApplyConfiguration(new PersonTypeConfig());
            modelBuilder.ApplyConfiguration(new ProcurementConfig());
            modelBuilder.ApplyConfiguration(new ShipmentConfig());
            modelBuilder.ApplyConfiguration(new ShipmentItemVendorConfig());
            modelBuilder.ApplyConfiguration(new ShipperConfig());
            modelBuilder.ApplyConfiguration(new TransactionItemVendorConfig());
            modelBuilder.ApplyConfiguration(new TransactionConfig());
            modelBuilder.ApplyConfiguration(new TransactionTypeConfig());
            modelBuilder.ApplyConfiguration(new VendorConfig());
        }
    }
}
