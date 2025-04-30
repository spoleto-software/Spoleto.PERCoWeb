namespace Spoleto.PERCoWeb
{
    public interface IPercoWebProvider : IDisposable
    {
        /// <summary>
        /// <see href="https://ru.percoweb.com/dev#accessReportsEventsGET">Отчет о проходах</see>.
        /// </summary>
       AccessReportEventContainer GetAccessReportEvents(AccessReportEventRequest request);

        /// <summary>
        /// <see href="https://ru.percoweb.com/dev#accessReportsEventsGET">Отчет о проходах</see>.
        /// </summary>
        Task<AccessReportEventContainer> GetAccessReportEventsAsync(AccessReportEventRequest request);
    }
}
