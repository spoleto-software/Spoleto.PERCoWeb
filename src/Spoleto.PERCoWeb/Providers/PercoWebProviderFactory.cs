namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// PercoWebProvider factory used to create an instance of <see cref="PercoWebProvider"/>.
    /// </summary>
    public class PercoWebProviderFactory
    {
        private PercoWebOptions? _percoWebOptions;
        private PercoWebProvider? _percoWebProvider;

        /// <summary>
        /// Sets the options of the PercoWeb provider.
        /// </summary>
        /// <remarks>
        /// <see href="https://ru.percoweb.com/dev#introduction"/>
        /// </remarks>
        /// <param name="login">The login.</param>
        /// <param name="password">The password.</param>
        /// <param name="serviceUrl">The PercoWeb service url.</param>
        /// <returns>The <see cref="PercoWebProviderFactory"/> instance is provided to support method chaining capabilities.</returns>
        public PercoWebProviderFactory WithOptions(string login, string password, string serviceUrl)
           => WithOptions(x =>
           {
               x.ServiceUrl = serviceUrl;
               x.Login = login;
               x.Password = password;
           });

        /// <summary>
        /// Sets the options of the PercoWeb provider.
        /// </summary>
        /// <param name="config">The action to configure the <see cref="PercoWebOptions"/> for the PercoWeb provider.</param>
        /// <returns>The <see cref="PercoWebProviderFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        public PercoWebProviderFactory WithOptions(Action<PercoWebOptions> config)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            // loads the options
            var options = new PercoWebOptions();
            config(options);

            // validates the options
            options.Validate();

            _percoWebOptions = options;

            return this;
        }

        /// <summary>
        /// Sets the options of the PercoWeb provider.
        /// </summary>
        /// <param name="options">The options for the PercoWeb provider.</param>
        /// <returns>The <see cref="PercoWebProviderFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="options"/> is null.</exception>
        public PercoWebProviderFactory WithOptions(PercoWebOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // validates the options
            options.Validate();

            _percoWebOptions = options;

            return this;
        }

        /// <summary>
        /// Sets the PercoWeb provider.
        /// </summary>
        /// <param name="config">The action to configure the <see cref="PercoWebOptions"/> for the PercoWeb provider.</param>
        /// <returns>The <see cref="PercoWebProviderFactory"/> instance is provided to support method chaining capabilities.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="config"/> is null.</exception>
        public PercoWebProviderFactory WithPercoWebProvider(PercoWebProvider percoWebProvider)
        {
            if (percoWebProvider is null)
                throw new ArgumentNullException(nameof(percoWebProvider));

            _percoWebProvider = percoWebProvider;

            return this;
        }

        /// <summary>
        /// Creates the PercoWebProvider instance.
        /// </summary>
        /// <returns>Instance of <see cref="PercoWebProvider"/>.</returns>
        public IPercoWebProvider Build() => _percoWebProvider ?? new PercoWebProvider(_percoWebOptions);
    }
}
