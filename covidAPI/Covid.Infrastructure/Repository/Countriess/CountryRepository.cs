using Core.Data;
using Core.Entities;
using Core.Interfaces.Countries;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Countrys
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        private readonly AppDbContext _db;
        public CountryRepository(AppDbContext dbContext): base(dbContext){ _db = dbContext; }
        public async Task<bool> Exist(Guid id)
        {
            var query =  await _db.Country.Where(x => x.Id == id).AnyAsync();
            return query;
        }
    }
}
