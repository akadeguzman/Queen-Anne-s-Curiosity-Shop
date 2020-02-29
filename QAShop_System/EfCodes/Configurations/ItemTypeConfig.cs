using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ItemTypeConfig : IEntityTypeConfiguration<ItemType>
    {
        public void Configure(EntityTypeBuilder<ItemType> builder)
        {
            builder.ToTable("ItemType");

            builder.HasKey(c => c.ItemTypeId);
            builder.Property(c => c.ItemTypeId).ValueGeneratedOnAdd();
        }
    }
}