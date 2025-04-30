using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Группа пользователей
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<UserGroup>))]
    public enum UserGroup
    {
        [JsonEnumValue("all")]
        All,

        [JsonEnumValue("staff")]
        Staff,

        [JsonEnumValue("visitors")]
        Visitors
    }
}
