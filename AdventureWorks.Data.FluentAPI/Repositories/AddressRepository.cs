using AdventureWorks.Data.FluentAPI.Infrastructure;
using AdventureWorks.Data.FluentAPI.Context;

namespace AdventureWorks.Data.FluentAPI.Repositories
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(AdventureWorks2019Context context) : base(context)
        {
        }
    }
}
