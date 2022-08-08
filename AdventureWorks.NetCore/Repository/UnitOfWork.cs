using AdventureWorks.NetCore.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MoDbContext _context;
        public UnitOfWork(MoDbContext context)
        {
            _context = context;
            Address = new AddressRepository(_context);
            Product = new ProductRepository(_context);
            Currency = new CurrencyRepository(_context);
        }
        public IAddressRepository Address { get; set; }
        public IProductRepository Product { get; set; }
        public ICurrencyRepository Currency { get; set; }

        #region Methods
        public void  Save() => _context.SaveChanges();
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
        #endregion

    }
}
