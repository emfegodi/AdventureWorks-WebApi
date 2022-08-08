using AdventureWorks.NetCore.Repository.IRepository;
using AdventureWorks.NetCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository
{
    public class AddressRepository : Repository<Address>,IAddressRepository
    {
        private MoDbContext _db;

        public AddressRepository(MoDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Address address)
        {
            _db.Addresses.Update(address);
        }
        public IEnumerable<Address> GetById(int id)
        {
           var res= _db.Addresses.Find(id);
            yield return res;

        }
        public void Delete(Address address)
        {
            _db.Addresses.Remove(address);
        }


    }
}
