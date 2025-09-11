using sportradar.Helpers;
using sportradar.Models;
using sportradar.Models.Sportradar.Soccer;
using sportradar.Models.Sportradar.Soccer.CompetitionSeasonsResponse;
using sportradar.Models.Sportradar.Soccer.SeasonCompetitorsResponse;
using sportradar.Services.SportradarApiService;
using System.Configuration;
using System.Threading.Tasks;

namespace sportradar.Forms
{
    public partial class HistoricalData2Form : Form
    {
        private readonly SportradarApiService _apiService;
        private List<Models.Sportradar.Soccer.CompetitionsResponse.Competition>? _competitions;
        private List<Models.Sportradar.Soccer.Season>? _seasons;
        private List<Summary>? _currentSeasons;

        public HistoricalData2Form()
        {
            InitializeComponent();

            var apiKey = ConfigurationManager.AppSettings["SportradarApiKey"] ?? string.Empty;
            _apiService = new SportradarApiService(apiKey);
        }

        #region Common

        private void LoadYearCombobox()
        {
            int currentYear = DateTime.UtcNow.Year;

            var years = new List<int>();
            for (int i = 0; i <= 10; i++) // last 10 years
            {
                years.Add(currentYear - i);
            }

            cbbYear.DataSource = years;
            cbbLeague.SelectedIndex = -1;
        }

        private async Task LoadLeaguesComboboxAsync()
        {
            try
            {
                cbbLeague.Enabled = false;
                cbbLeague.Items.Add("Loading...");
                cbbLeague.SelectedIndex = 0;
                //Get all league and bind to dropdown (combobox)
                var resp = await _apiService.GetCompetitionsAsync()
                           ?? throw new Exception("Unexpected response from server.");
                _competitions = resp.Competitions
                    .OrderBy(x => x.Name)
                    .ToList();

                BindLeagueComboboxData(cbbLeague);
            }
            finally
            {
                cbbLeague.Enabled = true;
            }
        }

        private void BindLeagueComboboxData(ComboBox combobox)
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
            combobox.SelectedIndex = -1;
        }

        private async Task LoadTeamsComboboxAsync()
        {
            try
            {
                if (cbbYear.SelectedValue != null
                    && cbbLeague.SelectedValue != null)
                {
                    cbbTeam.DataSource = null;
                    cbbTeam.Items.Clear();
                    cbbTeam.Enabled = false;
                    cbbTeam.Items.Add("Loading...");
                    cbbTeam.SelectedIndex = 0;

                    int selectedYear = (int)cbbYear.SelectedValue;
                    var selectedLeagueId = cbbLeague.SelectedValue.ToString();

                    if (string.IsNullOrWhiteSpace(selectedLeagueId)) return;

                    //Get season from `selectedYear` and `selectedLeagueId`
                    var seasonId = await GetSeasonIdByYearAndLeague(selectedYear, selectedLeagueId);
                    if (string.IsNullOrWhiteSpace(seasonId)) return;

                    ////Get all match for a given season
                    //_currentSeasons = [];
                    //int start = 0;
                    //int limit = 100; // max allowed by API
                    //while (true)
                    //{
                    //    var seasonSummariesResp = await _apiService.GetSeasonSummariesAsync(seasonId, start, limit)
                    //           ?? throw new Exception("Unexpected response from server.");

                    //    if (seasonSummariesResp.Summaries.Count == 0)
                    //    {
                    //        break;
                    //    }

                    //    _currentSeasons.AddRange(seasonSummariesResp.Summaries);

                    //    // next page
                    //    start += limit;

                    //    //Delay to prevent spamming
                    //    await Task.Delay(500);
                    //}

                    //_currentSeasons = _currentSeasons
                    //    .Where(x => x.SportEvent.StartTime.Date < DateTime.UtcNow.Date)
                    //    .ToList();

                    //var lstTeam = _currentSeasons
                    //    .SelectMany(m => m.SportEvent.Competitors)
                    //    .DistinctBy(c => c.Id)
                    //    .OrderBy(c => c.Name)
                    //    .ToList();

                    //Get all team for a given season
                    var seasonCompetitorsResp = await _apiService.GetSeasonCompetitorsAsync(seasonId)
                           ?? throw new Exception("Unexpected response from server.");

                    var lstTeam = seasonCompetitorsResp.SeasonCompetitors
                        .OrderBy(x => x.Name).ToList();

                    BindComboboxTeamData(cbbTeam, lstTeam);
                }
            }
            finally
            {
                cbbTeam.Enabled = true;
            }
        }

