using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the book author is missing or empty.
    /// </summary>
    public class AuthorRequiredException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorRequiredException"/> class with a default error message.
        /// </summary>
        public AuthorRequiredException()
            : base("The book author is required.")
        {
            ErrorCode = ErrorCode.BookAuthorRequired;
        }
    }
}
