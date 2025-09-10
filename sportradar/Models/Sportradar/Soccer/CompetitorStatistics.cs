using Newtonsoft.Json;

namespace sportradar.Models.Sportradar.Soccer
{
    public class CompetitorStatistics
    {
        [JsonProperty("ball_possession")]
        public int? BallPossession { get; set; }

        [JsonProperty("cards_given")]
        public int CardsGiven { get; set; }

        [JsonProperty("chances_created")]
        public int ChancesCreated { get; set; }

        [JsonProperty("clearances")]
        public int Clearances { get; set; }

        [JsonProperty("corner_kicks")]
        public int CornerKicks { get; set; }

        [JsonProperty("crosses_successful")]
        public int CrossesSuccessful { get; set; }

        [JsonProperty("crosses_total")]
        public int CrossesTotal { get; set; }

        [JsonProperty("crosses_unsuccessful")]
        public int CrossesUnsuccessful { get; set; }

        [JsonProperty("defensive_blocks")]
        public int DefensiveBlocks { get; set; }

        [JsonProperty("diving_saves")]
        public int DivingSaves { get; set; }

        [JsonProperty("fouls")]
        public int Fouls { get; set; }

        [JsonProperty("free_kicks")]
        public int FreeKicks { get; set; }

        [JsonProperty("goal_kicks")]
        public int GoalKicks { get; set; }

        [JsonProperty("injuries")]
        public int Injuries { get; set; }

        [JsonProperty("interceptions")]
        public int Interceptions { get; set; }

        [JsonProperty("long_passes_successful")]
        public int LongPassesSuccessful { get; set; }

        [JsonProperty("long_passes_total")]
        public int LongPassesTotal { get; set; }

        [JsonProperty("long_passes_unsuccessful")]
        public int LongPassesUnsuccessful { get; set; }

        [JsonProperty("offsides")]
        public int Offsides { get; set; }

        [JsonProperty("passes_successful")]
        public int PassesSuccessful { get; set; }

        [JsonProperty("passes_total")]
        public int PassesTotal { get; set; }

        [JsonProperty("passes_unsuccessful")]
        public int PassesUnsuccessful { get; set; }

        [JsonProperty("penalties_missed")]
        public int PenaltiesMissed { get; set; }

        [JsonProperty("red_cards")]
        public int? RedCards { get; set; }

        [JsonProperty("shots_blocked")]
        public int? ShotsBlocked { get; set; }

        [JsonProperty("shots_off_target")]
        public int? ShotsOffTarget { get; set; }

        [JsonProperty("shots_on_target")]
        public int? ShotsOnTarget { get; set; }

        [JsonProperty("shots_saved")]
        public int ShotsSaved { get; set; }

        [JsonProperty("shots_total")]
        public int ShotsTotal { get; set; }

        [JsonProperty("substitutions")]
        public int Substitutions { get; set; }

        [JsonProperty("tackles_successful")]
        public int TacklesSuccessful { get; set; }

        [JsonProperty("tackles_total")]
        public int TacklesTotal { get; set; }

        [JsonProperty("tackles_unsuccessful")]
        public int TacklesUnsuccessful { get; set; }

        [JsonProperty("throw_ins")]
        public int ThrowIns { get; set; }

        [JsonProperty("was_fouled")]
        public int WasFouled { get; set; }

        [JsonProperty("yellow_cards")]
        public int YellowCards { get; set; }

        [JsonProperty("yellow_red_cards")]
        public int YellowRedCards { get; set; }
    }
}
