using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ItemConfig : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(c => c.ItemId);
            builder.Property(c => c.ItemId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.ItemTypeLink)
                .WithMany(c => c.Items)
                .HasForeignKey(c => c.ItemTypeId).IsRequired(true);

            builder.HasOne(c => c.ItemAvailabilityLink)
                .WithMany(c => c.Items)
                .HasForeignKey(c => c.ItemAvailabilityId)
                .IsRequired(true);
        }
    }
}