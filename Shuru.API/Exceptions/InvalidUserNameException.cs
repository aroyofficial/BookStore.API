using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the provided username is invalid.
    /// </summary>
    public class InvalidUserNameException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserNameException"/> class 
        /// with a specified error message that describes the invalid username error.
        /// </summary>
        /// <param name="message">The error message that explains why the username is invalid.</param>
        public InvalidUserNameException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.InvalidUserName;
        }
    }
}
