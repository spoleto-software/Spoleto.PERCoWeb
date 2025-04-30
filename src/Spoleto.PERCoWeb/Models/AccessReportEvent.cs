using System.Text.Json.Serialization;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// <see href="https://ru.percoweb.com/dev#accessReportsEventsGET">Отчет о проходах</see>.
    /// </summary>
    public record AccessReportEvent
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("tabel_number")]
        public string TabelNumber { get; set; }

        [JsonPropertyName("fio")]
        public string Fio { get; set; }

        [JsonPropertyName("time_label")]
        public string TimeLabel { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("user_id")]
        public int? UserId { get; set; }

        [JsonPropertyName("template_id")]
        public int? TemplateId { get; set; }

        [JsonPropertyName("template_name")]
        public string TemplateName { get; set; }

        [JsonPropertyName("template_name_vis")]
        public string TemplateNameVis { get; set; }

        [JsonPropertyName("position_id")]
        public int? PositionId { get; set; }

        [JsonPropertyName("position_name")]
        public string PositionName { get; set; }

        [JsonPropertyName("division_id")]
        public int? DivisionId { get; set; }

        [JsonPropertyName("division_name")]
        public string DivisionName { get; set; }

        [JsonPropertyName("division_name_vis")]
        public string DivisionNameVis { get; set; }

        [JsonPropertyName("zone_exit_id")]
        public int? ZoneExitId { get; set; }

        [JsonPropertyName("zone_exit")]
        public string ZoneExit { get; set; }

        [JsonPropertyName("zone_enter_id")]
        public int? ZoneEnterId { get; set; }

        [JsonPropertyName("zone_enter")]
        public string ZoneEnter { get; set; }

        [JsonPropertyName("supporting_document")]
        public string SupportingDocument { get; set; }

        [JsonPropertyName("supporting_document_number")]
        public string SupportingDocumentNumber { get; set; }

        [JsonPropertyName("accompanying_name")]
        public string AccompanyingName { get; set; }

        [JsonPropertyName("cars")]
        public string Cars { get; set; }
    }
}