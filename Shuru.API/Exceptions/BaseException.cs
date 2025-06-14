using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents the base exception type for application-specific exceptions.
    /// All custom exceptions in the application should inherit from this class.
    /// </summary>
    public abstract class BaseException : Exception
    {
        /// <summary>
        /// The error code.
        /// </summary>
        public ErrorCode ErrorCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        protected BaseException(string message)
            : base(message)
        {
        }
    }
}
