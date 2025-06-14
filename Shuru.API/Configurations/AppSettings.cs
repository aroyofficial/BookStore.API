namespace Shuru.API.Configurations
{
    /// <summary>
    /// Represents the application configuration settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppSettings"/> class with default values.
        /// </summary>
        public AppSettings()
        {
            ConnectionStrings = new ConnectionStrings();
        }

        /// <summary>
        /// Gets or sets the allowed hosts for the application.
        /// This is typically used to configure CORS or host restrictions.
        /// </summary>
        public string AllowedHosts { get; set; }

        /// <summary>
        /// Gets or sets the database connection strings used by the application.
        /// </summary>
        public ConnectionStrings ConnectionStrings { get; set; }

        public TokenConfiguration TokenConfiguration { get; set; }
    }
}
