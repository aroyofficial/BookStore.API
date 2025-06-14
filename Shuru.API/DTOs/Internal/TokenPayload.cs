namespace Shuru.API.DTOs.Internal
{
    /// <summary>
    /// Represents the user information required for generating a token.
    /// </summary>
    public class TokenPayload
    {
        /// <summary>
        /// Gets or sets the unique user identifier.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user's email address.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user's username.
        /// </summary>
        public string UserName { get; set; } = null!;
    }
}
