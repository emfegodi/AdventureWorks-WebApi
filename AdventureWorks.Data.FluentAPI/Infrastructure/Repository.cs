using System.Linq.Expressions;
using AdventureWorks.Data.FluentAPI.Context;

namespace AdventureWorks.Data.FluentAPI.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AdventureWorks2019Context _context;
        public Repository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        /// <summary>
        /// Adds a new record to AdventureWorksContext
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        /// <summary>
        /// Adds a list of records to AdventureWorksContext
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<T> entities)
        {
           _context.Set<T>().AddRange(entities);
        }
        /// <summary>
        /// Finds a set of records
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        /// <summary>
        /// returns a list of records
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        /// <summary>
        /// returns a simple object depending on the id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        /// <summary>
        /// Removes a record from the context
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        /// <summary>
        /// Removes a list of records.
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }
}