        private void BindComboboxTeamData(ComboBox combobox, List<SeasonCompetitor> seasonCompetitors)
        {
            if (seasonCompetitors == null) return;

            combobox.DisplayMember = "Display";
            combobox.ValueMember = "Id";

            combobox.DataSource = seasonCompetitors
                .Select(c => new
                {
                    Id = c.Id,
                    Display = $"{c.Name}"
                })
                .ToList();
            combobox.SelectedIndex = -1;
        }

        private async Task<string> GetSeasonIdByYearAndLeague(int year, string leagueId)
        {
            if (_seasons == null)
            {
                //var resp = await _apiService.GetCompetitionSeasonsAsync(leagueId);
                var resp = await _apiService.GetSeasonsAsync();
                if (resp == null) return string.Empty;

                _seasons = resp.Seasons;
            }

            var result = _seasons
                .FirstOrDefault(x => x.StartDate.Year == year && x.CompetitionId == leagueId)?
                .Id ?? string.Empty;

            return result;
        }

        private async Task LoadHistoricalAsync()
        {
            if (cbbYear.SelectedValue == null
                || cbbLeague.SelectedValue == null
                || cbbTeam.SelectedValue == null)
            {
                MessageBox.Show("Please select Year, League and Team.");
                return;
            }


            int selectedYear = (int)cbbYear.SelectedValue;
            var selectedLeagueId = cbbLeague.SelectedValue.ToString();

            if (string.IsNullOrWhiteSpace(selectedLeagueId)) return;

            //Get season from `selectedYear` and `selectedLeagueId`
            var seasonId = await GetSeasonIdByYearAndLeague(selectedYear, selectedLeagueId);

            if (string.IsNullOrWhiteSpace(seasonId)) return;
            var teamId = cbbTeam.SelectedValue.ToString();

            await PrepareSeasonData(seasonId);

            if (_currentSeasons == null) throw new Exception("Cannot get season data. Please try again");

            var season = _currentSeasons;

            var data = season
                .Where(m => m.SportEvent.Competitors.Any(c => c.Id == teamId))
                .Select(BuildHistoricalMatch)
                .OrderByDescending(x => x.MatchDate)
                .ToList();

            BindMatchData(data, dtgvHistoricalData);
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
            result.SeasonName = _currentSeasons?.FirstOrDefault()?.SportEvent.SportEventContext.Season.Name ?? leagueName;
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

                if (homeStats.YellowCards != null && awayStats.YellowCards != null)
                    result.YellowCards = (homeStats.YellowCards + awayStats.YellowCards).ToString() ?? string.Empty;

                if (homeStats.YellowRedCards != null && awayStats.YellowRedCards != null)
                    result.YellowRedCards = (homeStats.YellowRedCards + awayStats.YellowRedCards).ToString() ?? string.Empty;

                if (homeStats.CardsGiven != null && awayStats.CardsGiven != null)
                    result.CardsGiven = (homeStats.CardsGiven + awayStats.CardsGiven).ToString() ?? string.Empty;

                if (homeStats.CornerKicks != null && awayStats.CornerKicks != null)
                    result.CornerKicks = (homeStats.CornerKicks + awayStats.CornerKicks).ToString() ?? string.Empty;

                if (homeStats.Fouls != null && awayStats.Fouls != null)
                    result.Fouls = (homeStats.Fouls + awayStats.Fouls).ToString() ?? string.Empty;

                if (homeStats.FreeKicks != null && awayStats.FreeKicks != null)
                    result.FreeKicks = (homeStats.FreeKicks + awayStats.FreeKicks).ToString() ?? string.Empty;

                if (homeStats.GoalKicks != null && awayStats.GoalKicks != null)
                    result.GoalKicks = (homeStats.GoalKicks + awayStats.GoalKicks).ToString() ?? string.Empty;

                if (homeStats.Injuries != null && awayStats.Injuries != null)
                    result.Injuries = (homeStats.Injuries + awayStats.Injuries).ToString() ?? string.Empty;

                if (homeStats.Offsides != null && awayStats.Offsides != null)
                    result.Offsides = (homeStats.Offsides + awayStats.Offsides).ToString() ?? string.Empty;

                if (homeStats.ShotsBlocked != null && awayStats.ShotsBlocked != null)
                    result.ShotsBlocked = (homeStats.ShotsBlocked + awayStats.ShotsBlocked).ToString() ?? string.Empty;

                if (homeStats.ShotsOffTarget != null && awayStats.ShotsOffTarget != null)
                    result.ShotsOffTarget = (homeStats.ShotsOffTarget + awayStats.ShotsOffTarget).ToString() ?? string.Empty;

                if (homeStats.ShotsSaved != null && awayStats.ShotsSaved != null)
                    result.ShotsSaved = (homeStats.ShotsSaved + awayStats.ShotsSaved).ToString() ?? string.Empty;

                if (homeStats.ShotsTotal != null && awayStats.ShotsTotal != null)
                    result.ShotsTotal = (homeStats.ShotsTotal + awayStats.ShotsTotal).ToString() ?? string.Empty;

                if (homeStats.Substitutions != null && awayStats.Substitutions != null)
                    result.Substitutions = (homeStats.Substitutions + awayStats.Substitutions).ToString() ?? string.Empty;

                if (homeStats.ThrowIns != null && awayStats.ThrowIns != null)
                    result.ThrowIns = (homeStats.ThrowIns + awayStats.ThrowIns).ToString() ?? string.Empty;
            }

