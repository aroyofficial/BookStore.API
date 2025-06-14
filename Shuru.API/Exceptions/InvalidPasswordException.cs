using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the provided password is invalid.
    /// </summary>
    public class InvalidPasswordException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPasswordException"/> class 
        /// with a default error message indicating an invalid password.
        /// </summary>
        public InvalidPasswordException()
            : base("Invalid password.")
        {
            ErrorCode = ErrorCode.InvalidPassword;
        }
    }
}
