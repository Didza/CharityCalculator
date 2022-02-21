using CharityCalculator.Application.Contracts.Persistence;
using CharityCalculator.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CharityCalculator.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("useInMemoryDb"))
            {
                services.AddDbContext<CharityCalculatorSqliteDbContext>(options =>
                    options.UseSqlite(
                        configuration.GetConnectionString("CharityCalculatorSqliteConnectionString")));
            } else
            {
                services.AddDbContext<CharityCalculatorDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("CharityCalculatorConnectionString")));
            }

           
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<,>));
            if (configuration.GetValue<bool>("useInMemoryDb"))
            {
                services.AddScoped<IUnitOfWork, UnitOfWork<CharityCalculatorSqliteDbContext>>();
            }
            else
            {
                services.AddScoped<IUnitOfWork, UnitOfWork<CharityCalculatorDbContext>>();
            }

            return services;
        }
    }
}
