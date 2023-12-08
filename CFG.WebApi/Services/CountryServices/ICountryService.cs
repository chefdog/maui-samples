using CFG.WebApi.Models;

namespace CFG.WebApi.Services.CountryServices
{
    public interface ICountryService
    {

        Task<IAsyncEnumerable<Country>> GetCountries();
    }
}
