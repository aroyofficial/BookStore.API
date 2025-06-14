using Shuru.API.DTOs.Request;
using Shuru.API.Models;

namespace Shuru.API.Repository.Interfaces
{
    /// <summary>
    /// Interface for performing book-related database operations.
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Creates a new book record in the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> object containing book details to be created.</param>
        /// <returns>A task representing the asynchronous operation, containing the ID of the newly created book.</returns>
        Task<int> CreateAsync(Book book);

        /// <summary>
        /// Deletes a book record from the database based on its ID.
        /// </summary>
        /// <param name="id">The ID of the book to be deleted.</param>
        /// <returns>A task representing the asynchronous delete operation.</returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Retrieves book data based on the specified search filter.
        /// </summary>
        /// <param name="filter">The <see cref="BookSearchFilter"/> object containing filter criteria for searching books.</param>
        /// <returns>A task representing the asynchronous get operation.</returns>
        Task<IEnumerable<Book>> GetAsync(BookSearchFilter filter);

        /// <summary>
        /// Updates an existing book record in the database.
        /// </summary>
        /// <param name="book">The <see cref="Book"/> object containing updated book details.</param>
        /// <returns>A task representing the asynchronous update operation.</returns>
        Task UpdateAsync(Book book);
    }
}
