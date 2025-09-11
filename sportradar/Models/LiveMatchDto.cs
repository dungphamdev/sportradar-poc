namespace sportradar.Models
{
    public class LiveMatchDto
    {
        public string MatchId { get; set; } = string.Empty;
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public string LeagueName { get; set; } = string.Empty;
        public string MatchName { get; set; } = string.Empty;
        public string Score { get; set; } = string.Empty;
        public string TimePlayed { get; set; } = string.Empty;
    }
}
