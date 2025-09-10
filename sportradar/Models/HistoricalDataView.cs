namespace sportradar.Models
{
    public class HistoricalDataView
    {
        public DateTime MatchDate { get; set; }
        public string MatchName { get; set; } = string.Empty;
        public string FinalScore { get; set; } = string.Empty;
        public string LeagueName { get; set; } = string.Empty;
        public string PossessionGap { get; set; } = string.Empty;
        public string ShotsOnTarget { get; set; } = string.Empty;
        public string DangerousAttacks { get; set; } = string.Empty;
        public string RedCards { get; set; } = string.Empty;


        //public string TimeElapsed { get; set; } = string.Empty;
    }
}
