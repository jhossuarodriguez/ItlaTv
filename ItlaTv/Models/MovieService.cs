using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;


namespace ItlaTv.Models
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public MovieService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["MovieApi:ApiKey"] ?? throw new ArgumentNullException(nameof(_apiKey));
            _baseUrl = configuration["MovieApi:BaseUrl"] ?? throw new ArgumentNullException(nameof(_baseUrl));
        }

        public async Task<JObject> GetPopularMoviesAsync()
        {
            string requestUrl = $"{_baseUrl}movie/popular?api_key={_apiKey}";
            var response = await _httpClient.GetStringAsync(requestUrl);
            return JObject.Parse(response);
        }
    }
}
