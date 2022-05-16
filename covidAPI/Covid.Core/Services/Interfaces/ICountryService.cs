using Covid.Core.ViewModel;
using System.Collections.Generic;

namespace Covid.Application.Interfaces
{
    public interface ICountryService
    {
        List<CountryViewModel> getCountries(DateTime startDate, int WeekCount);
    }
}
