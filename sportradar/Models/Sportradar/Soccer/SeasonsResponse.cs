using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SeasonsResponse
    {
        [JsonProperty("generated_at")]
        public DateTime GeneratedAt { get; set; }

        [JsonProperty("seasons")]
        public List<Season> Seasons { get; set; } = [];
    }
}
