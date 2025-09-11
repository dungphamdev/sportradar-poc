using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SeasonSummariesResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("summaries")]
        public List<Summary> Summaries { get; set; } = [];
    }
}
