using Core.Entities;

namespace Core.Interfaces.Countries
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<bool> Exist(Guid id);
    }
}
