namespace Shuru.API.Enumerations
{
    /// <summary>
    /// Represents standardized error codes used throughout the application for various exception scenarios.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Indicates that internally something went wrong.
        /// </summary>
        InternalServerError = 500,

        #region user module exceptions
        /// <summary>
        /// Indicates that the provided email address is not in a valid format.
        /// </summary>
        InvalidEmail = 1001,

        /// <summary>
        /// Indicates that the provided password is invalid or does not meet the required format.
        /// </summary>
        InvalidPassword = 1002,

        /// <summary>
        /// Indicates that the request is malformed or contains invalid parameters.
        /// </summary>
        InvalidRequest = 1003,

        /// <summary>
        /// Indicates a failure occurred during user creation due to invalid or incomplete data.
        /// </summary>
        InvalidUserCreation = 1004,

        /// <summary>
        /// Indicates that the username is invalid or does not meet the required format.
        /// </summary>
        InvalidUserName = 1005,

        /// <summary>
        /// Indicates that required credentials are missing from the request.
        /// </summary>
        MissingCredentials = 1006,

        /// <summary>
        /// Indicates that a user with the given email or username already exists.
        /// </summary>
        UserAlreadyExists = 1007,

        /// <summary>
        /// Indicates that the requested user could not be found in the system.
        /// </summary>
        UserNotFound = 1008,

        /// <summary>
        /// Indicates that the provided password is too weak or does not meet complexity requirements.
        /// </summary>
        WeakPassword = 1009,
        #endregion user module exceptions

        #region book module exceptions
        /// <summary>
        /// Indicates that the book title is missing or empty.
        /// </summary>
        BookTitleRequired = 2001,

        /// <summary>
        /// Indicates that the book author is missing or empty.
        /// </summary>
        BookAuthorRequired = 2002,

        /// <summary>
        /// Indicates that the price of the book is invalid (less than 1).
        /// </summary>
        BookInvalidPrice = 2003,

        /// <summary>
        /// Indicates that the published date of the book is invalid (future date).
        /// </summary>
        BookInvalidPublishedDate = 2004,

        /// <summary>
        /// Indicates that the stock count of the book is invalid (negative).
        /// </summary>
        BookInvalidStockCount = 2005,

        /// <summary>
        /// Indicates that the published start date in the search filter is invalid (future date).
        /// </summary>
        InvalidPublishedStartDate = 2006,

        /// <summary>
        /// Indicates that the published end date in the search filter is invalid (future date).
        /// </summary>
        InvalidPublishedEndDate = 2007,

        /// <summary>
        /// Indicates that the published date range is invalid because the start date is after the end date.
        /// </summary>
        InvalidPublishedDateRange = 2008,
        #endregion book module exceptions
    }
}
