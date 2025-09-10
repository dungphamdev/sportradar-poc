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
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<LiveSummariesResponse?> GetLiveSportEventsAsync()
        {
            string endpoint = $"{_lang}/schedules/live/summaries.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LiveSummariesResponse>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sportEventId"></param>
        /// <returns></returns>
        public async Task<SportEventSummaryResponse?> GetSportEventAsync(string sportEventId)
        {
            string endpoint = $"{_lang}/sport_events/{sportEventId}/summary.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SportEventSummaryResponse>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<CompetitionsResponse?> GetCompetitionsAsync()
        {
            string endpoint = $"{_lang}/competitions.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompetitionsResponse>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitionId"></param>
        /// <returns></returns>
        public async Task<CompetitionSeasonsResponse?> GetCompetitionSeasonsAsync(string competitionId)
        {
            string endpoint = $"{_lang}/competitions/{competitionId}/seasons.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CompetitionSeasonsResponse>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seasonId"></param>
        /// <returns></returns>
        public async Task<SeasonCompetitorsResponse?> GetSeasonCompetitorsAsync(string seasonId)
        {
            string endpoint = $"{_lang}/seasons/{seasonId}/competitors.json";
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SeasonCompetitorsResponse>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="competitorId"></param>
        /// <returns></returns>
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
