using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class TransactionItemVendorConfig : IEntityTypeConfiguration<TransactionItem>
    {
        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {
            builder.ToTable("TransactionItemVendor");

            builder.HasKey(c => c.TransactionItemVendorId);
            builder.Property(c => c.TransactionItemVendorId).ValueGeneratedOnAdd();
            
            builder.HasOne(c => c.ItemVendorLink)
                .WithMany(c => c.TransactionItemVendors)
                .HasForeignKey(c => c.ItemVendorId);
        }
    }
}