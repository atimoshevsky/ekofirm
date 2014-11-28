using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Generic
{
    public interface IRepository<T> : IDisposable where T: class
    {
        /// <summary>
        /// Get all objects from Database
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All();

        /// <summary>
        /// Get objects from database by filter
        /// </summary>
        /// <param name="predicate">filter</param>
        /// <returns></returns>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get objects from database with filtering and paging
        /// </summary>
        /// <param name="predicate">filter</param>
        /// <param name="total">total rows</param>
        /// <param name="index">current page</param>
        /// <param name="size">size of the page</param>
        /// <returns></returns>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 50);

        /// <summary>
        /// get the object(s) is existing in the database by filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find object by keys
        /// </summary>
        /// <param name="keys">search keys</param>
        /// <returns></returns>
        T Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression
        /// </summary>
        /// <param name="predicate">expression</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Create a new object in database
        /// </summary>
        /// <param name="t"> new object</param>
        /// <returns></returns>
        T Create(T t);

        /// <summary>
        /// Delete object in the database
        /// </summary>
        /// <param name="t">deleted object</param>
        void Delete(T t);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        void Delete(Expression<Func<T, bool>> predicate);


        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        int Update(T t);

        /// <summary>
        /// Get the total objects count.
        /// </summary>
        int Count {get; }

    }
}
