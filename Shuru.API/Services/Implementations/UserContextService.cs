using Shuru.API.Services.Interfaces;

namespace Shuru.API.Services.Implementations
{
    /// <summary>
    /// Implementation of <see cref="IUserContextService"/> that extracts user-specific information from the current HTTP context.
    /// </summary>
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContextService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">Provides access to the current HTTP context.</param>
        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Retrieves the UserId from the claims present in the current HTTP request context.
        /// </summary>
        /// <returns>The unique identifier of the currently authenticated user.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown if the user ID claim is not found.</exception>
        public Guid GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new UnauthorizedAccessException("No authenticated user context found.");
            }

            var userIdClaim = user.FindFirst("sub");

            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("User ID claim not found in token.");
            }

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
