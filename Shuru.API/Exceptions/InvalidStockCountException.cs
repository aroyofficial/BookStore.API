using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the stock count of the book is invalid (negative).
    /// </summary>
    public class InvalidStockCountException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidStockCountException"/> class with a default error message.
        /// </summary>
        public InvalidStockCountException()
            : base("The stock count cannot be negative.")
        {
            ErrorCode = ErrorCode.BookInvalidStockCount;
        }
    }
}
