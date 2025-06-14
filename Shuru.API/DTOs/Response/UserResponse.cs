namespace Shuru.API.DTOs.Response
{
    /// <summary>
    /// Represents the user information returned in API responses.
    /// </summary>
    public class UserResponse : BaseDTO
    {
        /// <summary>
        /// Gets or sets the user's display name.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email { get; set; } = null!;
    }
}
