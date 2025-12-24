using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Application.InterfacesRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null);
    }
}
