using AdventureWorks.Data.FluentAPI.Context;
using AdventureWorks.Data.FluentAPI.Repositories;
using AdventureWorks.Data.FluentAPI;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data.FluentAPI.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
     
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;        
           
        }

        public virtual int SaveChanges() => _context.SaveChanges();
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        public virtual int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _context.Database.ExecuteSqlRaw(sql, parameters);
        }
        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, parameters);
        }

        public virtual async Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters)
        {
            return await _context.Database.ExecuteSqlRawAsync(sql, cancellationToken, parameters);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
