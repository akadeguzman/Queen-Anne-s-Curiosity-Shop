﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QAShop_System.EfClasses;

namespace QAShop_System.Migrations
{
    [DbContext(typeof(QueenAnneCuriosityShopContext))]
    partial class QueenAnneCuriosityShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QAShop_System.EfClasses.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ItemAvailabilityId")
                        .HasColumnType("int");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemTypeId")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemAvailabilityId");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ItemAvailability", b =>
                {
                    b.Property<int>("ItemAvailabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemAvailabilityId");

                    b.ToTable("ItemAvailability");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ItemVendor", b =>
                {
                    b.Property<int>("ItemVendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExchangeRate")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("LocalCurrency")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("ItemVendorId");

                    b.HasIndex("ItemId");

                    b.HasIndex("VendorId");

                    b.ToTable("ItemVendor");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdditionalContactId")
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("AdditionalContactId");

                    b.HasIndex("AddressId");

                    b.HasIndex("PersonTypeId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.PersonType", b =>
                {
                    b.Property<int>("PersonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonTypeId");

                    b.ToTable("PersonType");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Procurement", b =>
                {
                    b.Property<int>("ProcurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Condition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PurchasingAgentId")
                        .HasColumnType("int");

                    b.Property<int>("ReceivingClerkId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentItemVendorId")
                        .HasColumnType("int");

                    b.HasKey("ProcurementId");

                    b.HasIndex("PurchasingAgentId");

                    b.HasIndex("ReceivingClerkId");

                    b.HasIndex("ShipmentItemVendorId");

                    b.ToTable("Procurement");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.PurchasingAgent", b =>
                {
                    b.Property<int>("PurchasingAgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("PurchasingAgentId");

                    b.HasIndex("PersonId");

                    b.ToTable("PurchasingAgent");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Shipment", b =>
                {
                    b.Property<int>("ShipmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InsuredValue")
                        .HasColumnType("int");

                    b.Property<string>("InsurerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int");

                    b.Property<string>("ShipperInvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipmentId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Shipment");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ShipmentItemVendor", b =>
                {
                    b.Property<int>("ShipmentItemVendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemVendorId")
                        .HasColumnType("int");

                    b.Property<int>("ShipmentId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("ShipmentItemVendorId");

                    b.HasIndex("ItemVendorId");

                    b.HasIndex("ShipmentId");

                    b.ToTable("ShipmentItemVendor");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Shipper", b =>
                {
                    b.Property<int>("ShipperId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ShipperContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipperFax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipperName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShipperId");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InvoiceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("Subtotal")
                        .HasColumnType("int");

                    b.Property<int?>("Tax")
                        .HasColumnType("int");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.TransactionItem", b =>
                {
                    b.Property<int>("TransactionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemVendorId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("TransactionItemId");

                    b.HasIndex("ItemVendorId");

                    b.HasIndex("TransactionId");

                    b.ToTable("TransactionItem");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.TransactionType", b =>
                {
                    b.Property<int>("TransactionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionType");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Vendor", b =>
                {
                    b.Property<int>("VendorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VendorId");

                    b.ToTable("Vendor");
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Item", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.ItemAvailability", "ItemAvailabilityLink")
                        .WithMany("Items")
                        .HasForeignKey("ItemAvailabilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.ItemType", "ItemTypeLink")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ItemVendor", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.Item", "ItemLink")
                        .WithMany("ItemVendors")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.Vendor", "VendorLink")
                        .WithMany("ItemVendors")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Person", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.Person", "AdditionalContactLink")
                        .WithMany("Persons")
                        .HasForeignKey("AdditionalContactId");

                    b.HasOne("QAShop_System.EfClasses.Address", "AddressLink")
                        .WithMany("Persons")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.PersonType", "PersonTypeLink")
                        .WithMany("Persons")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Procurement", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.PurchasingAgent", "PurchasingAgentLink")
                        .WithMany("Procurements")
                        .HasForeignKey("PurchasingAgentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.Person", "ReceivingClerkLink")
                        .WithMany("Procurements")
                        .HasForeignKey("ReceivingClerkId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.ShipmentItemVendor", "ShipmentItemLink")
                        .WithMany("Procurements")
                        .HasForeignKey("ShipmentItemVendorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.PurchasingAgent", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.Person", "PersonLink")
                        .WithMany("PurchasingAgents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Shipment", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.Shipper", "ShipperLink")
                        .WithMany("Shipments")
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.ShipmentItemVendor", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.ItemVendor", "ItemVendorLink")
                        .WithMany("ShipmentItemVendors")
                        .HasForeignKey("ItemVendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.Shipment", "ShipmentLink")
                        .WithMany("ShipmentItemVendors")
                        .HasForeignKey("ShipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.Transaction", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.Person", "PersonLink")
                        .WithMany("Transactions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.TransactionType", "TransactionTypeLink")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QAShop_System.EfClasses.TransactionItem", b =>
                {
                    b.HasOne("QAShop_System.EfClasses.ItemVendor", "ItemVendorLink")
                        .WithMany("TransactionItems")
                        .HasForeignKey("ItemVendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QAShop_System.EfClasses.Transaction", "TransactionLink")
                        .WithMany("TransactionItems")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