            return result;
        }

        private async Task PrepareSeasonData(string seasonId)
        {
            if (_currentSeasons?.FirstOrDefault()?.SportEvent.SportEventContext.Season.Id == seasonId) return;

            //Get all match for a given season
            _currentSeasons = [];
            int start = 0;
            int limit = 100; // max allowed by API
            while (true)
            {
                var seasonSummariesResp = await _apiService.GetSeasonSummariesAsync(seasonId, start, limit)
                       ?? throw new Exception("Unexpected response from server.");

                if (seasonSummariesResp.Summaries.Count == 0)
                {
                    break;
                }

                _currentSeasons.AddRange(seasonSummariesResp.Summaries);

                // next page
                start += limit;

                //Delay to prevent spamming
                await Task.Delay(500);
            }

            _currentSeasons = _currentSeasons
                .Where(x => x.SportEvent.StartTime.Date < DateTime.UtcNow.Date)
                .ToList();
        }

        private void DisableFormAccess()
        {
            cbbYear.Enabled = false;
            cbbLeague.Enabled = false;
            cbbTeam.Enabled = false;
            btnSearch.Enabled = false;
        }

        private void EnableFormAccess()
        {
            cbbYear.Enabled = true;
            cbbLeague.Enabled = true;
            if (cbbYear.SelectedIndex >= 0 || cbbLeague.SelectedIndex >= 0)
            {
                cbbTeam.Enabled = true;
                btnSearch.Enabled = true;
            }
        }

        #endregion Common

        #region Form Events

        private async void HistoricalData2Form_Load(object sender, EventArgs e)
        {
            try
            {
                DisableFormAccess();
                LoadYearCombobox();
                await LoadLeaguesComboboxAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load leagues. Please try again later.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex.ToString());
                this.Close();
            }
            finally
            {
                EnableFormAccess();
            }
        }

        private async void cbbLeague_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DisableFormAccess();
                await LoadTeamsComboboxAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load teams. Please try again later.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex);
            }
            finally
            {
                EnableFormAccess();
            }
        }

        private async void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DisableFormAccess();
                await LoadTeamsComboboxAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to load teams. Please try again later.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex);
            }
            finally
            {
                EnableFormAccess();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DisableFormAccess();
                await LoadHistoricalAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to search. Please try again later.",
                    "Load Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex);
            }
            finally
            {
                EnableFormAccess();
            }
        }

        #endregion Form Events
    }
}
