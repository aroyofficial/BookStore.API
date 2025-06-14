namespace Shuru.API.Models
{
    /// <summary>
    /// Represents a book available in the bookstore.
    /// </summary>
    public class Book : BaseEntity
    {
        /// <summary>
        /// The title of the book.
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// The author of the book.
        /// </summary>
        public string Author { get; set; } = null!;

        /// <summary>
        /// The price of the book.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The number of copies available in stock.
        /// </summary>
        public int StockCount { get; set; }

        /// <summary>
        /// The publication date of the book.
        /// </summary>
        public DateTime PublishedAt { get; set; }
    }
}
