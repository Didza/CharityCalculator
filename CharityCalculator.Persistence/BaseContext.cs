using CharityCalculator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence
{
    public interface IBaseContext<T>  where T : DbContext
    {
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
    public class BaseContext<T> : DbContext where T : DbContext, IBaseContext<T>
    {
        public BaseContext(DbContextOptions<T> options): base(options)
        {
                
        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
