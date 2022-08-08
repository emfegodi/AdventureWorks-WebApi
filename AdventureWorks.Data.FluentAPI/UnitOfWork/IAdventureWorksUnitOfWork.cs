using AdventureWorks.Data.FluentAPI.Infrastructure;

namespace AdventureWorks.Data.FluentAPI.UnitOfWork
{
    public interface IAdventureWorksUnitOfWork : IUnitOfWork
    {
        public IRepository<Address> AddressRepository { get; }
    }
}
