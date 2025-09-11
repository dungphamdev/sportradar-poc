using sportradar.Models;
using sportradar.Services.SportradarApiService;
using System.Configuration;

namespace sportradar.Forms
{
    public partial class LiveMatchesForm : Form
    {
        private readonly SportradarApiService _apiService;
        private List<LiveMatchDto> _originalData = [];

        public LiveMatchesForm()
        {
            InitializeComponent();

            var apiKey = ConfigurationManager.AppSettings["SportradarApiKey"] ?? string.Empty;
            _apiService = new SportradarApiService(apiKey);
        }

        #region Common

        private async Task BindLiveMatchesData(DataGridView dtgv)
        {
            //Get List of currently live match
            var resp = await _apiService.GetLiveSportEventsAsync();

            if (resp == null || resp.Summaries.Count == 0)
            {
                MessageBox.Show("No live matches available.");
                return;
            }

            var liveMatches = resp.Summaries;

            _originalData = resp.Summaries.Select(x => new LiveMatchDto
            {
                MatchId = x.SportEvent.Id,
                HomeTeam = x.SportEvent.Competitors.First(c => c.Qualifier == "home").Name,
                AwayTeam = x.SportEvent.Competitors.First(c => c.Qualifier == "away").Name,
                LeagueName = x.SportEvent.SportEventContext.Competition.Name + " | "
                           + x.SportEvent.SportEventContext.Category.Name,
                MatchName = x.SportEvent.Competitors.First(c => c.Qualifier == "home").Name + " vs "
                          + x.SportEvent.Competitors.First(c => c.Qualifier == "away").Name,
                Score = x.SportEventStatus.HomeScore + " - " + x.SportEventStatus.AwayScore,
                TimePlayed = x.SportEventStatus.Clock.Played,
            }).ToList();

            applyFilterMatch(txtHome.Text, txtAway.Text);
            dtgv.Columns[nameof(LiveMatchDto.MatchId)]!.Visible = false;
        }

        private void applyFilterMatch(string homeFilter, string awayFilter)
        {
            try
            {
                homeFilter = homeFilter.Trim();
                awayFilter = awayFilter.Trim();

                var filtered = _originalData.Where(m =>
                    m.HomeTeam.Contains(homeFilter, StringComparison.CurrentCultureIgnoreCase) &&
                    m.AwayTeam.Contains(awayFilter, StringComparison.CurrentCultureIgnoreCase)
                ).ToList();

                dtgvLiveMatches.DataSource = filtered;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while applying the filter. {ex}");
            }
        }

        #endregion Common

        #region Form Events

        private async void LiveMatchesForm_Load(object sender, EventArgs e)
        {
            try
            {
                await BindLiveMatchesData(dtgvLiveMatches);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred:\n{ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Console.WriteLine(ex);
            }
        }

        private void dtgvLiveMatches_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Ignore header row
                if (e.RowIndex < 0) return;

                if (dtgvLiveMatches.Rows[e.RowIndex].DataBoundItem is LiveMatchDto rowData
                    && !string.IsNullOrWhiteSpace(rowData.MatchId))
                {
                    var matchForm = new RealTimeForm(rowData.MatchId);
                    matchForm.Show();
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
                Console.WriteLine(ex);
            }
        }

        private void txtHome_TextChanged(object sender, EventArgs e)
        {
            applyFilterMatch(txtHome.Text, txtAway.Text);
        }

        private void txtAway_TextChanged(object sender, EventArgs e)
        {
            applyFilterMatch(txtHome.Text, txtAway.Text);
        }

        #endregion Form Events

    }
}
