using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    ///  Условие выборки, логическое И или ИЛИ.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<LogicalOperator>))]
    public enum LogicalOperator
    {
        [JsonEnumValue("and")]
        And,

        [JsonEnumValue("or")]
        Or
    }
}
