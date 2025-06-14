namespace Shuru.API.DTOs.Response
{
    /// <summary>
    /// Represents the response returned after a successful login operation.
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// Gets or sets the JSON Web Token (JWT) access token generated for the authenticated user.
        /// </summary>
        public string AccessToken { get; set; } = null!;

        /// <summary>
        /// Gets or sets the date and time when the access token will expire.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the user information associated with the login response.
        /// </summary>
        public UserResponse User { get; set; } = null!;
    }
}
