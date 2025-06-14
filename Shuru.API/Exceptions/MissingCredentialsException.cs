using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when required credentials are missing in the login request.
    /// </summary>
    public class MissingCredentialsException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingCredentialsException"/> class
        /// with a specified field name indicating which credential is missing.
        /// </summary>
        /// <param name="fieldName">The name of the missing credential field.</param>
        public MissingCredentialsException(string fieldName)
            : base($"{fieldName} must be provided.")
        {
            ErrorCode = ErrorCode.MissingCredentials;
        }
    }
}
