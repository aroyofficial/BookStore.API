using Shuru.API.DTOs.Request;
using Shuru.API.DTOs.Response;

namespace Shuru.API.Services.Interfaces
{
    /// <summary>
    /// Defines the contract for book-related operations.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Retrieves a collection of books that match the specified search filter.
        /// </summary>
        /// <param name="filter">The filter criteria to apply when searching for books.</param>
        /// <returns>A task representing the asynchronous operation, containing a collection of matching books.</returns>
        Task<IEnumerable<BookResponse>> GetAsync(BookSearchFilter filter);

        /// <summary>
        /// Creates a new book record.
        /// </summary>
        /// <param name="request">The data required to create the book.</param>
        /// <returns>A task representing the asynchronous operation, containing the created book data.</returns>
        Task<BookResponse> CreateAsync(BookRequest request);

        /// <summary>
        /// Updates an existing book record.
        /// </summary>
        /// <param name="id">The identifier of the book to update.</param>
        /// <param name="request">The updated book data.</param>
        /// <returns>A task representing the asynchronous operation, containing the updated book data.</returns>
        Task<BookResponse> UpdateAsync(int id, BookRequest request);

        /// <summary>
        /// Deletes the book with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the book to delete.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task Delete(int id);
    }
}
