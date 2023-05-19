using BlazorApp.Models;
using BlazorApp.Services.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorApp.Services
{
    public class ProductService : ServiceBase, IRepository<Product>
    {
        private string _message;
        public string Message { get { return _message; } set { value = _message; } }
        public ProductService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Product>> Get()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}v1/products");
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _jsonSerializerOptions);
        }

        public async Task<Product> GetById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}v1/products/{id}");
            string json = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            Product product = JsonSerializer.Deserialize<Product>(json, _jsonSerializerOptions);
            product.Image = product.Images[0].ToString();
            product.CategoryId = product.Category.Id;
            return product;
        }

        public async Task Add(Product product)
        {
            HttpResponseMessage response = await _httpClient.PostAsync($"{_apiUrl}v1/products", JsonContent.Create(product));
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }
        }

        public async Task Update(Product product)
        {
            HttpContent httpContent = JsonContent.Create(product);
            HttpResponseMessage response = await _httpClient.PutAsync($"{_apiUrl}v1/products/{product.Id}", httpContent);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }
        }

        public async Task<bool> Delete(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"{_apiUrl}v1/products/{id}");
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = JsonSerializer.Deserialize<ResponseException>(json, _jsonSerializerOptions);
                _message = string.Join('\n', errorResponse.Message);
                return false;
            }

            return true;
        }
    }
}
