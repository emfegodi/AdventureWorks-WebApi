using AdventureWorks.NetCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository.IRepository
{
   public interface IProductRepository :IRepository<Product>
    {
        void Update(Product product);      
        IEnumerable<Product> GetById(int id);
        void Delete(Product product);    
    }
}
