using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CharityCalculator.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CharityCalculator.Persistence.Repositories
{
    public class GenericRepository<T, U> : IGenericRepository<T> where U : DbContext where T : class
    {
        private readonly BaseContext<U> _dbContext;

        public GenericRepository(BaseContext<U> dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> Get(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
