using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shuru.API.Common;
using Shuru.API.DTOs.Request;
using Shuru.API.DTOs.Response;
using Shuru.API.Services.Interfaces;

namespace Shuru.API.Controllers
{
    /// <summary>
    /// Controller responsible for managing user-related operations such as registration, login, and profile retrieval.
    /// </summary>
    public class UsersController : BaseController
    {
        private readonly IUserService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="service">The user service instance.</param>
        public UsersController(IUserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retrieves the profile details of a user by their ID.
        /// </summary>
        /// <param name="id">The unique ID of the user.</param>
        /// <returns>Returns the user profile wrapped in a standardized API response.</returns>
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserProfile(int id)
        {
            var response = new APIResponse<UserResponse>();
            response.Data = await _service.GetUserProfile(id);
            response.Success = true;
            return Ok(response);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token upon successful login.
        /// </summary>
        /// <param name="request">The login request containing user credentials.</param>
        /// <returns>Returns the login response containing token and user details.</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = new APIResponse<LoginResponse>();
            response.Data = await _service.Login(request);
            response.Success = true;
            return Ok(response);
        }

        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="request">The registration request containing user details.</param>
        /// <returns>Returns the registered user profile wrapped in a standardized API response.</returns>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var response = new APIResponse<UserResponse>();
            response.Data = await _service.Register(request);
            response.Success = true;
            return Ok(response);
        }
    }
}
