using Shuru.API.Repository.Interfaces;

namespace Shuru.API.Repository.Implementations
{
    /// <summary>
    /// Repository implementation for performing order-related database operations.
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// The base repository used to execute database operations.
        /// </summary>
        private readonly IBaseRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class with the specified base repository dependency.
        /// </summary>
        /// <param name="repository">The base repository used to execute database operations.</param>
        public OrderRepository(IBaseRepository repository)
        {
            _repository = repository;
        }
    }
}
