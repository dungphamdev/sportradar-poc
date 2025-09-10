using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.CompetitionsResponse
{
    public class Category
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}
