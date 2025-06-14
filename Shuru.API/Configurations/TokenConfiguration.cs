namespace Shuru.API.Configurations
{
    /// <summary>
    /// Represents the configuration settings required for generating and validating tokens.
    /// </summary>
    public class TokenConfiguration
    {
        /// <summary>
        /// Gets or sets the secret key used to sign the JWT token.
        /// </summary>
        public string SecretKey { get; set; } = null!;

        /// <summary>
        /// Gets or sets the issuer of the JWT token.
        /// </summary>
        public string Issuer { get; set; } = null!;

        /// <summary>
        /// Gets or sets the audience of the JWT token.
        /// </summary>
        public string Audience { get; set; } = null!;

        /// <summary>
        /// Gets or sets the token expiration time in minutes.
        /// </summary>
        public int ExpiryMinutes { get; set; }
    }
}
