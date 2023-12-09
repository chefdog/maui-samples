using CFG.MauiSampleApp.Models;

namespace CFG.MauiSampleApp.Services
{
    public interface ICountryService
    {
        Task<IAsyncEnumerable<Country>> GetCountries();
    }
}
