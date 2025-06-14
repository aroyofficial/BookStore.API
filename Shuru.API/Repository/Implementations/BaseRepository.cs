using Dapper;
using Shuru.API.DTOs.Request;
using Shuru.API.Repository.Interfaces;
using System.Data;

namespace Shuru.API.Repository.Implementations
{
    /// <summary>
    /// Base repository providing generic methods for executing stored procedures using Dapper.
    /// </summary>
    public class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// The database connection instance used for executing commands.
        /// </summary>
        private readonly IDbConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository"/> class with the specified database connection.
        /// </summary>
        /// <param name="connection">The database connection to use.</param>
        public BaseRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Executes a stored procedure asynchronously that does not return a result.
        /// </summary>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        public async Task ExecuteAsync(StoredProcedureRequest request)
        {
            await _connection.ExecuteAsync(
                request.Name,
                request.Parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 1000);
        }

        /// <summary>
        /// Executes a stored procedure asynchronously and returns a collection of results.
        /// </summary>
        /// <typeparam name="T">The type of the result objects.</typeparam>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of result objects.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(StoredProcedureRequest request)
        {
            return await _connection.QueryAsync<T>(
                request.Name,
                request.Parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 1000);
        }

        /// <summary>
        /// Executes a stored procedure asynchronously and returns a single result.
        /// </summary>
        /// <typeparam name="T">The type of the result object.</typeparam>
        /// <param name="request">The stored procedure request containing name and parameters.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result object.</returns>
        public async Task<T> QuerySingleOrDefaultAsync<T>(StoredProcedureRequest request)
        {
            return await _connection.QuerySingleOrDefaultAsync<T>(
                request.Name,
                request.Parameters,
                commandType: CommandType.StoredProcedure,
                commandTimeout: 1000);
        }
    }
}
