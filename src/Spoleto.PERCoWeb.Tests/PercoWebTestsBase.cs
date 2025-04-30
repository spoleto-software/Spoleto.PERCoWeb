namespace Spoleto.PERCoWeb.Tests
{
    public abstract class PercoWebTestsBase
    {
        protected abstract IPercoWebProvider GetPercoWebProvider();

        [Test]
        public async Task GetAllAccessReportEvents()
        {
            // Arrange
            var provider = GetPercoWebProvider();
            var request = ConfigurationHelper.GetRequestModel<AccessReportEventRequest>();
            request.Filters = new(LogicalOperator.Or);
            request.Filters.Rows.Add(new FilterRow(FilterColumn.Fio, "Иванов"));
            request.Filters.Rows.Add(new FilterRow(FilterColumn.Fio, "Петров"));

            // Act
            var accessReportEvents = await provider.GetAllAccessReportEventsAsync(request);

            // Assert
            Assert.That(accessReportEvents, Is.Not.Null);
        }
    }
}