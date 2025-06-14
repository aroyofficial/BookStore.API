using Microsoft.AspNetCore.Mvc;
using Shuru.API.Attributes;

namespace Shuru.API.Controllers
{
    /// <summary>
    /// Base controller for all API controllers in the application.
    /// Applies the <see cref="APIExceptionFilterAttribute"/> for consistent exception handling.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [APIExceptionFilter]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        public BaseController()
        {
        }
    }
}
