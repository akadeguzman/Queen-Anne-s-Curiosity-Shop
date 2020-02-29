using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ItemAvailabilityConfig : IEntityTypeConfiguration<ItemAvailability>
    {
        public void Configure(EntityTypeBuilder<ItemAvailability> builder)
        {
            builder.ToTable("ItemAvailability");

            builder.HasKey(c => c.ItemAvailabilityId);
            builder.Property(c => c.ItemAvailabilityId).ValueGeneratedOnAdd();
        }
    }
}