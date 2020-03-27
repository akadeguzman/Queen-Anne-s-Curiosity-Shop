using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class TransactionItemConfig : IEntityTypeConfiguration<TransactionItem>
    {
        public void Configure(EntityTypeBuilder<TransactionItem> builder)
        {
            builder.ToTable("TransactionItem");

            builder.HasKey(c => c.TransactionItemId);
            builder.Property(c => c.TransactionItemId).ValueGeneratedOnAdd();
            
            builder.HasOne(c => c.ItemVendorLink)
                .WithMany(c => c.TransactionItems)
                .HasForeignKey(c => c.ItemVendorId);
        }
    }
}