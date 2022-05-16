using Core.Entities;
using Core.Interfaces.Countries;
using Covid.Application.Interfaces;
using Covid.Core.ViewModel;
using Newtonsoft.Json;
using RestSharp;

namespace Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository) { _countryRepository = countryRepository; }

        public List<CountryViewModel> getCountries(DateTime startDate, int WeekCount)
        {
            var result = new List<CountryViewModel>();

            var now = DateTime.Now;
            var range = now.AddDays(-180);
            var path = $"https://api.covid19api.com/country/brazil?from={range.ToString("yyyy-MM-dd")}&to={now.ToString("yyyy-MM-dd")}";

            var client = new RestClient(path);
            RestRequest request = new RestRequest("", Method.Get);
            var response = client.ExecuteAsync<Country>(request).Result;
            IEnumerable<Country> covidData = JsonConvert.DeserializeObject<IEnumerable<Country>>(response.Content);
            
            if (!_countryRepository.Exist(covidData.Select(x => x.Id).First()).Result)
            {
                _countryRepository.AddRange(covidData);
            }

            var weeks = ReturnLastWeeks(startDate, WeekCount);
            var resultCovidContries = _countryRepository.GetAll();

            for (int i = 0; i < WeekCount; i++)
            {
                var weekConfirmedCases =
                    resultCovidContries.Where(c => c.Date <= weeks.StartDate[i] && c.Date >= weeks.EndDate[i])
                    .Select(c => c.Confirmed).ToList();

                var weekDeathCases =
                    resultCovidContries.Where(c => c.Date <= weeks.StartDate[i] && c.Date >= weeks.EndDate[i])
                    .Select(c => c.Deaths).ToList();

                float movingAverageCases = ((weekConfirmedCases.Sum()) / 7);
                float movingAverageDeaths = ((weekDeathCases.Sum()) / 7);

                result.Add(new CountryViewModel
                {
                    Week = i,
                    Cases = movingAverageCases,
                    Deaths = movingAverageDeaths,
                    StartDate = weeks.StartDate[i],
                    EndtDate = weeks.EndDate[i],
                });
            }    

            return result;
        }

        public LastWeeks ReturnLastWeeks(DateTime startDate, int weekCount)
        {
            var result = new LastWeeks();

            List<DateTime> startDateTime = new List<DateTime>();
            List<DateTime> endDateTime = new List<DateTime>();

            startDateTime.Add(startDate.AddDays(-1));
            endDateTime.Add(startDate.AddDays(-7));

            for (int i = 0; i < weekCount; i++)
            {
                var start = startDateTime.Last();
                var end = endDateTime.Last();
                startDateTime.Add(start.AddDays(-7));
                endDateTime.Add(end.AddDays(-7));
            }
            result = new LastWeeks
            {
                StartDate = startDateTime,
                EndDate = endDateTime
            };
            return result;
        }
    }
}
