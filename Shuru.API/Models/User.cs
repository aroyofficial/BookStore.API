namespace Shuru.API.Models
{
    /// <summary>
    /// Represents a user in the system.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// The name of the user.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// The unique email address of the user.
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// The hashed password for authentication.
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
