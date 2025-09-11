namespace sportradar.Models
{
    public class HistoricalDataView
    {
        public DateTime MatchDate { get; set; }
        public string MatchName { get; set; } = string.Empty;
        public string FinalScore { get; set; } = string.Empty;
        public string SeasonName { get; set; } = string.Empty;

        // Extra stats
        public string PossessionGap { get; set; } = string.Empty;
        public string ShotsOnTarget { get; set; } = string.Empty;
        public string DangerousAttacks { get; set; } = string.Empty;
        public string RedCards { get; set; } = string.Empty;
        public string YellowCards { get; set; } = string.Empty;
        public string YellowRedCards { get; set; } = string.Empty;
        public string CardsGiven { get; set; } = string.Empty;
        public string CornerKicks { get; set; } = string.Empty;
        public string Fouls { get; set; } = string.Empty;
        public string FreeKicks { get; set; } = string.Empty;
        public string GoalKicks { get; set; } = string.Empty;
        public string Injuries { get; set; } = string.Empty;
        public string Offsides { get; set; } = string.Empty;
        public string ShotsBlocked { get; set; } = string.Empty;
        public string ShotsOffTarget { get; set; } = string.Empty;
        public string ShotsSaved { get; set; } = string.Empty;
        public string ShotsTotal { get; set; } = string.Empty;
        public string Substitutions { get; set; } = string.Empty;
        public string ThrowIns { get; set; } = string.Empty;

        //public DateTime MatchDate { get; set; }
        //public string MatchName { get; set; } = string.Empty;
        //public string FinalScore { get; set; } = string.Empty;
        //public string LeagueName { get; set; } = string.Empty;
        //public string PossessionGap { get; set; } = string.Empty;
        //public string ShotsOnTarget { get; set; } = string.Empty;
        //public string DangerousAttacks { get; set; } = string.Empty;
        //public string RedCards { get; set; } = string.Empty;
    }
}
