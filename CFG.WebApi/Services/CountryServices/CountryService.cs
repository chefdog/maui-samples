using CFG.WebApi.Common;
using CFG.WebApi.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CFG.WebApi.Services.CountryServices
{
    public class CountryService : ICountryService
    {
        private readonly AppSettings appSettings;
        public CountryService(IOptions<AppSettings> options)
        {
            appSettings = options.Value;
        }


        public async Task<IAsyncEnumerable<Country>> GetCountries()
        {

            var filePath = $"{appSettings.DataPath}/countries.json";

            using var jsonStream = File.OpenRead(filePath);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var countries = await JsonSerializer.DeserializeAsync<IAsyncEnumerable<Country>>(jsonStream, options);

            if (countries == null)
            {
                throw new Exception("Could not fetch any data");
            }

            return countries;
        }
    }
}
