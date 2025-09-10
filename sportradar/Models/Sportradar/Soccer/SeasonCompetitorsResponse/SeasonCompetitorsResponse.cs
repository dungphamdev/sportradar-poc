using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.SeasonCompetitorsResponse
{
    public class SeasonCompetitorsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("season_competitors")]
        public List<SeasonCompetitor> SeasonCompetitors { get; set; } = [];
    }
}
