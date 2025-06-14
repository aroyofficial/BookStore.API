using Shuru.API.Enumerations;

namespace Shuru.API.Exceptions
{
    /// <summary>
    /// Represents an exception that is thrown when the provided password does not meet the required strength or complexity rules.
    /// </summary>
    public class WeakPasswordException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeakPasswordException"/> class 
        /// with a specified error message describing why the password is considered weak.
        /// </summary>
        /// <param name="message">The message that describes the reason for the weak password exception.</param>
        public WeakPasswordException(string message)
            : base(message)
        {
            ErrorCode = ErrorCode.WeakPassword;
        }
    }
}
