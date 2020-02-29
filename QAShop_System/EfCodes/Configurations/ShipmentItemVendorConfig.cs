using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ShipmentItemVendorConfig : IEntityTypeConfiguration<ShipmentItemVendor>
    {
        public void Configure(EntityTypeBuilder<ShipmentItemVendor> builder)
        {
            builder.ToTable("ShipmentItemVendor");

            builder.HasKey(c => c.ShipmentItemVendorId);
            builder.Property(c => c.ShipmentItemVendorId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ShipmentLink)
                .WithMany(c => c.ShipmentItemVendors)
                .HasForeignKey(c => c.ShipmentId);

            builder.HasOne(c => c.ItemVendorLink)
                .WithMany(c => c.ShipmentItemVendors)
                .HasForeignKey(c => c.ItemVendorId)
                .IsRequired(true);
        }
    }
}