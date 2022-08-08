using AdventureWorks.NetCore.Repository.IRepository;
using AdventureWorks.NetCore.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private MoDbContext _db;

        public ProductRepository(MoDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Product product)
        {
            _db.Products.Update(product);
        }
        public IEnumerable<Product> GetById(int id)
        {
           var res= _db.Products.Find(id);
            yield return res;

        }
        public void Delete(Product products)
        {
            _db.Products.Remove(products);
        }


    }
}
