using Microsoft.EntityFrameworkCore;
using AdventureWorks.Data.FluentAPI.Context;
using AdventureWorks.Data.FluentAPI.Infrastructure;


namespace AdventureWorks.Data.FluentAPI.UnitOfWork
{
    public class AdventureWorksUnitOfWork :UnitOfWork, IAdventureWorksUnitOfWork
    {
        public AdventureWorksUnitOfWork(DbContext context,
            IRepository<Address> addressRepository)
            : base((AdventureWorks2019Context)context)
        {
            AddressRepository = addressRepository;
        }

        public IRepository<Address> AddressRepository { get; }
            
    }
}
