namespace Shuru.API.Enumerations
{
    /// <summary>
    /// Represents the purpose for which user information is being retrieved.
    /// </summary>
    public enum UserPurpose
    {
        /// <summary>
        /// Retrieving user profile information.
        /// </summary>
        GetUserProfile = 1,

        /// <summary>
        /// Retrieving user information for login.
        /// </summary>
        Login = 2,

        /// <summary>
        /// Retrieving user information for registration.
        /// </summary>
        Registration = 4
    }
}
