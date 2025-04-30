using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Расширенный фильтр для событий.Должен быть JSON-строкой следующего формата: {"type": "", "rows": [{"column": "", "value": ""}]} 
    /// </summary>
    public record AccessReportEventsFilter
    {
        public AccessReportEventsFilter(LogicalOperator type)
        {
            Type = type;
        }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(JsonEnumValueConverter<LogicalOperator>))]
        public LogicalOperator Type { get;  }

        [JsonPropertyName("rows")]
        public List<FilterRow> Rows { get; set; } = [];
    }
}