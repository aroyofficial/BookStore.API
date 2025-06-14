using Dapper;
using Shuru.API.DTOs.Request;
using Shuru.API.Enumerations;
using Shuru.API.Models;
using Shuru.API.Repository.Interfaces;
using System.Data;

namespace Shuru.API.Repository.Implementations
{
    /// <summary>
    /// Repository implementation for performing user-related database operations.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// The base repository used to execute database operations.
        /// </summary>
        private readonly IBaseRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified base repository dependency.
        /// </summary>
        /// <param name="repository">The base repository used to execute database operations.</param>
        public UserRepository(IBaseRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(User user)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@username", user.UserName, DbType.String);
            parameters.Add("@email", user.Email, DbType.String);
            parameters.Add("@password", user.Password, DbType.String);

            return await _repository.QuerySingleOrDefaultAsync<int>(new StoredProcedureRequest()
            {
                Name = "usp_createuser",
                Parameters = parameters
            });
        }

        /// <inheritdoc/>
        public async Task<User> GetAsync(User user, UserPurpose purpose)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", user.Id, DbType.Int32);
            parameters.Add("@username", user.UserName, DbType.String);
            parameters.Add("@email", user.Email, DbType.String);
            parameters.Add("@password", user.Password, DbType.String);
            parameters.Add("@mode", Convert.ToByte(purpose), DbType.Byte);

            return await _repository.QuerySingleOrDefaultAsync<User>(new StoredProcedureRequest()
            {
                Name = "usp_getuser",
                Parameters = parameters
            });
        }
    }
}
