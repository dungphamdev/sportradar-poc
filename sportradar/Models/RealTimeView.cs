namespace sportradar.Models
{
    public class RealTimeView
    {
        public class LiveMatch
        {
            public string TimeElapsed { get; set; } = string.Empty;
            public string DangerousAttacks { get; set; } = string.Empty;
            public string ShotsOnTarget { get; set; } = string.Empty;
            public string CurrentGoals { get; set; } = string.Empty;
            public string PossessionGap { get; set; } = string.Empty;
            public string GoalDiff { get; set; } = string.Empty;
            public string RedCards { get; set; } = string.Empty;
        }

        public class FieldValue
        {
            public string Field { get; set; } = "";
            public string Value { get; set; } = "";
        }
    }
}
