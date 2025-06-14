namespace Shuru.API.Models
{
    /// <summary>
    /// Represents a customer order containing total price and associated user information.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the user who placed the order.
        /// </summary>
        public Guid OrderedBy { get; set; }

        /// <summary>
        /// Gets or sets the total price of the order.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
