using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the user creation request is invalid.
    /// </summary>
    public class InvalidUserCreationRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserCreationRequestException"/> class
        /// with a default error message indicating that the username, email, and password are required.
        /// </summary>
        public InvalidUserCreationRequestException()
            : base("User creation request is invalid. Username, Email, and Password are required.")
        {
            ErrorCode = ErrorCode.InvalidUserCreation;
        }
    }
}
