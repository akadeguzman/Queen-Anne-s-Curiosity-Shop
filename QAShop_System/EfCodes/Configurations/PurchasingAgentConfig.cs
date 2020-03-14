using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class PurchasingAgentConfig : IEntityTypeConfiguration<PurchasingAgent>
    {
        public void Configure(EntityTypeBuilder<PurchasingAgent> builder)
        {
            builder.ToTable("PurchasingAgent");

            builder.HasKey(c => c.PurchasingAgentId);
            builder.Property(c => c.PurchasingAgentId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.PersonLink)
                .WithMany(c => c.PurchasingAgents)
                .HasForeignKey(c => c.PersonId);

        }
    }
}