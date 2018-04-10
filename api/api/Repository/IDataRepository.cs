using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace api.Repository
{
    public interface IDataRepository<T> : IDisposable where T : class
    {
        void Add(T entity);

        Task<int> AddAndSaveAsync(T entity);
                
        void Update(T entity);

        Task Create(T item);

        Task<int> UpdateAndSaveAsync(T entity);

        void Remove(T entity);

        Task<int> RemoveAndSaveAsync(T entity);

        Task<int> SaveAsync();

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> ToListAsync();

        Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate);
                
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        Task ClearAsnyc();

        Task ClearAndSaveAsnyc();
    }
}
