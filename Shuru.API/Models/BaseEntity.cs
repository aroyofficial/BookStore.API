namespace Shuru.API.Models
{
    /// <summary>
    /// Serves as the base entity class providing common auditing and identification properties for all derived entities.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the numeric identity of the entity (typically used for display or business logic).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the globally unique identifier (GUID) for the entity used as the primary key in the database.
        /// </summary>
        public Guid RowId { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp indicating when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the UTC timestamp indicating when the entity was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who created the entity.
        /// </summary>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the user who last updated the entity. Can be null if never updated.
        /// </summary>
        public Guid? UpdatedBy { get; set; }
    }
}
