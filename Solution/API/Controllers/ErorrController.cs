using API.Error;
using API.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errorhandler")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErorrController : ControllerBase
    {
        [Route("error-development")]

        public IActionResult ErorrDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {

            if(!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exptionHandlerFeature?.Error.InnerException?.StackTrace,
                title: exptionHandlerFeature?.Error.Message
                );
            //return new ObjectResult(new FailResponse(code));
        }
        [Route("error")]
        public IActionResult Erorr()
        {
            return Problem();
            //return new ObjectResult(new FailResponse(code));
        }
    }
}