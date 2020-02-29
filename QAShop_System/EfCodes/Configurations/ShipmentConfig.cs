using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ShipmentConfig : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipment");

            builder.HasKey(c => c.ShipmentId);
            builder.Property(c => c.ShipmentId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ShipperLink)
                .WithMany(c => c.Shipments)
                .HasForeignKey(c => c.ShipperId)
                .IsRequired(true);
        }
    }
}