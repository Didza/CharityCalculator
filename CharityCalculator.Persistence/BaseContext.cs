using System;
using System.Collections.Generic;
using System.Text;
using CharityCalculator.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence
{
    public class BaseContext<T> : DbContext where T : DbContext
    {
        public BaseContext(DbContextOptions<T> options): base(options)
        {
                
        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
