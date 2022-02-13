using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CharityCalculator.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
