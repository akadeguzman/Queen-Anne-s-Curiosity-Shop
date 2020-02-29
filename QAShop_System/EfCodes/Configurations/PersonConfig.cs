using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class PersonConfig : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");

            builder.HasKey(c => c.PersonId);
            builder.Property(c => c.PersonId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.AdditionalContactLink)
                .WithMany(c => c.Persons)
                .HasForeignKey(c => c.AdditionalContactId)
                .IsRequired(false);

            builder.HasOne(c => c.AddressLink)
                .WithMany(c => c.Persons)
                .HasForeignKey(c => c.AddressId);
        }
    }
}