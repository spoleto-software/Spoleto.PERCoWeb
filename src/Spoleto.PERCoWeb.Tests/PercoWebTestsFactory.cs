namespace Spoleto.PERCoWeb.Tests
{
    public class PercoWebTestsFactory : PercoWebTestsBase
    {
        private IPercoWebProvider _percoWebProvider;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var percoWebOptions = ConfigurationHelper.GetPercoWebOptions();
            _percoWebProvider = new PercoWebProviderFactory().WithOptions(percoWebOptions).Build();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _percoWebProvider?.Dispose();
        }

        protected override IPercoWebProvider GetPercoWebProvider() => _percoWebProvider;
    }
}