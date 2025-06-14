namespace Shuru.API.DTOs.Request
{
    /// <summary>
    /// Represents the data required to authenticate a user during the login process.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>
        /// Gets or sets the username of the user attempting to log in.
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the user's account.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password.
        /// </summary>
        public string Password { get; set; }
    }
}
