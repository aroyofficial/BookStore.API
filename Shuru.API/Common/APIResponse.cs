using Shuru.API.Enumerations;

namespace Shuru.API.Common
{
    /// <summary>
    /// Represents a standard API response model with success status, message, data, and error list.
    /// </summary>
    /// <typeparam name="T">The type of the data payload returned in the response.</typeparam>
    public class APIResponse<T>
    {
        /// <summary>
        /// Indicates whether the API operation was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public ErrorCode? ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; } = null!;

        /// <summary>
        /// The data payload of the API response.
        /// </summary>
        public T Data { get; set; }
    }
}
