namespace Spoleto.PERCoWeb
{
    public static class PercoWebProviderExtensions
    {
        /// <summary>
        /// Получить отчет о всех проходах (со всех страниц, которые возвращает PERCo-Web).
        /// </summary>
        public static List<AccessReportEvent> GetAllAccessReportEvents(this IPercoWebProvider provider, AccessReportEventRequest request)
            => GetAllAccessReportEventsAsync(provider, request).GetAwaiter().GetResult();

        /// <summary>
        /// Получить отчет о всех проходах (со всех страниц, которые возвращает PERCo-Web).
        /// </summary>
        public static async Task<List<AccessReportEvent>> GetAllAccessReportEventsAsync(this IPercoWebProvider provider, AccessReportEventRequest request)
        {
            List<AccessReportEvent>? allEvents = null;
            var currentPage = 1;
            int totalPages;

            do
            {
                request.Page = currentPage;
                var currentContainer = await provider.GetAccessReportEventsAsync(request).ConfigureAwait(false);

                if (currentContainer == null || currentContainer.Rows.Count == 0)
                {
                    break;
                }

                allEvents ??= new List<AccessReportEvent>(currentContainer.Records);
                allEvents.AddRange(currentContainer.Rows);

                totalPages = currentContainer.Total;
                currentPage++;
            }
            while (currentPage <= totalPages);  // Continue until all pages are retrieved

            return allEvents;
        }
    }
}
