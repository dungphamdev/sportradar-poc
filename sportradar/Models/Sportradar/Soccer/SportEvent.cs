using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SportEvent
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }

        [JsonProperty("start_time_confirmed")]
        public bool StartTimeConfirmed { get; set; }

        [JsonProperty("sport_event_context")]
        public SportEventContext SportEventContext { get; set; } = new();

        //[JsonProperty("coverage")]
        //public Coverage Coverage { get; set; }

        [JsonProperty("competitors")]
        public List<Competitor> Competitors { get; set; } = [];

        //[JsonProperty("venue")]
        //public Venue Venue { get; set; }

        //[JsonProperty("sport_event_conditions")]
        //public SportEventConditions SportEventConditions { get; set; }

        //[JsonProperty("channels")]
        //public List<Channel> Channels { get; set; }
    }
}
