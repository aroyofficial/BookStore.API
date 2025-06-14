using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when no user is found for the provided username or email.
    /// </summary>
    public class UserNotFoundException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class 
        /// with a specified identifier indicating which field was used for the lookup.
        /// </summary>
        /// <param name="identifier">The field name (e.g., username or email) that was used in the search.</param>
        public UserNotFoundException(string identifier)
            : base($"No user found with the provided {identifier}.")
        {
            ErrorCode = ErrorCode.UserNotFound;
        }
    }
}
