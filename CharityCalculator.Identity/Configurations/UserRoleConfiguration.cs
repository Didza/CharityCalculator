using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharityCalculator.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0653CBA6-A166-4EA9-A0FC-1E35463B02E8",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "BFCC8834-648D-4439-B6E9-CD78FC42EEA9",
                    UserId = "9e224968-33e4-4652-b7b7-8574d048cdb9"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "FF66F091-86B1-45EE-AC1C-A5AA7E54C55A",
                    UserId = "D1E7ACB9-90AA-44E3-AC96-8933A7E3647E"
                }
            );
        }
    }
}
