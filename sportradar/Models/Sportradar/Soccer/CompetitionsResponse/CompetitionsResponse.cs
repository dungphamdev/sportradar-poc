using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.CompetitionsResponse
{
    public class CompetitionsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("competitions")]
        public List<Competition> Competitions { get; set; } = [];
    }
}
