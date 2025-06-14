using Dapper;

namespace Shuru.API.DTOs.Request
{
    /// <summary>
    /// Represents a request object used for executing a stored procedure.
    /// </summary>
    public class StoredProcedureRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StoredProcedureRequest"/> class
        /// with an empty set of dynamic parameters.
        /// </summary>
        public StoredProcedureRequest()
        {
            Parameters = new DynamicParameters();
        }

        /// <summary>
        /// Gets or sets the name of the stored procedure to be executed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the dynamic parameters to be passed to the stored procedure.
        /// This allows adding parameters at runtime using Dapper's <see cref="Parameters"/> class.
        /// </summary>
        public DynamicParameters Parameters { get; set; }
    }
}
