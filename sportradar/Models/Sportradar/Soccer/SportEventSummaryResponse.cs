using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SportEventSummaryResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("sport_event")]
        public SportEvent SportEvent { get; set; } = new();

        [JsonProperty("sport_event_status")]
        public SportEventStatus SportEventStatus { get; set; } = new();

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; } = new();
    }
}
