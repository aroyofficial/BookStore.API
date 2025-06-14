using Shuru.API.Enumerations;
using Shuru.API.Models;

namespace Shuru.API.Repository.Interfaces
{
    /// <summary>
    /// Defines methods for performing user-related database operations.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Asynchronously creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object containing the user details to be stored.</param>
        /// <returns>A task representing the asynchronous operation, containing the unique identifier (integer) of the newly created user.</returns>
        Task<int> CreateAsync(User user);

        /// <summary>
        /// Asynchronously retrieves a user from the database based on the specified search criteria.
        /// </summary>
        /// <param name="request">The user request object containing the search parameters (e.g., Id, username, or email).</param>
        /// <param name="purpose">The purpose of the user to retrieve the details.</param>
        /// <returns>A task representing the asynchronous operation, containing the user object retrieved from the database.</returns>
        Task<User> GetAsync(User request, UserPurpose purpose);
    }
}
