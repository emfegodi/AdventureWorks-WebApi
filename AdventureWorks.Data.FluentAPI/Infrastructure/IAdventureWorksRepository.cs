namespace AdventureWorks.Data.FluentAPI.Infrastructure
{
    public interface IAdventureWorksRepository : IRepository<Address>
    {
        IEnumerable<Address> GetTop(int count);          

    }
}
