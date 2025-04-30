namespace Spoleto.PERCoWeb
{
    public record PercoWebOptions
    {
        public string ServiceUrl { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Checks that all the settings within the options are configured properly.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when <see cref="ServiceUrl"/> or <see cref="Login"/> or <see cref="Password"/> are null.</exception>
        public void Validate()
        {
            if (String.IsNullOrEmpty(ServiceUrl))
                throw new ArgumentNullException(nameof(ServiceUrl));

            if (Login == null)
                throw new ArgumentNullException(nameof(Login));

            if (Password == null)
                throw new ArgumentNullException(nameof(Password));
        }
    }
}
