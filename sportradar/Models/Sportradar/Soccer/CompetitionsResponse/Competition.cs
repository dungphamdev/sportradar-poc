using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.CompetitionsResponse
{
    public class Competition
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("gender")]
        public string Gender { get; set; } = string.Empty;

        [JsonProperty("category")]
        public Category Category { get; set; } = new();
    }
}
