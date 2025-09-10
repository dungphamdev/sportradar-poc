using sportradar.Models.Sportradar.Soccer;

namespace sportradar.Helpers
{
    public static class SportradarHelper
    {
        public static int? CalculateDangerousAttack(CompetitorStatistics competitorStatistics)
        {
            if (competitorStatistics.ShotsOnTarget != null
                || competitorStatistics.ShotsOffTarget != null
                || competitorStatistics.ShotsBlocked != null)
            {
                return competitorStatistics.ShotsOnTarget + competitorStatistics.ShotsOffTarget + competitorStatistics.ShotsBlocked;
            }

            return null;
        }
    }
}
