namespace Shuru.API.DTOs.Response
{
    /// <summary>
    /// Represents the data returned for a book record.
    /// </summary>
    public class BookResponse : BaseDTO
    {
        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the price of the book.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the number of copies available in stock.
        /// </summary>
        public int StockCount { get; set; }

        /// <summary>
        /// Gets or sets the publication date of the book.
        /// </summary>
        public DateTime PublishedAt { get; set; }
    }
}
