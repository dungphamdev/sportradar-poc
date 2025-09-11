using sportradar.Helpers;
using sportradar.Models;
using sportradar.Models.Sportradar.Soccer;
using sportradar.Models.Sportradar.Soccer.SeasonCompetitorsResponse;
using sportradar.Services.SportradarApiService;
using System.Configuration;

namespace sportradar.Forms
{
    public partial class HistoricalDataForm : Form
    {
        private readonly SportradarApiService _apiService;
        private List<Models.Sportradar.Soccer.CompetitionsResponse.Competition>? _competitions;

        public HistoricalDataForm()
        {
            InitializeComponent();

            var apiKey = ConfigurationManager.AppSettings["SportradarApiKey"] ?? string.Empty;
            _apiService = new SportradarApiService(apiKey);
        }

        #region Form Events

        private async void HistoricalDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Get all league and bind to dropdown (combobox)
                var resp = await _apiService.GetCompetitionsAsync()
                           ?? throw new Exception("Unexpected response from server.");
                _competitions = resp.Competitions
                    .OrderBy(x => x.Name)
                    .ToList();

                BindComboboxData(cbbHomeCompetitions);
                BindComboboxData(cbbAwayCompetitions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load competitions. Please try again later.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex.ToString());
                this.Close();
            }
        }

        private async void btnSearchHome_Click(object sender, EventArgs e)
        {
            try
            {
                btnSearchHome.Enabled = false;

                await LoadHistoricalAsync(txtHome.Text, cbbHomeCompetitions, dtgvHome);
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
            finally
            {
                btnSearchHome.Enabled = true;
            }
        }

        private async void btnSearchAway_Click(object sender, EventArgs e)
        {

            try
            {
                btnSearchAway.Enabled = false;

                await LoadHistoricalAsync(txtAway.Text, cbbAwayCompetitions, dtgvAway);
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
            finally
            {
                btnSearchAway.Enabled = true;
            }
        }
        #endregion Form Events

        #region Common

        private async Task LoadHistoricalAsync(string teamName, ComboBox cbbCompetitions, DataGridView dtgv)
        {
            if (cbbCompetitions.SelectedValue == null)
            {
                MessageBox.Show("Please select league.");
                return;
            }

            if (string.IsNullOrWhiteSpace(teamName))
            {
                MessageBox.Show("Please enter team names.");
                return;
            }

            var competitionId = cbbCompetitions.SelectedValue.ToString();

            //Get all league
            var competitionSeasonsResp = await _apiService.GetCompetitionSeasonsAsync(competitionId!);

            if (competitionSeasonsResp == null)
            {
                return;
            }

            var seasonCompetitors = new List<SeasonCompetitor>();

            foreach (var competitionSeason in competitionSeasonsResp.Seasons)
            {
                //Get all team for a given season
                var seasonCompetitorsResp = await _apiService.GetSeasonCompetitorsAsync(competitionSeason.Id);
                if (seasonCompetitorsResp != null)
                {
                    seasonCompetitors.AddRange(seasonCompetitorsResp.SeasonCompetitors);
                }
            }

            seasonCompetitors = seasonCompetitors.DistinctBy(x => x.Id).ToList();

            var matchCompetitor = seasonCompetitors
                .FirstOrDefault(x => x.Name.Contains(teamName, StringComparison.OrdinalIgnoreCase));

            if (matchCompetitor != null && ShowConfirmDialog(matchCompetitor))
            {
                //Get all upcoming matches and statistics for the 30 most recent completed matches of a specified Team
                var competitorSummariesResp = await _apiService.GetCompetitorSummariesAsync(matchCompetitor.Id);
                if (competitorSummariesResp == null) return;
                var competitorSummaries = competitorSummariesResp.Summaries;

                // Filter past matches only
                competitorSummaries = competitorSummaries
                    .Where(x => x.SportEvent.StartTime.Date < DateTime.UtcNow.Date)
                    .ToList();

                var data = competitorSummaries
                    .Select(x => BuildHistoricalMatch(x))
                    .ToList();

                //Load data to DataGridView
                BindMatchData(data, dtgv);
            }
            else
            {
                MessageBox.Show("Team not found in this league.");
                return;
            }
        }

        private void BindMatchData(List<HistoricalDataView> data, DataGridView dtgv)
        {
            dtgv.AutoGenerateColumns = true;
            dtgv.DataSource = data;
        }

        private HistoricalDataView BuildHistoricalMatch(Summary sportEventSummary)
        {
            var result = new HistoricalDataView();

            var homeTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "home").Name;
            var awayTeam = sportEventSummary.SportEvent.Competitors.First(x => x.Qualifier == "away").Name;
            var leagueName = sportEventSummary.SportEvent.SportEventContext.Competition.Name;

            result.MatchDate = sportEventSummary.SportEvent.StartTime.Date;
            result.MatchName = $"{homeTeam} vs {awayTeam}";
            result.LeagueName = leagueName;
            result.FinalScore = $"{sportEventSummary.SportEventStatus.HomeScore} - {sportEventSummary.SportEventStatus.AwayScore}";

            var homeStats = sportEventSummary.Statistics.Totals.Competitors.FirstOrDefault(x => x.Qualifier == "home")?.Statistics;
            var awayStats = sportEventSummary.Statistics.Totals.Competitors.FirstOrDefault(x => x.Qualifier == "away")?.Statistics;

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

        private bool ShowConfirmDialog(SeasonCompetitor competitor)
        {
            var confirm = MessageBox.Show(
                $"Team found:\n" +
                $"Full name: {competitor.Name}\n" +
                $"Short name: {competitor.ShortName}\n" +
                $"Gender: {competitor.Gender}\n" +
                $"\nDo you want to track this team?",
                "Confirm Match", MessageBoxButtons.YesNo);

            return confirm == DialogResult.Yes;
        }

        private void BindComboboxData(ComboBox combobox)
        {
            if (_competitions == null) return;

            combobox.DisplayMember = "Display";
            combobox.ValueMember = "Id";

            combobox.DataSource = _competitions
                .Select(c => new
                {
                    Id = c.Id,
                    Display = $"{c.Name} | {c.Category.Name} ({c.Gender})"
                })
                .ToList();
        }

        #endregion Common
    }
}
