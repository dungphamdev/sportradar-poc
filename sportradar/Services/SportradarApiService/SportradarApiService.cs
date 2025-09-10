using Newtonsoft.Json;
using sportradar.Models.Sportradar.Soccer;
using sportradar.Models.Sportradar.Soccer.CompetitionSeasonsResponse;
using sportradar.Models.Sportradar.Soccer.CompetitionsResponse;
using sportradar.Models.Sportradar.Soccer.CompetitorSummariesResponse;
using sportradar.Models.Sportradar.Soccer.SeasonCompetitorsResponse;
using System.Net.Http.Headers;

namespace sportradar.Services.SportradarApiService
{
    public class SportradarApiService
    {
        private readonly string _apiKey;
        private readonly string _lang;
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://api.sportradar.com/soccer-extended/trial/v4/";

        public SportradarApiService(string apiKey, string lang = "en")
        {
            _apiKey = apiKey;
            _lang = lang;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(BaseUrl)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _apiKey);
        }

        /// <summary>
        /// Provides match information for all currently live matches including team scoring, 
        /// player and team match statistics. 
        /// This feed updates in real time as matches are played. 
        /// Matches appear a few minutes before kick-off and disappear a few minutes after the match reaches “ended” status.
        /// See API docs: Live Summaries - https://developer.sportradar.com/soccer/reference/soccer-live-summaries
        /// </summary>
        /// <returns>List of currently live match</returns>
        public async Task<LiveSummariesResponse?> GetLiveSportEventsAsync()
        {
            string endpoint = $"{_lang}/schedules/live/summaries.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LiveSummariesResponse>(json);
        }


        /// <summary>
        /// Provides real-time match-level statistics for a given match. 
        /// Including player and team stats, scoring info, and channel availability.
        /// See API docs: Sport Event Summary - https://developer.sportradar.com/soccer/reference/soccer-sport-event-summary
        /// </summary>
        /// <param name="sportEventId">MatchId (Unique identifier of the sport event)</param>
        /// <returns>Real-time match statistics for a given match.</returns>
        public async Task<SportEventSummaryResponse?> GetSportEventAsync(string sportEventId)
        {
            string endpoint = $"{_lang}/sport_events/{sportEventId}/summary.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SportEventSummaryResponse>(json);
        }


        /// <summary>
        /// Provides a list of all available Soccer competitions.
        /// See API docs: Competitions - https://developer.sportradar.com/soccer/reference/soccer-competitions
        /// </summary>
        /// <returns>List of all available Soccer leagues.</returns>
        public async Task<CompetitionsResponse?> GetCompetitionsAsync()
        {
            string endpoint = $"{_lang}/competitions.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompetitionsResponse>(json);
        }


        /// <summary>
        /// Provides historical season information for a given competition.
        /// Valid competition IDs can be found in the Competitions feed.
        /// See API docs: Competition Seasons - https://developer.sportradar.com/soccer/reference/soccer-competition-seasons
        /// </summary>
        /// <param name="competitionId">League Id (Unique identifier of the competition).</param>
        /// <returns>List of all season for a given league.</returns>
        public async Task<CompetitionSeasonsResponse?> GetCompetitionSeasonsAsync(string competitionId)
        {
            string endpoint = $"{_lang}/competitions/{competitionId}/seasons.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompetitionSeasonsResponse>(json);
        }


        /// <summary>
        /// Provides a list of teams participating for a given season.
        /// See API docs: Season Competitors - https://developer.sportradar.com/soccer/reference/soccer-season-competitors
        /// </summary>
        /// <param name="seasonId">Unique identifier of the season.</param>
        /// <returns>List of teams participating for a given season.</returns>
        public async Task<SeasonCompetitorsResponse?> GetSeasonCompetitorsAsync(string seasonId)
        {
            string endpoint = $"{_lang}/seasons/{seasonId}/competitors.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SeasonCompetitorsResponse>(json);
        }


        /// <summary>
        /// Provides scheduling information for upcoming matches 
        /// and statistics for the 30 most recent completed matches of a specified competitor.
        /// See API docs: Competitor Summaries - https://developer.sportradar.com/soccer/reference/soccer-competitor-summaries
        /// </summary>
        /// <param name="competitorId">Team Id (Unique identifier of the competitor).</param>
        /// <returns>A list of upcoming matches and the 30 most recent completed matches of the Team (competitor).</returns>
        public async Task<CompetitorSummariesResponse?> GetCompetitorSummariesAsync(string competitorId)
        {
            string endpoint = $"{_lang}/competitors/{competitorId}/summaries.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompetitorSummariesResponse>(json);
        }
    }
}
