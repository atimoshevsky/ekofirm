using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace DAL.Generic
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private DbSet<T> _dbSet;
        private DbContext _dbContext;

        public Repository(DbContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
            _dbContext = dataContext;
        }

        public virtual IQueryable<T> All()
        {
            return _dbSet.AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable<T>();
        }

        public virtual IQueryable<T> Filter(System.Linq.Expressions.Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;

            var _resetSet = predicate != null ? _dbSet.Where(predicate).AsQueryable() : _dbSet.AsQueryable();

            _resetSet = skipCount == 0 ? _resetSet.Take(size) :
               _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();

            return _resetSet.AsQueryable();
        }

        public virtual bool Contains(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Count(predicate) > 0;
        }

        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        public virtual T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public virtual T Create(T t)
        {
            var newEtity = _dbSet.Add(t);
            return t;
        }

        public virtual void Delete(T t)
        {
            _dbSet.Remove(t);
        }

        public virtual void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            var entities = Filter(predicate);
            _dbSet.RemoveRange(entities);
        }

        public virtual int Update(T t)
        {
            var entry = _dbContext.Entry(t);
            _dbSet.Attach(t);
            entry.State = EntityState.Modified;
            return 1;
        }

        public virtual int Count
        {
            get
            {
                return _dbSet.Count();
            }
        }

        public void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

    }
}
