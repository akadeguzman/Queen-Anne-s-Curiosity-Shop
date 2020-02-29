using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QAShop_System.EfClasses;

namespace QAShop_System.EfCodes.Configurations
{
    public class TransactionTypeConfig : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.ToTable("TransactionType");

            builder.HasKey(c => c.TransactionTypeId);
            builder.Property(c => c.TransactionTypeId).ValueGeneratedOnAdd();
        }
    }
}