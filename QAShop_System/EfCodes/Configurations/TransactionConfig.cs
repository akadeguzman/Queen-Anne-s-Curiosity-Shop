using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class TransactionConfig : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(c => c.TransactionId);
            builder.Property(c => c.TransactionId).ValueGeneratedOnAdd();

            builder.HasOne(c => c.PersonLink)
                .WithMany(c => c.Transactions)
                .HasForeignKey(c => c.PersonId);

            builder.HasOne(c => c.TransactionTypeLink)
                .WithMany(c => c.Transactions)
                .HasForeignKey(c => c.TransactionTypeId)
                .IsRequired(true);
        }
    }
}