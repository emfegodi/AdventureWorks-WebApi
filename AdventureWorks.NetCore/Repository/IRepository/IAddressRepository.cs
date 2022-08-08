using AdventureWorks.NetCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository.IRepository
{
   public interface IAddressRepository :IRepository<Address>
    {
        void Update(Address address);      
        IEnumerable<Address> GetById(int id);
        void Delete(Address address);    
    }
}
