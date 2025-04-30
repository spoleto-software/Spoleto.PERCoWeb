using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Массив объектов, содержащий название колонки и значение для поиска
    /// </summary>
    public record FilterRow
    {
        public FilterRow(FilterColumn column, string value)
        {
            Column = column;
            Value = value;
        }

        [JsonPropertyName("column")]
        [JsonConverter(typeof(JsonEnumValueConverter<FilterColumn>))]
        public FilterColumn Column { get; }

        [JsonPropertyName("value")]
        public string Value { get; }
    }
}