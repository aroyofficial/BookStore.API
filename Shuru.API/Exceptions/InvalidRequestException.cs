using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the input request object is null or invalid.
    /// </summary>
    public class InvalidRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidRequestException"/> class 
        /// with a default error message indicating that the request object is null or invalid.
        /// </summary>
        public InvalidRequestException()
            : base("The request object cannot be null or invalid.")
        {
            ErrorCode = ErrorCode.InvalidRequest;
        }
    }
}
