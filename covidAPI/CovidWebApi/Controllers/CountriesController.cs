using Covid.Application.Interfaces;
using Covid.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace CovidWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService) { _countryService = countryService; }

        [HttpGet]
        public IEnumerable<CountryViewModel> Get(DateTime startDate, int WeekCount)
        {
            return _countryService.getCountries(startDate, WeekCount); 
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("averages")]
        public object Post([FromBody] string value)
        {
            return null;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
