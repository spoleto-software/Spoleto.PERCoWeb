using System.Text.Json.Serialization;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// <see href="https://ru.percoweb.com/dev#accessReportsEventsGET">Отчет о проходах</see>.
    /// </summary>
    public record AccessReportEventContainer
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("records")]
        public int Records { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("rows")]
        public List<AccessReportEvent> Rows { get; set; }
    }
}
