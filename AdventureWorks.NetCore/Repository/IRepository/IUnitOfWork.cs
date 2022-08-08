using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAddressRepository Address {  get; }
        IProductRepository Product { get; }
        ICurrencyRepository Currency { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<int> ExecuteSqlCommandAsync(string sql, params object[] parameters);
        Task<int> ExecuteSqlCommandAsync(string sql, CancellationToken cancellationToken, params object[] parameters);
        void Save();
    }
}
