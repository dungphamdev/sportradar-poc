using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class SportEventStatus
    {
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("match_status")]
        public string MatchStatus { get; set; } = string.Empty;

        [JsonProperty("home_score")]
        public int HomeScore { get; set; }

        [JsonProperty("away_score")]
        public int AwayScore { get; set; }

        [JsonProperty("winner_id")]
        public string WinnerId { get; set; } = string.Empty;

        //[JsonProperty("period_scores")]
        //public List<PeriodScore> PeriodScores { get; set; }

        //[JsonProperty("ball_locations")]
        //public List<BallLocation> BallLocations { get; set; }

        //[JsonProperty("match_situation")]
        //public MatchSituation MatchSituation { get; set; }

        [JsonProperty("clock")]
        public Clock Clock { get; set; } = new();
    }
}
