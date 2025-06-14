using Shuru.API.DTOs.Request;
using Shuru.API.DTOs.Response;

namespace Shuru.API.Services.Interfaces
{
    /// <summary>
    /// Provides business logic operations related to user management.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registers a new user with the provided user information.
        /// </summary>
        /// <param name="request">The request containing user details for registration.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a <see cref="UserResponse"/> with the registered user information.
        /// </returns>
        Task<UserResponse> Register(RegistrationRequest request);

        /// <summary>
        /// Authenticates a user and generates an access token upon successful login.
        /// </summary>
        /// <param name="request">The request containing user login credentials.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a <see cref="LoginResponse"/> with the authentication token and user information.
        /// </returns>
        Task<LoginResponse> Login(LoginRequest request);

        /// <summary>
        /// Retrieves a user's profile based on the specified user identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>
        /// A task representing the asynchronous operation, containing a <see cref="UserResponse"/> with the user's profile information.
        /// </returns>
        Task<UserResponse> GetUserProfile(int id);
    }
}
