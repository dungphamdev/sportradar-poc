using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class Summary
    {
        [JsonProperty("sport_event")]
        public SportEvent SportEvent { get; set; } = new();

        [JsonProperty("sport_event_status")]
        public SportEventStatus SportEventStatus { get; set; } = new();

        [JsonProperty("statistics")]
        public Statistics Statistics { get; set; } = new();
    }
}
