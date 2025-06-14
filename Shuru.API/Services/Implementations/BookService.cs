using Shuru.API.DTOs.Request;
using Shuru.API.DTOs.Response;
using Shuru.API.Exceptions;
using Shuru.API.Models;
using Shuru.API.Repository.Interfaces;
using Shuru.API.Services.Interfaces;

namespace Shuru.API.Services.Implementations
{
    /// <summary>
    /// Provides implementation for book-related business operations.
    /// </summary>
    public class BookService : IBookService
    {
        /// <summary>
        /// The repository used to perform data access operations for books.
        /// </summary>
        private readonly IBookRepository _repository;

        /// <summary>
        /// The service used to retrieve information about the current authenticated user.
        /// </summary>
        private readonly IUserContextService _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="repository">The repository instance used for book data operations.</param>
        /// <param name="context">The user context service instance used to access the current user's information.</param>
        public BookService(IBookRepository repository, IUserContextService context)
        {
            _repository = repository;
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<BookResponse> CreateAsync(BookRequest request)
        {
            Validate(request);
            var bookId = await _repository.CreateAsync(new Book()
            {
                Author = request.Author,
                Title = request.Title,
                Price = request.Price,
                StockCount = request.StockCount,
                PublishedAt = request.PublishedAt,
                CreatedBy = _context.GetUserId(),
            });

            return new BookResponse()
            {
                Id = bookId,
                Author = request.Author,
                Title = request.Title,
                Price = request.Price,
                StockCount = request.StockCount,
                PublishedAt = request.PublishedAt
            };
        }

        /// <inheritdoc/>
        public async Task Delete(int id)
        {
            await _repository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<BookResponse>> GetAsync(BookSearchFilter filter)
        {
            ValidateSearchFilter(filter);
            var books = await _repository.GetAsync(filter);
            return books.Select(book => new BookResponse()
            {
                Id = book.Id,
                Author = book.Author,
                Title = book.Title,
                Price = book.Price,
                StockCount = book.StockCount,
                PublishedAt = book.PublishedAt
            });
        }

        /// <inheritdoc/>
        public async Task<BookResponse> UpdateAsync(int id, BookRequest request)
        {
            Validate(request);
            await _repository.UpdateAsync(new Book()
            {
                Id = id,
                Author = request.Author,
                Title = request.Title,
                Price = request.Price,
                StockCount = request.StockCount,
                PublishedAt = request.PublishedAt,
                UpdatedAt = DateTime.UtcNow,
                UpdatedBy = _context.GetUserId()
            });

            return new BookResponse()
            {
                Id = id,
                Author = request.Author,
                Title = request.Title,
                Price = request.Price,
                StockCount = request.StockCount,
                PublishedAt = request.PublishedAt
            };
        }

        /// <summary>
        /// Validates the book request before processing.
        /// </summary>
        /// <param name="request">The <see cref="BookRequest"/> object to validate.</param>
        private static void Validate(BookRequest request)
        {
            if (request == null)
            {
                throw new InvalidRequestException();
            }

            if (string.IsNullOrEmpty(request.Title))
            {
                throw new TitleRequiredException();
            }

            if (string.IsNullOrWhiteSpace(request.Author))
            {
                throw new AuthorRequiredException();
            }

            if (request.Price < 1)
            {
                throw new InvalidPriceException();
            }

            if (request.PublishedAt > DateTime.UtcNow)
            {
                throw new InvalidPublishedDateException();
            }

            if (request.StockCount < 0)
            {
                throw new InvalidStockCountException();
            }
        }

        /// <summary>
        /// Validates the book search filter before processing.
        /// </summary>
        /// <param name="filter">The <see cref="BookSearchFilter"/> object to validate.</param>
        private static void ValidateSearchFilter(BookSearchFilter filter)
        {
            if (filter != null)
            {
                if (filter.Price < 1)
                {
                    throw new InvalidPriceException();
                }

                if (filter.PublishedBetween != null)
                {
                    if (filter.PublishedBetween.Start > DateTime.UtcNow)
                    {
                        throw new InvalidPublishedStartDateException();
                    }
                    if (filter.PublishedBetween.End > DateTime.UtcNow)
                    {
                        throw new InvalidPublishedEndDateException();
                    }
                    if (filter.PublishedBetween.Start > filter.PublishedBetween.End)
                    {
                        throw new PublishedDateRangeInvalidException();
                    }
                }
            }
        }
    }
}
