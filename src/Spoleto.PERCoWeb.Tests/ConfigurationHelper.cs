using Microsoft.Extensions.Configuration;

namespace Spoleto.PERCoWeb.Tests
{
    internal class ConfigurationHelper
    {
        private static readonly IConfigurationRoot _config;

        static ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true)
               .AddUserSecrets("e1896686-532d-48b7-b760-469fe0c260fd")
               .Build();
        }

        public static IConfigurationRoot Configuration => _config;

        public static PercoWebOptions GetPercoWebOptions()
        {
            var options = _config.GetSection(nameof(PercoWebOptions)).Get<PercoWebOptions>()!;

            return options;
        }

        public static T GetRequestModel<T>() where T : class
        {
            var model = _config.GetSection(typeof(T).Name).Get<T>();

            return model;
        }
    }
}
