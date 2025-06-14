namespace Shuru.API.Services.Interfaces
{
    /// <summary>
    /// Provides access to user-specific context information extracted from the current HTTP request.
    /// </summary>
    public interface IUserContextService
    {
        /// <summary>
        /// Retrieves the UserId (typically stored in the 'sub' claim) from the currently authenticated user.
        /// </summary>
        /// <returns>The unique identifier of the current user.</returns>
        Guid GetUserId();
    }
}
