using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityTypeConfigurations
{
    public class PriceListNoteConfiguration : IEntityTypeConfiguration<PriceListNote>
    {
        public void Configure(EntityTypeBuilder<PriceListNote> builder)
        {
            builder.HasKey(priceListNote => priceListNote.Id);
            builder.HasIndex(priceListNote => priceListNote.Id).IsUnique();
            builder.Property(priceListNote => priceListNote.Price).HasColumnType("decimal(18, 2)");
        }
    }
}
