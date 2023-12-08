using CFG.WebApi.Models;
using CFG.WebApi.Services.CountryServices;
using Microsoft.AspNetCore.Mvc;

namespace CFG.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController
    {
        private readonly ICountryService businessService;


        public CountryController(ILogger<CountryController> controllerLogger, ICountryService countryService)
        {
            logger = controllerLogger;
            businessService = countryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCountries()
        {
            return await ToApiResponse<IAsyncEnumerable<Country>>(() => businessService.GetCountries());
        }
    }
}
