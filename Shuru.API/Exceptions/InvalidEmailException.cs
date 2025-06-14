using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid email is encountered.
    /// </summary>
    public class InvalidEmailException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEmailException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidEmailException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.InvalidEmail;
        }
    }
}
