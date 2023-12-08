using CFG.MauiSampleApp.Models;
using System.Net.Http.Json;

namespace CFG.MauiSampleApp.Services
{

    /// <remarks>
    /// TODO: this setup only works on windows app, so todo is handling service for all platforms
    /// </remarks>
    public class CountryService : ICountryService
    {
        private string apiUrl;
        private IEnumerable<Country> data;

        HttpClient httpClient;


        public CountryService()
        {
            httpClient = new HttpClient();

            apiUrl = $"{AppSettings.ApiUrl}/country";
            data = new List<Country>();
        }

        public async Task<IAsyncEnumerable<Country>> GetCountries(CancellationToken token)
        {
            var response = await httpClient.GetAsync(this.apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<IAsyncEnumerable<Country>>>();
                if (apiResponse != null && apiResponse.Data != null)
                {
                    return apiResponse.Data;
                }
            }
            return null;
        }
    }
}
