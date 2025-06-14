using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Exception thrown when the start date is later than the end date in the published date range.
    /// </summary>
    public class PublishedDateRangeInvalidException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PublishedDateRangeInvalidException"/> class with a default error message.
        /// </summary>
        public PublishedDateRangeInvalidException()
            : base("The start date cannot be after the end date in the published date range.")
        {
            ErrorCode = ErrorCode.InvalidPublishedDateRange;
        }
    }
}
