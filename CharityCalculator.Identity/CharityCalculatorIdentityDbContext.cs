using CharityCalculator.Identity.Configurations;
using CharityCalculator.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Identity
{
    public class CharityCalculatorDbIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public CharityCalculatorDbIdentityContext(DbContextOptions<CharityCalculatorDbIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
