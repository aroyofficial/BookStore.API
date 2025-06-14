using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the price of the book is invalid.
    /// </summary>
    public class InvalidPriceException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPriceException"/> class with a default error message.
        /// </summary>
        public InvalidPriceException()
            : base("The price must be greater than or equal to 1.") 
        {
            ErrorCode = ErrorCode.BookInvalidPrice;
        }
    }
}
