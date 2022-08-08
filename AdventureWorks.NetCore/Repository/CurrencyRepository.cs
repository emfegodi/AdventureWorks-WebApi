using AdventureWorks.NetCore.Repository.IRepository;
using AdventureWorks.NetCore.Repository.Models;

namespace AdventureWorks.NetCore.Repository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private MoDbContext _db;

        public CurrencyRepository(MoDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Currency cur)
        {
            _db.Currencies.Update(cur);
        }
        public IEnumerable<Currency> GetById(string id)
        {
            var res = _db.Currencies.Find(id);
            yield return res;

        }
        public void Delete(Currency cur)
        {
            _db.Currencies.Remove(cur);
        }

    }
}
