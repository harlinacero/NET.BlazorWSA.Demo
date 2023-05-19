using BlazorApp.Models;
using BlazorApp.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp.Services
{
    public class CategoryService : ServiceBase, IRepository<Category>
    {
        private string _message;
        public string Message { get => _message; set { value = _message; } }
        public CategoryService(IConfiguration configuration) : base(configuration)
        {
        }


        public async Task Add(Category entity)
        {
            HttpContent httpContent = JsonContent.Create(entity);
            HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}v1/categories", httpContent);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }
        }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}v1/categories/{id}");
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            string url = $"{_apiUrl}v1/categories";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }

            return JsonSerializer.Deserialize<List<Category>>(content, _jsonSerializerOptions);
        }

        public async Task<Category> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}v1/categories/{id}");
            string content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }

            return JsonSerializer.Deserialize<Category>(content, _jsonSerializerOptions);
        }

        public async Task Update(Category entity)
        {
            HttpContent httpContent = JsonContent.Create(entity);
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}v1/categories/{entity.Id}", httpContent);
            string content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(content, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
            }
        }
    }
}
