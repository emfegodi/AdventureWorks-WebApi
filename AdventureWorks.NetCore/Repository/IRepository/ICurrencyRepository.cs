using System.Collections;
using AdventureWorks.NetCore.Repository.Models;

namespace AdventureWorks.NetCore.Repository.IRepository
{
    public interface ICurrencyRepository : IRepository<Currency>    
    {
        void Update(Currency cur);
        IEnumerable<Currency> GetById(string id);
        void Delete(Currency cur);
    }
}
