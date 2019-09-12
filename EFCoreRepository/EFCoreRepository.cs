using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace EFCoreRepository
{
    public class EFCoreRepository<T, TContext> : IRepository<T> where TContext : DbContext where T : class
    {
        protected readonly TContext _context;
        public EFCoreRepository(TContext context)
        {
            _context = context;
        }
        protected virtual DbSet<T> _table
        {
            get
            {
                return _context.Set<T>();
            }
        }
        public virtual void Add(T entity)
        {
            _table.Add(entity);
            SaveChanges();
        }

        public async virtual Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual void Delete(T entity)
        {
            _table.Remove(entity);
            SaveChanges();
        }

        public async virtual Task DeleteAsync(T entity)
        {
            _table.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).ToList();
        }

        public virtual IEnumerable<Target> Query<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector)
        {
            return _table.Where(predicate).Select(selector).ToList();
        }

        public virtual IEnumerable<T> Query(Expression<Func<T, bool>> predicate, int page, int pageSize)
        {
            CheckPage(page);
            return _table.Where(predicate).Skip(GetSkipCount(page, pageSize)).Take(pageSize).ToList();
        }

        public virtual IEnumerable<T> QueryAll()
        {
            return _table.ToList();
        }

        public virtual IEnumerable<Target> QueryAll<Target>(Expression<Func<T, Target>> selector)
        {
            return _table.Select(selector).ToList();
        }

        public async virtual Task<IEnumerable<T>> QueryAllAsync()
        {
            var list = await _table.ToListAsync();
            return list;
        }

        public async virtual Task<IEnumerable<Target>> QueryAllAsync<Target>(Expression<Func<T, Target>> selector)
        {
            var list = await _table.Select(selector).ToListAsync();
            return list;
        }

        public async virtual Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate)
        {
            var list = await _table.Where(predicate).ToListAsync();
            return list;
        }

        public async virtual Task<IEnumerable<Target>> QueryAsync<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector)
        {
            var list = await _table.Where(predicate).Select(selector).ToListAsync();
            return list;
        }

        public async virtual Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> predicate, int page, int pageSize)
        {
            CheckPage(page);
            var list = await _table.Where(predicate).Skip(GetSkipCount(page, pageSize)).Take(pageSize).ToListAsync();
            return list;
        }

        public async virtual Task<IEnumerable<Target>> QueryAsync<Target>(Expression<Func<T, bool>> predicate, Expression<Func<T, Target>> selector, int page, int pageSize)
        {
            CheckPage(page);
            var list = await _table.Where(predicate).Select(selector).Skip(GetSkipCount(page, pageSize)).Take(pageSize).ToListAsync();
            return list;
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public virtual void Update(T entity)
        {
            _table.Update(entity);
            SaveChanges();
        }

        public async virtual Task UpdateAsync(T entity)
        {
            _table.Update(entity);
            await SaveChangesAsync();
        }
        private int GetSkipCount(int page, int pageSize)
        {
            return (page - 1) + pageSize;
        }
        private void CheckPage(int page)
        {
            if (page <= 0)
            {
                throw new ArgumentException(nameof(page));
            }
        }
    }
}
