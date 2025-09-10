using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer.CompetitionSeasonsResponse
{
    public class Season
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; } = string.Empty;

        [JsonProperty("competition_id")]
        public string CompetitionId { get; set; } = string.Empty;
    }
}
