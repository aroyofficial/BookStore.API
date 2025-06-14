using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the publication date of the book is invalid (in the future).
    /// </summary>
    public class InvalidPublishedDateException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPublishedDateException"/> class with a default error message.
        /// </summary>
        public InvalidPublishedDateException()
            : base("The published date cannot be a future date.")
        {
            ErrorCode = ErrorCode.BookInvalidPublishedDate;
        }
    }
}
