using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class Clock
    {
        [JsonProperty("played")]
        public string Played { get; set; } = string.Empty;
    }
}
