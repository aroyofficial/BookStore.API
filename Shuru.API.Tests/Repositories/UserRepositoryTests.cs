using Moq;
using Shuru.API.DTOs.Request;
using Shuru.API.Enumerations;
using Shuru.API.Models;
using Shuru.API.Repository.Implementations;
using Shuru.API.Repository.Interfaces;
using Shuru.API.Tests.TestData;

namespace Shuru.Tests.Repositories
{
    /// <summary>
    /// Contains unit tests for the <see cref="UserRepository"/> class.
    /// </summary>
    public class UserRepositoryTests
    {
        /// <summary>
        /// Mock instance of <see cref="IBaseRepository"/> used to isolate repository behavior.
        /// </summary>
        private readonly Mock<IBaseRepository> _mockBaseRepository;

        /// <summary>
        /// Instance of <see cref="UserRepository"/> under test.
        /// </summary>
        private readonly UserRepository _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepositoryTests"/> class.
        /// Sets up the mocked base repository and injects it into the repository under test.
        /// </summary>
        public UserRepositoryTests()
        {
            _mockBaseRepository = new Mock<IBaseRepository>();
            _userRepository = new UserRepository(_mockBaseRepository.Object);
        }

        /// <summary>
        /// Tests the <see cref="UserRepository.GetAsync"/> method to ensure it returns expected user data.
        /// </summary>
        /// <param name="argument1">The <see cref="User"/> request object containing input parameters.</param>
        /// <param name="argument2">The <see cref="UserPurpose"/> enum specifying the query mode.</param>
        /// <param name="expected">The expected <see cref="User"/> object returned by the repository.</param>
        /// <returns>A task representing the asynchronous test operation.</returns>
        [Theory]
        [MemberData(nameof(UserRepositoryTestData.GetAsyncReturnsObjectDataSet),
            MemberType = typeof(UserRepositoryTestData))]
        public async Task GetAsyncReturnsObject(User argument1, UserPurpose argument2, User expected)
        {
            // Arrange
            _mockBaseRepository
                .Setup(repo => repo.QuerySingleOrDefaultAsync<User>(It.IsAny<StoredProcedureRequest>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _userRepository.GetAsync(argument1, argument2);

            // Assert
            if (argument1.UserName == "aroy02072000")
            {
                Assert.NotNull(result);
                if (!string.IsNullOrWhiteSpace(argument1.UserName))
                {
                    Assert.Equal(argument1.UserName, result.UserName);
                }
                if (!string.IsNullOrWhiteSpace(argument1.Email))
                {
                    Assert.Equal(argument1.Email, result.Email);
                }
            }

            if (argument1.UserName == "ankitadas")
            {
                Assert.Null(result);
            }

            _mockBaseRepository.Verify(repo =>
                repo.QuerySingleOrDefaultAsync<User>(
                    It.IsAny<StoredProcedureRequest>()),
                    Times.Once);
        }

        [Theory]
        [MemberData(nameof(UserRepositoryTestData.GetAsyncReturnsNullDataSet),
            MemberType = typeof(UserRepositoryTestData))]
        public async Task GetAsyncReturnsNull(User argument1, UserPurpose argument2, User expected)
        {
            // Arrange
            _mockBaseRepository.Setup(repo => repo.QuerySingleOrDefaultAsync<User>(It.IsAny<StoredProcedureRequest>()))
                .ReturnsAsync(expected);

            // Act
            var result = await _userRepository.GetAsync(argument1, argument2);

            // Assert
            Assert.Null(result);
            _mockBaseRepository.Verify(repo =>
                repo.QuerySingleOrDefaultAsync<User>(It.IsAny<StoredProcedureRequest>()),
                Times.Once);
        }
    }
}
