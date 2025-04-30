
using Spoleto.RestClient;

namespace Spoleto.PERCoWeb
{
    public class PercoWebProvider : IPercoWebProvider
    {
        private readonly PercoWebOptions _options;
        private readonly PercoWebClient _cdekClient;


        public PercoWebProvider(PercoWebOptions options)
        {
            if (options is null)
                throw new ArgumentNullException(nameof(options));

            // Validates if the options are valid
            options.Validate();

            _options = options;

            _cdekClient = new PercoWebClient(_options);
        }

        public PercoWebProvider(PercoWebClient cdekClient)
        {
            _cdekClient = cdekClient;
        }

        #region IDisposable
        bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                _cdekClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <inheritdoc/>
        public AccessReportEventContainer GetAccessReportEvents(AccessReportEventRequest request)
            => GetAccessReportEventsAsync(request).GetAwaiter().GetResult();

        /// <inheritdoc/>
        public async Task<AccessReportEventContainer> GetAccessReportEventsAsync(AccessReportEventRequest request)
        {
            var restRequest = new RestRequestFactory(RestHttpMethod.Get, $"api/accessReports/events")
                .WithQueryString(request)
                .Build();

            var accessReportEvents = await _cdekClient.ExecuteAsync<AccessReportEventContainer>(restRequest).ConfigureAwait(false);

            return accessReportEvents!;
        }
    }
}
