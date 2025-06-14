namespace Shuru.API.DTOs.Request
{
    /// <summary>
    /// Represents the filter criteria used for searching books.
    /// </summary>
    public class BookSearchFilter
    {
        /// <summary>
        /// Gets or sets the title of the book to search for.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book to search for.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the price of the book to search for.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is available in stock.
        /// </summary>
        public bool AvailableInStock { get; set; }

        /// <summary>
        /// Gets or sets the publication date range within which the book was published.
        /// </summary>
        public DateRange PublishedBetween { get; set; }
    }
}
