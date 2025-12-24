using Application.InterfacesRepository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        /* ---------------- READ ---------------- */

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            foreach (var include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(
                e => EF.Property<Guid>(e, "Id") == id);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null)
        {
            return predicate == null
                ? _dbSet.AsQueryable()
                : _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        /* ---------------- WRITE ---------------- */

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        /* ---------------- SOFT DELETE ---------------- */

        public void SoftDelete(T entity)
        {
            var isDeletedProp = typeof(T).GetProperty("IsDeleted");
            if (isDeletedProp == null)
                throw new InvalidOperationException(
                    $"{typeof(T).Name} does not support soft delete.");

            isDeletedProp.SetValue(entity, true);

            var deletedAtProp = typeof(T).GetProperty("DeletedAt");
            deletedAtProp?.SetValue(entity, DateTime.UtcNow);

            _dbSet.Update(entity);
        }
    }
}
