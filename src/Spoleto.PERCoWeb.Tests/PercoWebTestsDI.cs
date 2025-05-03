using Microsoft.Extensions.DependencyInjection;

namespace Spoleto.PERCoWeb.Tests
{
    public class PercoWebTestsDI : PercoWebTestsBase
    {
        private ServiceProvider _serviceProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var services = new ServiceCollection();

            var percoWebOptions = ConfigurationHelper.GetPercoWebOptions();
            services.AddSingleton(percoWebOptions);
            services.AddSingleton<IPercoWebProvider, PercoWebProvider>();
            _serviceProvider = services.BuildServiceProvider();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _serviceProvider?.Dispose();
        }

        protected override IPercoWebProvider GetPercoWebProvider() => _serviceProvider.GetRequiredService<IPercoWebProvider>();
    }
}