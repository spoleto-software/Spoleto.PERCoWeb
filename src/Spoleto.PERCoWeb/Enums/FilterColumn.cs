using System.Text.Json.Serialization;
using Spoleto.Common.Attributes;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Колонка для расширенного фильтра.
    /// </summary>
    [JsonConverter(typeof(JsonEnumValueConverter<FilterColumn>))]
    public enum FilterColumn
    {
        /// <summary>
        /// дата события
        /// </summary>
        [JsonEnumValue("event_date")]
        EventDate,

        /// <summary>
        /// полное имя сотрудника.
        /// </summary>
        /// <remarks>
        /// Работает по принципу "содержит", а не "равно".
        /// </remarks>
        [JsonEnumValue("fio")]
        Fio,

        /// <summary>
        /// номер карты в универсальном формате.
        /// </summary>
        /// <remarks>
        /// Работает по принципу "содержит", а не "равно".
        /// </remarks>
        [JsonEnumValue("identifier")]
        Identifier,

        /// <summary>
        /// ID подразделения.
        /// </summary>
        [JsonEnumValue("division")]
        Division,

        /// <summary>
        /// ID должности.
        /// </summary>
        [JsonEnumValue("position")]
        Position,

        /// <summary>
        /// ID шаблона доступа.
        /// </summary>
        [JsonEnumValue("access_template")]
        AccessTemplate,

        /// <summary>
        /// сопровождающий документ.
        /// </summary>
        /// <remarks>
        /// Работает по принципу "содержит", а не "равно".
        /// </remarks>
        [JsonEnumValue("supporting_document")]
        SupportingDocument,

        /// <summary>
        /// номер документа.
        /// </summary>
        /// <remarks>
        /// Работает по принципу "содержит", а не "равно".
        /// </remarks>
        [JsonEnumValue("supporting_document_number")]
        SupportingDocumentNumber,

        /// <summary>
        /// ID помещения входа.
        /// </summary>
        [JsonEnumValue("in")]
        InRoom,

        /// <summary>
        /// ID помещения выхода.
        /// </summary>
        [JsonEnumValue("out")]
        OutRoom,

        /// <summary>
        /// Сопровождающий.
        /// </summary>
        /// <remarks>
        /// Работает по принципу "содержит", а не "равно".
        /// </remarks>
        [JsonEnumValue("accompanying_name")]
        AccompanyingName
    }
}
