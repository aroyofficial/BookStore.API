namespace Shuru.API.DTOs.Request
{
    /// <summary>
    /// Represents the data required for user registration operation.
    /// </summary>
    public class RegistrationRequest
    {
        /// <summary>
        /// Gets or sets the username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the user's email address. This must be unique.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the user's password used for authentication.
        /// </summary>
        public string Password { get; set; }
    }
}
