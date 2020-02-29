using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ItemVendorConfig : IEntityTypeConfiguration<ItemVendor>
    {
        public void Configure(EntityTypeBuilder<ItemVendor> builder)
        {
            builder.ToTable("ItemVendor");

            builder.HasKey(c => c.ItemVendorId);
            builder.Property(c => c.ItemVendorId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.VendorLink)
                .WithMany(c => c.ItemVendors)
                .HasForeignKey(c => c.VendorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ItemLink)
                .WithMany(c => c.ItemVendors)
                .HasForeignKey(c => c.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}