using CFG.WebApi.Common;
using CFG.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CFG.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ILogger? logger;


        protected async Task<IActionResult> ToApiResponse<T>(Func<Task<T>> methodName, bool handleFile = false)
        {
            var apiResponse = new ApiResponse<T>();
            apiResponse.DidError = false;
            try
            {
                var result = await methodName();
                apiResponse.Data = result;
            }
            catch (ServiceException bex)
            {
                apiResponse.DidError = true;
                logger.LogInformation(bex.Message, bex);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message, ex);
#if DEBUG
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
#else
                 no information exposure

                return StatusCode(StatusCodes.Status500InternalServerError);
#endif
            }

            return Ok(apiResponse);
        }
    }
}
