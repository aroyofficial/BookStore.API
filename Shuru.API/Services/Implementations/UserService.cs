using Shuru.API.DTOs.Internal;
using Shuru.API.DTOs.Request;
using Shuru.API.DTOs.Response;
using Shuru.API.Enumerations;
using Shuru.API.Exceptions;
using Shuru.API.Helpers;
using Shuru.API.Models;
using Shuru.API.Repository.Interfaces;
using Shuru.API.Services.Interfaces;
using System.Net.Mail;
using System.Text.RegularExpressions;
using LoginRequest = Shuru.API.DTOs.Request.LoginRequest;

namespace Shuru.API.Services.Implementations
{
    /// <summary>
    /// Provides user-related business logic including registration, authentication, and profile retrieval.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repository">The user repository to interact with the database.</param>
        /// <param name="tokenService">The token service to generate JWT tokens.</param>
        public UserService(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        /// <inheritdoc/>
        public async Task<UserResponse> GetUserProfile(int id)
        {
            var user = await _repository.GetAsync(new User()
            {
                Id = id
            }, UserPurpose.GetUserProfile);

            if (user == null)
            {
                throw new UserNotFoundException("identifier");
            }

            return new UserResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        /// <inheritdoc/>
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            Validate(request);
            var user = await _repository.GetAsync(new User()
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = PasswordHelper.HashPassword(request.Password)
            }, UserPurpose.Login);

            if (user == null)
            {
                throw new UserNotFoundException(string.IsNullOrWhiteSpace(request.Email) ? request.Email : request.UserName);
            }
            else
            {
                if (PasswordHelper.VerifyPassword(request.Password, user.Password))
                {
                    var (token, expiresAt) = _tokenService.GenerateToken(new TokenPayload()
                    {
                        UserId = user.RowId,
                        UserName = user.UserName,
                        Email = user.Email
                    });

                    return new LoginResponse()
                    {
                        AccessToken = token,
                        ExpiresAt = expiresAt,
                        User = new UserResponse()
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            Email = user.Email
                        }
                    };
                }
                else
                {
                    throw new InvalidPasswordException();
                }
            }
        }

        /// <inheritdoc/>
        public async Task<UserResponse> Register(RegistrationRequest request)
        {
            Validate(request);

            UserResponse response = null!;
            var user = await _repository.GetAsync(new User()
            {
                UserName = request.UserName,
                Email = request.Email
            }, UserPurpose.Registration);

            if (user == null)
            {
                var userId = await _repository.CreateAsync(new User()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = PasswordHelper.HashPassword(request.Password)
                });

                response = new UserResponse()
                {
                    Id = userId,
                    UserName = request.UserName,
                    Email = request.Email
                };
            }
            else
            {
                if (user.Email == request.Email)
                {
                    throw new UserAlreadyExistsException("email");
                }
                if (user.UserName == request.UserName)
                {
                    throw new UserAlreadyExistsException("username");
                }
            }

            return response;
        }

        /// <summary>
        /// Validates the user registration request.
        /// </summary>
        /// <param name="request">The user request to validate.</param>
        /// <exception cref="InvalidUserCreationRequestException">Thrown when required fields are missing.</exception>
        private static void Validate(RegistrationRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.UserName) &&
                string.IsNullOrWhiteSpace(request.Email) &&
                string.IsNullOrWhiteSpace(request.Password))
            {
                throw new InvalidUserCreationRequestException();
            }

            ValidateUserName(request.UserName);
            ValidateEmail(request.Email);
            ValidatePassword(request.Password);
        }

        /// <summary>
        /// Validates the username.
        /// </summary>
        /// <param name="username">The username to validate.</param>
        private static void ValidateUserName(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new InvalidUserNameException("Username is required.");

            if (username.Length < 3 || username.Length > 50)
                throw new InvalidUserNameException("Username must be between 3 and 50 characters.");

            var usernameRegex = new Regex("^[a-zA-Z0-9._-]{3,50}$");
            if (!usernameRegex.IsMatch(username))
                throw new InvalidUserNameException("Username can only contain letters, numbers, dots, underscores, and hyphens.");
        }

        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidEmailException("Email is required.");

            if (email.Length > 100)
                throw new InvalidEmailException("Email is too long.");

            try
            {
                var addr = new MailAddress(email);
                if (addr.Address != email)
                    throw new InvalidEmailException("Email is invalid.");
            }
            catch
            {
                throw new InvalidEmailException("Email is invalid.");
            }
        }

        /// <summary>
        /// Validates the password according to complexity rules.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        private static void ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new WeakPasswordException("Password is required.");

            if (password.Length < 8 || password.Length > 64)
                throw new WeakPasswordException("Password must be between 8 and 64 characters.");

            if (!password.Any(char.IsLower))
                throw new WeakPasswordException("Password must contain at least one lowercase letter.");

            if (!password.Any(char.IsUpper))
                throw new WeakPasswordException("Password must contain at least one uppercase letter.");

            if (!password.Any(char.IsDigit))
                throw new WeakPasswordException("Password must contain at least one digit.");

            if (!password.Any(ch => "!@#$%^&*()_+{}[]:;\"'<>,.?/~`-=".Contains(ch)))
                throw new WeakPasswordException("Password must contain at least one special character.");
        }

        /// <summary>
        /// Validates the login request.
        /// </summary>
        /// <param name="request">The login request to validate.</param>
        private static void Validate(LoginRequest request)
        {
            if (request == null)
            {
                throw new InvalidRequestException();
            }
            if (string.IsNullOrWhiteSpace(request.UserName) && string.IsNullOrWhiteSpace(request.Email))
            {
                throw new MissingCredentialsException("UserName or Email");
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new MissingCredentialsException("Password");
            }
        }
    }
}
