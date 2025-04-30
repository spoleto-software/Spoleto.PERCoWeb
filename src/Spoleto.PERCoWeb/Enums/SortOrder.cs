using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Порядок сортировки (ASC или DESC)
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<SortOrder>))]
    public enum SortOrder
    {
        [JsonEnumValue("ASC")]
        Asc,

        [JsonEnumValue("DESC")]
        Desc
    }
}
