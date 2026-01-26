using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoManage.API.Controllers.Base
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult OkResponse(object? result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        protected IActionResult CreatedResponse(object? result = null)
        {
            return StatusCode(StatusCodes.Status201Created, result);
        }

        protected IActionResult NoContentResponse()
        {
            return NoContent();
        }
    }
}
