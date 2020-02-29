using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class ProcurementConfig : IEntityTypeConfiguration<Procurement>
    {
        public void Configure(EntityTypeBuilder<Procurement> builder)
        {
            builder.ToTable("Procurement");

            builder.HasKey(c => c.ProcurementId);
            builder.Property(c => c.ProcurementId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.PersonLink)
                .WithMany(c => c.Procurements)
                .HasForeignKey(c => c.PersonId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ShipmentItemLink)
                .WithMany(c => c.Procurements)
                .HasForeignKey(c => c.ShipmentItemVendorId)
                .IsRequired(true).OnDelete(DeleteBehavior.Restrict);
        }
    }
}