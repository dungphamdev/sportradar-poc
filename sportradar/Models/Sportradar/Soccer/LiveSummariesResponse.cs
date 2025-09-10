using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class LiveSummariesResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("summaries")]
        public List<Summary> Summaries { get; set; } = [];
    }
}
