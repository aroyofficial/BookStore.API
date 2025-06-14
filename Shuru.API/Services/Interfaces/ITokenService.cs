using Shuru.API.DTOs.Internal;

namespace Shuru.API.Services.Interfaces
{
    /// <summary>
    /// Defines methods for generating JSON Web Tokens (JWT) for authentication.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JWT token based on the provided token payload.
        /// </summary>
        /// <param name="payload">The payload containing user information required for generating the token.</param>
        /// <returns>
        /// A tuple containing:
        /// <list type="bullet">
        /// <item><description>The generated token string.</description></item>
        /// <item><description>The expiration date and time of the token.</description></item>
        /// </list>
        /// </returns>
        (string, DateTime) GenerateToken(TokenPayload payload);
    }
}
