using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CharityCalculator.Domain.Models;
using CharityCalculator.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence
{
    public class CharityCalculatorSqliteDbContext : BaseContext<CharityCalculatorSqliteDbContext>
    {
        public CharityCalculatorSqliteDbContext(DbContextOptions<CharityCalculatorSqliteDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CharityCalculatorSqliteDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.LastModified = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
