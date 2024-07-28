using System.Text.Json.Serialization;

namespace FlowersShopMVCTraining.Service.Dtos
{
    public class TranslateDto
    {
        [JsonPropertyName("q")]
        public string TextToTranslate { get; set; }

        [JsonPropertyName("source")]
        public string SourceLanguage { get; set; }

        [JsonPropertyName("target")]
        public string TargetLanguage { get; set; }

        [JsonPropertyName("format")]
        public string ResponseFormat { get; set; }

        [JsonPropertyName("alternatives")]
        public int NumberOfAlternatives { get; set; }

        [JsonPropertyName("api_key")]
        public string ApiKey { get; set; }

    }
}
