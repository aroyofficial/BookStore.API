namespace Shuru.API.DTOs
{
    /// <summary>
    /// Represents the base data transfer object (DTO) that contains the common identifier property.
    /// </summary>
    public abstract class BaseDTO
    {
        /// <summary>
        /// Gets or sets the identity of the entity.
        /// </summary>
        public int Id { get; set; }
    }
}
