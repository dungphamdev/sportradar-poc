using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.SeasonCompetitorsResponse
{
    public class SeasonCompetitor
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("short_name")]
        public string ShortName { get; set; } = string.Empty;

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; } = string.Empty;

        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;
    }
}
