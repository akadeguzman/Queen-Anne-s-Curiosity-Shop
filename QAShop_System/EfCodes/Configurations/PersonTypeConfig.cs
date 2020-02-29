using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class PersonTypeConfig : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.ToTable("PersonType");

            builder.HasKey(c => c.PersonTypeId);
            builder.Property(c => c.PersonTypeId).ValueGeneratedOnAdd();
        }
    }
}