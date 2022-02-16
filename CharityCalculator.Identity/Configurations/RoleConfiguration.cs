using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharityCalculator.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "BFCC8834-648D-4439-B6E9-CD78FC42EEA9",
                    Name = "Donor",
                    NormalizedName = "DONOR"
                },
                new IdentityRole
                {
                    Id = "FF66F091-86B1-45EE-AC1C-A5AA7E54C55A",
                    Name = "EventPromoter",
                    NormalizedName = "EVENTPROMOTER"
                },
                new IdentityRole
                {
                    Id = "0653CBA6-A166-4EA9-A0FC-1E35463B02E8",
                    Name = "SiteAdministrator",
                    NormalizedName = "SITEADMINISTRATOR"
                }
            );
        }
    }
}
