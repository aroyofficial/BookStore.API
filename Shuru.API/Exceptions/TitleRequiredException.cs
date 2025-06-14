using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the book title is missing or empty.
    /// </summary>
    public class TitleRequiredException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TitleRequiredException"/> class with a default error message.
        /// </summary>
        public TitleRequiredException()
            : base("The book title is required.")
        {
            ErrorCode = ErrorCode.BookTitleRequired;
        }
    }
}
