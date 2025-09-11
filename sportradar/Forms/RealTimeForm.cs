using sportradar.Helpers;
using sportradar.Models;
using sportradar.Models.Sportradar.Soccer;
using sportradar.Services.SportradarApiService;
using System.Configuration;

namespace sportradar.Forms
{
    public partial class RealTimeForm : Form
    {
        private readonly SportradarApiService _apiService;
        private Summary? _currentSportEventSummary;
        private string _sportEventId;

        public RealTimeForm(string matchId)
        {
            InitializeComponent();

            _sportEventId = matchId;
            var apiKey = ConfigurationManager.AppSettings["SportradarApiKey"] ?? string.Empty;
            _apiService = new SportradarApiService(apiKey);
        }

        #region Form Events
        //private async void btnSearch_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        btnSearch.Enabled = false;
        //        StopAutoRefresh();

        //        string home = txtHome.Text.Trim();
        //        string away = txtAway.Text.Trim();

        //        if (string.IsNullOrEmpty(home) || string.IsNullOrEmpty(away))
        //        {
        //            MessageBox.Show("Please enter both Home and Away team names.");
        //            return;
        //        }

        //        //Get List of currently live match
        //        var resp = await _apiService.GetLiveSportEventsAsync();

        //        if (resp == null || resp.Summaries.Count == 0)
        //        {
        //            MessageBox.Show("No live matches available.");
        //            return;
        //        }

        //        var selectedSummary = FindMatchByTeams(resp, home, away);

        //        if (selectedSummary == null)
        //        {
        //            MessageBox.Show("No matching live match found.");
        //            return;
        //        }

        //        var sportEventId = selectedSummary.SportEvent.Id;

        //        //Get Real-time match statistics for a given match
        //        var eventResponse = await _apiService.GetSportEventAsync(sportEventId);

        //        if (eventResponse == null) return;

        //        var sportEventSummary = new Summary
        //        {
        //            SportEvent = eventResponse.SportEvent,
        //            SportEventStatus = eventResponse.SportEventStatus,
        //            Statistics = eventResponse.Statistics,
        //        };

        //        if (ShowConfirmDialog(sportEventSummary))
        //        {
        //            var homeTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "home").Name;
        //            var awayTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "away").Name;
        //            var leagueName = sportEventSummary.SportEvent.SportEventContext.Competition.Name;
        //            lblMatchName.Text = $"{homeTeam} vs {awayTeam} | {leagueName}";
        //            var match = BuildLiveMatch(sportEventSummary);
        //            BindMatchData(match);

        //            StartAutoRefresh(sportEventSummary); // start refreshing every 10 seconds (liveStatsTimer)
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            $"An error occurred:\n{ex.Message}",
        //            "Error",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error
        //        );
        //        Console.WriteLine(ex.ToString());
        //    }
        //    finally
        //    {
        //        btnSearch.Enabled = true;
        //    }
        //}

