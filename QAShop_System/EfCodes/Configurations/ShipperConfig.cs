using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ShipperConfig : IEntityTypeConfiguration<Shipper>
    {
        public void Configure(EntityTypeBuilder<Shipper> builder)
        {
            builder.ToTable("Shipper");

            builder.HasKey(c => c.ShipperId);
            builder.Property(c => c.ShipperId).ValueGeneratedOnAdd();
        }
    }
}