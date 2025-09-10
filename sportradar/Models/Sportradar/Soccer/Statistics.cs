using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class Statistics
    {
        [JsonProperty("totals")]
        public Totals Totals { get; set; } = new();
    }
}
