using Spoleto.Common.JsonConverters;

namespace Spoleto.PERCoWeb.Converters
{
    public class JsonDateTimeConverter : JsonDateTimeConverterBase
    {
        public JsonDateTimeConverter() : base("yyyy-MM-dd HH:mm:ss")
        {
        }
    }
}
