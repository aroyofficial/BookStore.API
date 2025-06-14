namespace Shuru.API.Models
{
    /// <summary>
    /// Represents an item included in a customer order, containing details about the book, quantity, and pricing.
    /// </summary>
    public class OrderItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier of the associated order.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the associated book.
        /// </summary>
        public Guid BookId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the book ordered.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the individual item.
        /// </summary>
        public decimal Price { get; set; }
    }
}
