using System.Security.Cryptography;
using System.Text;

namespace Shuru.API.Helpers
{
    /// <summary>
    /// Helper class for securely hashing and verifying passwords.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// Hashes the provided plain-text password using SHA256.
        /// </summary>
        /// <param name="password">The plain-text password.</param>
        /// <returns>The hashed password string.</returns>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Compares a plain-text password to a hashed password.
        /// </summary>
        /// <param name="password">The plain-text password to verify.</param>
        /// <param name="hashedPassword">The stored hashed password.</param>
        /// <returns>True if password matches; otherwise, false.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hashedPassword;
        }
    }
}
