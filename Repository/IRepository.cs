using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        void Delete(T entity);
        Task DeleteAsync(T entity);
        void Update(T entity);
        Task UpdateAsync(T entity);
        IEnumerable<T> QueryAll();
        Task<IEnumerable<T>> QueryAllAsync();
        IEnumerable<Target> QueryAll<Target>(Expression<Func<T, Target>> selector);
        Task<IEnumerable<Target>> QueryAllAsync<Target>(Expression<Func<T, Target>> selector);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<Target> Query<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector);
        Task<IEnumerable<Target>> QueryAsync<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate, int page, int pageSize);
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, int page, int pageSize);
        Task<IEnumerable<Target>> QueryAsync<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector, int page, int pageSize);
        int SaveChanges();
        Task<int> SaveChangesAsync();

    }
}
