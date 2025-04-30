using System.Text.Json.Serialization;

namespace Spoleto.PERCoWeb
{
    /// <summary>
    /// <see href="https://ru.percoweb.com/dev#authorizationPOST">Токен</see>.
    /// </summary>
    public record TokenModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        public override string ToString() => Token;
    }
}
