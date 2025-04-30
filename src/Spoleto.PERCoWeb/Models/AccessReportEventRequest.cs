using System.Text.Json.Serialization;
using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// Параметры запроса для получения отчёта о проходах.
    /// </summary>
    public record AccessReportEventRequest
    {
        public AccessReportEventRequest(DateTime dateBegin, DateTime dateEnd = default)
        {
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }

        /// <summary>
        /// Дата начала периода (Строка формата YYYY-MM-DD)
        /// </summary>
        [JsonPropertyName("dateBegin")]
        public DateTime DateBegin { get; }

        /// <summary>
        /// Дата окончания периода(Строка формата YYYY-MM-DD)
        /// </summary>
        [JsonPropertyName("dateEnd")]
        public DateTime DateEnd { get; }

        /// <summary>
        /// Список подразделений (через запятую)
        /// </summary>
        [JsonPropertyName("division")]
        public string? Division { get; set; }

        /// <summary>
        /// Расширенный фильтр для событий.
        /// </summary>
        [JsonPropertyName("filters")]
        public AccessReportEventsFilter? Filters { get; set; }

        /// <summary>
        /// Группа пользователей ('all', 'staff', 'visitors')
        /// </summary>
        [JsonPropertyName("group")]
        [JsonConverter(typeof(JsonEnumValueConverter<UserGroup>))]
        public UserGroup? Group { get; set; }

        /// <summary>
        /// Номер страницы (пагинатор)
        /// </summary>
        [JsonPropertyName("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Список помещений (через запятую)
        /// </summary>
        [JsonPropertyName("rooms")]
        public string? Rooms { get; set; }

        /// <summary>
        /// Количество строк
        /// </summary>
        [JsonPropertyName("rows")]
        public int? Rows { get; set; }

        /// <summary>
        /// Строка поиска
        /// </summary>
        [JsonPropertyName("searchString")]
        public string? SearchString { get; set; }

        /// <summary>
        /// Имя столбца для сортировки
        /// </summary>
        [JsonPropertyName("sidx")]
        public string? Sidx { get; set; }

        /// <summary>
        /// Порядок сортировки (ASC или DESC)
        /// </summary>
        [JsonPropertyName("sord")]
        [JsonConverter(typeof(JsonEnumValueConverter<SortOrder>))]
        public SortOrder? Sord { get; set; }

        /// <summary>
        /// Секретный ключ (небезопасно), советуем не использовать данный метод авторизации
        /// </summary>
        [JsonPropertyName("token")]
        public string? Token { get; set; }
    }
}
