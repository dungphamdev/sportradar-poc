using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class Competitor
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("country")]
        public string Country { get; set; } = string.Empty;

        [JsonProperty("country_code")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; } = string.Empty;

        [JsonProperty("qualifier")]
        public string Qualifier { get; set; } = string.Empty;

        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonProperty("statistics")]
        public CompetitorStatistics Statistics { get; set; } = new();

        //[JsonProperty("players")]
        //public List<Player> Players { get; set; }
    }
}
