using BlazorApp.Models;
using BlazorApp.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp.Services
{
    public class UsersService : ServiceBase, IRepository<User>
    {
        private string _message;
        public string Message { get => _message; set { value = _message; } }
        public UsersService(IConfiguration configuration) : base(configuration)
        {
        }


        public async Task Add(User entity)
        {
            HttpContent httpContent = JsonContent.Create(entity);
            HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}v1/users", httpContent);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}v1/users/{id}");
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<User>> Get()
        {
            string url = $"{_apiUrl}v1/users";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }

            return JsonSerializer.Deserialize<List<User>>(content, _jsonSerializerOptions);
        }

        public async Task<User> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}v1/users/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }

            return JsonSerializer.Deserialize<User>(content, _jsonSerializerOptions);
        }

        public async Task Update(User entity)
        {
            HttpContent httpContent = JsonContent.Create(entity);
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}v1/users/{entity.Id}", httpContent);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }
        }
    }
}
