using BlazorApp.Models;
using BlazorApp.Services.Contracts;
using System.Text.Json;

namespace BlazorApp.Services
{
    public class ProductsFilterService : ProductService, IFilterService<Product>
    {
        public ProductsFilterService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Product>> GetByTitle(string title)
        {
            string url = $"{_apiUrl}v1/products/?title={title}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Product>> GetByPrice(decimal price)
        {
            string url = $"{_apiUrl}v1/products/?price={price}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Product>> GetByRangePrice(decimal minprice, decimal maxprice)
        {
            string url = $"{_apiUrl}v1/products/?price_min={minprice}&price_max={maxprice}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _jsonSerializerOptions);
        }

        public async Task<IEnumerable<Product>> GetByCategory(int id)
        {
            string url = $"{_apiUrl}v1/products/?categoryId={id}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            string json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(json);
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _jsonSerializerOptions);
        }
    }
}
