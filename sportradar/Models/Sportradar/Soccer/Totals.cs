using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class Totals
    {
        [JsonProperty("competitors")]
        public List<Competitor> Competitors { get; set; } = [];
    }
}
