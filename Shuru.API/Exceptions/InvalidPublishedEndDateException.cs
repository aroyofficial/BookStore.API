using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the end date of the published date range is in the future.
    /// </summary>
    public class InvalidPublishedEndDateException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidPublishedEndDateException"/> class with a default error message.
        /// </summary>
        public InvalidPublishedEndDateException()
            : base("The end date of the published date range cannot be a future date.")
        {
            ErrorCode = ErrorCode.InvalidPublishedEndDate;
        }
    }
}
