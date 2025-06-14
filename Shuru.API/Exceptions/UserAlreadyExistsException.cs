using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when a user with the same identifier already exists.
    /// </summary>
    public class UserAlreadyExistsException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAlreadyExistsException"/> class
        /// with a specified identifier indicating which field caused the duplication.
        /// </summary>
        /// <param name="identifier">The field name (e.g., username or email) that caused the conflict.</param>
        public UserAlreadyExistsException(string identifier)
            : base($"User with the same {identifier} already exists")
        {
            ErrorCode = ErrorCode.UserAlreadyExists;
        }
    }
}
