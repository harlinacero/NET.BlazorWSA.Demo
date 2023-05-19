using System.Text.Json;

namespace BlazorApp.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;
        protected readonly IConfiguration _configuration;
        protected readonly string _apiUrl;

        protected ServiceBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetValue<string>("apiUrl");
            _httpClient = new HttpClient();

            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };            
        }
    }
}