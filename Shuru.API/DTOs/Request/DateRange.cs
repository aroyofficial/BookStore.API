namespace Shuru.API.DTOs.Request
{
    /// <summary>
    /// Represents a date range with a start and end date.
    /// </summary>
    public class DateRange
    {
        /// <summary>
        /// Gets or sets the start date of the range.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end date of the range.
        /// </summary>
        public DateTime End { get; set; }
    }
}
