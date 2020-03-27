using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QAShop_System.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "ItemAvailability",
                columns: table => new
                {
                    ItemAvailabilityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAvailability", x => x.ItemAvailabilityId);
                });

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    PersonTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.PersonTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    ShipperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipperName = table.Column<string>(nullable: true),
                    ShipperContact = table.Column<string>(nullable: true),
                    ShipperFax = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.ShipperId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionType",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionType", x => x.TransactionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemDescription = table.Column<string>(nullable: true),
                    InventoryQuantity = table.Column<int>(nullable: false),
                    ItemAvailabilityId = table.Column<int>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_ItemAvailability_ItemAvailabilityId",
                        column: x => x.ItemAvailabilityId,
                        principalTable: "ItemAvailability",
                        principalColumn: "ItemAvailabilityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ItemType_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemType",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PersonTypeId = table.Column<int>(nullable: false),
                    AddressId = table.Column<int>(nullable: false),
                    AdditionalContactId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Person_AdditionalContactId",
                        column: x => x.AdditionalContactId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Person_PersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonType",
                        principalColumn: "PersonTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryOfOrigin = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    ShipperInvoiceNumber = table.Column<string>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    InsuredValue = table.Column<int>(nullable: false),
                    InsurerName = table.Column<string>(nullable: true),
                    ShipperId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.ShipmentId);
                    table.ForeignKey(
                        name: "FK_Shipment_Shipper_ShipperId",
                        column: x => x.ShipperId,
                        principalTable: "Shipper",
                        principalColumn: "ShipperId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVendor",
                columns: table => new
                {
                    ItemVendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    LocalCurrency = table.Column<int>(nullable: false),
                    ExchangeRate = table.Column<int>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVendor", x => x.ItemVendorId);
                    table.ForeignKey(
                        name: "FK_ItemVendor_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemVendor_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchasingAgent",
                columns: table => new
                {
                    PurchasingAgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasingAgent", x => x.PurchasingAgentId);
                    table.ForeignKey(
                        name: "FK_PurchasingAgent_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<string>(nullable: true),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Subtotal = table.Column<int>(nullable: true),
                    Tax = table.Column<int>(nullable: true),
                    Total = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    TransactionTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionType_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionType",
                        principalColumn: "TransactionTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItemVendor",
                columns: table => new
                {
                    ShipmentItemVendorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(nullable: false),
                    ShipmentId = table.Column<int>(nullable: false),
                    ItemVendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItemVendor", x => x.ShipmentItemVendorId);
                    table.ForeignKey(
                        name: "FK_ShipmentItemVendor_ItemVendor_ItemVendorId",
                        column: x => x.ItemVendorId,
                        principalTable: "ItemVendor",
                        principalColumn: "ItemVendorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipmentItemVendor_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransactionItem",
                columns: table => new
                {
                    TransactionItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    TransactionId = table.Column<int>(nullable: false),
                    ItemVendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionItem", x => x.TransactionItemId);
                    table.ForeignKey(
                        name: "FK_TransactionItem_ItemVendor_ItemVendorId",
                        column: x => x.ItemVendorId,
                        principalTable: "ItemVendor",
                        principalColumn: "ItemVendorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransactionItem_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procurement",
                columns: table => new
                {
                    ProcurementId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Condition = table.Column<string>(nullable: true),
                    ArrivalDate = table.Column<DateTime>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    ShipmentItemVendorId = table.Column<int>(nullable: false),
                    ReceivingClerkId = table.Column<int>(nullable: false),
                    PurchasingAgentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procurement", x => x.ProcurementId);
                    table.ForeignKey(
                        name: "FK_Procurement_PurchasingAgent_PurchasingAgentId",
                        column: x => x.PurchasingAgentId,
                        principalTable: "PurchasingAgent",
                        principalColumn: "PurchasingAgentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procurement_Person_ReceivingClerkId",
                        column: x => x.ReceivingClerkId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procurement_ShipmentItemVendor_ShipmentItemVendorId",
                        column: x => x.ShipmentItemVendorId,
                        principalTable: "ShipmentItemVendor",
                        principalColumn: "ShipmentItemVendorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemAvailabilityId",
                table: "Item",
                column: "ItemAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemTypeId",
                table: "Item",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendor_ItemId",
                table: "ItemVendor",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVendor_VendorId",
                table: "ItemVendor",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AdditionalContactId",
                table: "Person",
                column: "AdditionalContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PersonTypeId",
                table: "Person",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Procurement_PurchasingAgentId",
                table: "Procurement",
                column: "PurchasingAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Procurement_ReceivingClerkId",
                table: "Procurement",
                column: "ReceivingClerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Procurement_ShipmentItemVendorId",
                table: "Procurement",
                column: "ShipmentItemVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasingAgent_PersonId",
                table: "PurchasingAgent",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_ShipperId",
                table: "Shipment",
                column: "ShipperId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItemVendor_ItemVendorId",
                table: "ShipmentItemVendor",
                column: "ItemVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItemVendor_ShipmentId",
                table: "ShipmentItemVendor",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PersonId",
                table: "Transaction",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_ItemVendorId",
                table: "TransactionItem",
                column: "ItemVendorId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionItem_TransactionId",
                table: "TransactionItem",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Procurement");

            migrationBuilder.DropTable(
                name: "TransactionItem");

            migrationBuilder.DropTable(
                name: "PurchasingAgent");

            migrationBuilder.DropTable(
                name: "ShipmentItemVendor");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ItemVendor");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TransactionType");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "ItemAvailability");

            migrationBuilder.DropTable(
                name: "ItemType");
        }
    }
}
