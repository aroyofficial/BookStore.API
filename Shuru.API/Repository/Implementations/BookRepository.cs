using Dapper;
using Shuru.API.DTOs.Request;
using Shuru.API.Models;
using Shuru.API.Repository.Interfaces;
using System.Data;

namespace Shuru.API.Repository.Implementations
{
    /// <summary>
    /// Repository implementation for performing book-related database operations.
    /// </summary>
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// The base repository used to execute database operations.
        /// </summary>
        private readonly IBaseRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class with the specified base repository dependency.
        /// </summary>
        /// <param name="repository">The base repository used to execute database operations.</param>
        public BookRepository(IBaseRepository repository)
        {
            _repository = repository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@title", book.Title, DbType.String);
            parameters.Add("@author", book.Author, DbType.String);
            parameters.Add("@price", book.Price, DbType.Decimal);
            parameters.Add("@stockcount", book.StockCount, DbType.Int32);
            parameters.Add("@publishedat", book.PublishedAt, DbType.DateTime);
            parameters.Add("@createdby", book.CreatedBy, DbType.Guid);

            return await _repository.QuerySingleOrDefaultAsync<int>(new StoredProcedureRequest()
            {
                Name = "usp_createbook",
                Parameters = parameters
            });
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id, DbType.Int32);

            await _repository.ExecuteAsync(new StoredProcedureRequest()
            {
                Name = "usp_deletebook",
                Parameters = parameters
            });
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Book>> GetAsync(BookSearchFilter filter)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(Book book)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@title", book.Title, DbType.String);
            parameters.Add("@author", book.Author, DbType.String);
            parameters.Add("@price", book.Price, DbType.Decimal);
            parameters.Add("@stockcount", book.StockCount, DbType.Int32);
            parameters.Add("@publishedat", book.PublishedAt, DbType.DateTime);
            parameters.Add("@updatedby", book.UpdatedBy, DbType.Guid);
            parameters.Add("@updatedat", book.UpdatedAt, DbType.DateTime);

            await _repository.ExecuteAsync(new StoredProcedureRequest()
            {
                Name = "usp_updatebook",
                Parameters = parameters
            });
        }
    }
}