        /// <summary>
        /// Timer loop runs every interval (in seconds) set in liveStatsTimer.
        /// Used to get real-time match data (auto refresh statistics).
        /// To change refresh time -> adjust liveStatsTimer.Interval (milliseconds) in Form designer.
        /// </summary>
        private async void liveStatsTimer_Tick(object sender, EventArgs e)
        {
            if (_currentSportEventSummary == null) return;

            try
            {
                //Get Real-time match statistics for a given match
                var resp = await _apiService.GetSportEventAsync(_currentSportEventSummary.SportEvent.Id);

                if (resp == null) throw new Exception("Match not found!");

                var updatedMatch = new Summary
                {
                    SportEvent = resp.SportEvent,
                    SportEventStatus = resp.SportEventStatus,
                    Statistics = resp.Statistics
                };

                if (updatedMatch != null)
                {
                    var match = BuildLiveMatch(updatedMatch);
                    BindMatchData(match);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Refresh failed: {ex.Message}");
            }
        }

        private void RealTimeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAutoRefresh();
        }
        private async void RealTimeForm_Load(object sender, EventArgs e)
        {
            try
            {
                var sportEventId = _sportEventId;

                //Get Real-time match statistics for a given match
                var eventResponse = await _apiService.GetSportEventAsync(sportEventId);

                if (eventResponse == null) return;

                var sportEventSummary = new Summary
                {
                    SportEvent = eventResponse.SportEvent,
                    SportEventStatus = eventResponse.SportEventStatus,
                    Statistics = eventResponse.Statistics,
                };

                //if (ShowConfirmDialog(sportEventSummary))
                {
                    var homeTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "home").Name;
                    var awayTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "away").Name;
                    var leagueName = sportEventSummary.SportEvent.SportEventContext.Competition.Name;
                    lblMatchName.Text = $"{homeTeam} vs {awayTeam} | {leagueName}";
                    var match = BuildLiveMatch(sportEventSummary);
                    BindMatchData(match);

                    StartAutoRefresh(sportEventSummary); // start refreshing every 10 seconds (liveStatsTimer)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion Form Events


        #region Common
        //private Summary? FindMatchByTeams(LiveSummariesResponse resp, string home, string away)
        //{
        //    foreach (var summary in resp.Summaries)
        //    {
        //        var competitors = summary.SportEvent?.Competitors;
        //        if (competitors == null)
        //            continue;

        //        var homeTeam = competitors.FirstOrDefault(c => c.Qualifier == "home")?.Name ?? string.Empty;
        //        var awayTeam = competitors.FirstOrDefault(c => c.Qualifier == "away")?.Name ?? string.Empty;

        //        bool homeMatch = homeTeam.Contains(home, StringComparison.OrdinalIgnoreCase);
        //        bool awayMatch = awayTeam.Contains(away, StringComparison.OrdinalIgnoreCase);

        //        if (homeMatch && awayMatch)
        //        {
        //            return summary;
        //        }
        //    }

        //    return null;
        //}

        //private bool ShowConfirmDialog(Summary sportEventSummary)
        //{
        //    var homeTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "home").Name;
        //    var awayTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "away").Name;
        //    var leagueName = sportEventSummary.SportEvent.SportEventContext.Competition.Name;

        //    var confirm = MessageBox.Show(
        //        $"Match found:\n" +
        //        $"League: {leagueName}\n" +
        //        $"{homeTeam} vs {awayTeam}\n" +
        //        $"Score: {sportEventSummary.SportEventStatus.HomeScore} - {sportEventSummary.SportEventStatus.AwayScore}\n" +
        //        $"Time: {sportEventSummary.SportEventStatus.Clock.Played}'\n\nDo you want to track this match?",
        //        "Confirm Match", MessageBoxButtons.YesNo);

        //    return confirm == DialogResult.Yes;
        //}

        private RealTimeView.LiveMatch BuildLiveMatch(Summary sportEventSummary)
        {
            var result = new RealTimeView.LiveMatch();

            var homeStats = sportEventSummary.Statistics.Totals.Competitors.FirstOrDefault(x => x.Qualifier == "home")?.Statistics;
            var awayStats = sportEventSummary.Statistics.Totals.Competitors.FirstOrDefault(x => x.Qualifier == "away")?.Statistics;

            result.TimeElapsed = sportEventSummary.SportEventStatus.Clock.Played;
            result.CurrentGoals = (sportEventSummary.SportEventStatus.HomeScore + sportEventSummary.SportEventStatus.AwayScore).ToString();
            result.GoalDiff = (sportEventSummary.SportEventStatus.HomeScore - sportEventSummary.SportEventStatus.AwayScore).ToString("+#;-#;0");

            if (homeStats != null && awayStats != null)
            {
                var homeDangerousAttacks = SportradarHelper.CalculateDangerousAttack(homeStats);
                var awayDangerousAttacks = SportradarHelper.CalculateDangerousAttack(awayStats);
                if (homeStats.ShotsOnTarget != null && awayStats.ShotsOnTarget != null)
                {
                    result.DangerousAttacks = (homeDangerousAttacks + awayDangerousAttacks).ToString() ?? string.Empty;
                }

                if (homeStats.ShotsOnTarget != null && awayStats.ShotsOnTarget != null)
                {
                    result.ShotsOnTarget = (homeStats.ShotsOnTarget + awayStats.ShotsOnTarget).ToString() ?? string.Empty;
                }

                if (homeStats.BallPossession != null && awayStats.BallPossession != null)
                {
                    result.PossessionGap =
                        (homeStats.BallPossession - awayStats.BallPossession)?.ToString("+#;-#;0") ?? string.Empty;
                }

                if (homeStats.RedCards != null && awayStats.RedCards != null)
                {
                    result.RedCards = $"{homeStats.RedCards} / {awayStats.RedCards}";
                }
            }

            return result;
        }

        private void BindMatchData(RealTimeView.LiveMatch match)
        {
            var data = match.GetType()
                .GetProperties()
                .Select(p => new RealTimeView.FieldValue
                {
                    Field = p.Name,
                    Value = p.GetValue(match)?.ToString() ?? ""
                })
                .ToList();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;
        }

        private void StartAutoRefresh(Summary sportEventSummary)
        {
            _currentSportEventSummary = sportEventSummary;
            liveStatsTimer.Start();
        }

        private void StopAutoRefresh()
        {
            if (liveStatsTimer != null && liveStatsTimer.Enabled)
            {
                liveStatsTimer.Stop();
            }
        }
        #endregion Common

    }
}
