using AdventureWorks.NetCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository
{
 /// <summary>
 /// Implementacion de Repositorio
 /// </summary>
 /// <typeparam name="T"></typeparam>
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly MoDbContext _db;
            internal DbSet<T> dbSet;

            public Repository(MoDbContext db)
            {
                _db = db;             
                this.dbSet = _db.Set<T>();
            }
        /// <summary>
        /// Agregar entidad 
        /// </summary>
        /// <param name="entity"></param>
            public void Add(T entity)
            {
                dbSet.Add(entity);
            }
         /// <summary>
         /// Devuelve Todos los registros de la entidad
         /// </summary>
         /// <param name="filter"></param>
         /// <param name="includeProperties"></param>
         /// <returns></returns>
            public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
            {
                IQueryable<T> query = dbSet;
                if (filter != null)
                {
                    query = query.Where(filter);
                }
                if (includeProperties != null)
                {
                    foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProp);
                    }
                }
                return query.ToList();
            }
        /// <summary>
        /// Devuelve el primer registro de la entidad
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="includeProperties"></param>
        /// <param name="tracked"></param>
        /// <returns></returns>
            public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
            {
                if (tracked)
                {
                    IQueryable<T> query = dbSet;

                    query = query.Where(filter);
                    if (includeProperties != null)
                    {
                        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(includeProp);
                        }
                    }
                    return query.FirstOrDefault();
                }
                else
                {
                    IQueryable<T> query = dbSet.AsNoTracking();

                    query = query.Where(filter);
                    if (includeProperties != null)
                    {
                        foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            query = query.Include(includeProp);
                        }
                    }
                    return query.FirstOrDefault();
                }

            }
        /// <summary>
        /// Elimina la entidad
        /// </summary>
        /// <param name="entity"></param>
            public void Remove(T entity)
            {
                dbSet.Remove(entity);
            }
        /// <summary>
        /// Elimina un rango entidades
        /// </summary>
        /// <param name="entity"></param>
            public void RemoveRange(IEnumerable<T> entity)
            {
                dbSet.RemoveRange(entity);
            }
        }
    
}
