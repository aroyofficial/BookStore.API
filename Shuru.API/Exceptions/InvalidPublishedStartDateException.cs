using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the start date of the published date range is in the future.
    /// </summary>
    public class InvalidPublishedStartDateException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPublishedStartDateException"/> class with a default error message.
        /// </summary>
        public InvalidPublishedStartDateException()
            : base("The start date of the published date range cannot be a future date.")
        {
            ErrorCode = ErrorCode.InvalidPublishedStartDate;
        }
    }
}
