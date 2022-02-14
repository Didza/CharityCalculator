using CharityCalculator.Domain.Models;
using static CharityCalculator.Domain.Types.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharityCalculator.Persistence.Configurations
{
    public class RateTypeConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasIndex(r => r.RateType).IsUnique();
            builder.HasData(
                new Rate(RateType.TaxRate)
            );
        }
    }
}