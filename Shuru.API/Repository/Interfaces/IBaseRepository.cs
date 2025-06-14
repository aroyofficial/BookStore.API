using Shuru.API.DTOs.Request;

namespace Shuru.API.Repository.Interfaces
{
    /// <summary>
    /// Interface for base repository providing generic methods for executing stored procedures.
    /// </summary>
    public interface IBaseRepository
    {
        /// <summary>
        /// Executes a stored procedure asynchronously that does not return a result.
        /// </summary>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        Task ExecuteAsync(StoredProcedureRequest request);

        /// <summary>
        /// Executes a stored procedure asynchronously and returns a collection of results.
        /// </summary>
        /// <typeparam name="T">The type of the result objects.</typeparam>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of result objects.</returns>
        Task<IEnumerable<T>> QueryAsync<T>(StoredProcedureRequest request);

        /// <summary>
        /// Executes a stored procedure asynchronously and returns a single result.
        /// </summary>
        /// <typeparam name="T">The type of the result object.</typeparam>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result object.</returns>
        Task<T> QuerySingleOrDefaultAsync<T>(StoredProcedureRequest request);
    }
}
