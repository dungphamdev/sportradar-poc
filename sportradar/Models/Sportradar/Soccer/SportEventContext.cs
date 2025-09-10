using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SportEventContext
    {
        //[JsonProperty("sport")]
        //public Sport Sport { get; set; }

        //[JsonProperty("category")]
        //public Category Category { get; set; }

        [JsonProperty("competition")]
        public Competition Competition { get; set; } = new();

        //[JsonProperty("season")]
        //public Season Season { get; set; }

        //[JsonProperty("stage")]
        //public Stage Stage { get; set; }

        //[JsonProperty("round")]
        //public Round Round { get; set; }

        //[JsonProperty("groups")]
        //public List<Group> Groups { get; set; }
    }
}
