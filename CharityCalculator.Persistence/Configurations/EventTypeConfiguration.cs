using CharityCalculator.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharityCalculator.Persistence.Configurations
{
    public class EventTypeConfiguration : IEntityTypeConfiguration<EventType>
    {
        public void Configure(EntityTypeBuilder<EventType> builder)
        {
            builder.HasData(
                new EventType("Sports", 5, 100000),
                new EventType("Political", 3, 100000),
                new EventType("Other", 0, 100000)
            );
        }
    }
}
